using System.Text;

namespace LoggingSystem
{
    /// <summary>
    /// Logger Class it consists of the entry point of the program
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
        /// Log Error Method uses the Singleton Pattern
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
            catch (Exception)
            {
                Console.WriteLine("Error Occurred");
            }
        }

        /// <summary>
        /// Read the Log File from the path
        /// </summary>
        public static void ReadTheLogFile()
        {
            if (File.Exists(_logFilePath))
            {
                try
                {
                    using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Open))
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                        fileStream.SetLength(0);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error Occurred in reading the file");
                }
            }
            else
            {
                Console.WriteLine("File doesn't exists");
            }
        }
    }
}