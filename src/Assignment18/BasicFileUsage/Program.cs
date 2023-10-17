using System.Text;

namespace BasicFileUsage
{
    /// <summary>
    /// Program Class consists entry point of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  Write and Read Operation in the file
        /// </summary>
        /// <param name="args">It is string in main method</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Write to the file and Read from the file");
            Console.Write("Enter the data to be added : ");
            string data = Console.ReadLine();
            AddDataToFile("welcome.txt", data);
        }

        /// <summary>
        /// Add data to the file and checks whether the file contains the data
        /// </summary>
        /// <param name="filePath">Path at which file is present</param>
        /// <param name="data">Data to be added to the file</param>
        public static void AddDataToFile(string filePath, string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            if (File.Exists(filePath))
            {
                // Writing to file using memoryStream
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    using MemoryStream memoryStream = new MemoryStream();
                    memoryStream.Write(buffer, 0, buffer.Length);
                    memoryStream.WriteTo(fileStream);
                }

                // Read from the file using FileStream
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fileStream.Seek(0, SeekOrigin.Begin);
                    int bytesRead;
                    Console.WriteLine("\nAvailable file content : ");
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                    }
                }
            }
            else
            {
                Console.WriteLine("File Path Doesn't Exist");
            }
        }
    }
}