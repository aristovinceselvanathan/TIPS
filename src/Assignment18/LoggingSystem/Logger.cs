using System.Text;

namespace LoggingSystem
{
    /// <summary>
    /// Logger Class
    /// </summary>
    public class Logger
    {
        private static string _logFilePath = "log.txt";
        private static readonly object padlock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
        }

        /// <summary>
        /// Log Error Method
        /// </summary>
        /// <param name="errorMessage">Error Message</param>
        /// <param name="id">It takes the id</param>
        public static void LogError(string errorMessage, int id)
        {
            try
            {
                lock (padlock)
                {
                    if (File.Exists(_logFilePath))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            DateTime now = DateTime.Now;
                            string formattedDateTime = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            byte[] errorBytes = Encoding.UTF8.GetBytes($"Loop {id} : {errorMessage} : {formattedDateTime}\n");
                            memoryStream.Write(errorBytes, 0, errorBytes.Length);
                            using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
                            {
                                memoryStream.WriteTo(fileStream);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exists");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred");
            }
        }

        /// <summary>
        /// Read the Log File
        /// </summary>
        public static void ReadTheLogFile()
        {
            if (File.Exists(_logFilePath))
            {
                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Open))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                    fileStream.SetLength(0);
                }
            }
            else
            {
                Console.WriteLine("File doesn't exists");
            }
        }
    }
}