namespace FileDataProcessor
{
    using System.Diagnostics;

    /// <summary>
    /// Data Processor Class
    /// </summary>
    public class DataProcessor
    {
        /// <summary>
        /// Read the content from the file
        /// </summary>
        /// <param name="sourcePath">It is file path of the source</param>
        /// <param name="destinationPath">It is file path of the destination</param>
        public static void ReadFromTheFile(string sourcePath, string destinationPath)
        {
            if (File.Exists(sourcePath) && File.Exists(destinationPath))
            {
                int fileSize = (int)new FileInfo(sourcePath).Length;
                int bufferSize = Math.Min(fileSize, int.MaxValue);
                ColorfulMessage("\nWait until the reading the data from the file...", ConsoleColor.Yellow);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                ColorfulMessage("\nPress the Enter to Read the file using the file stream");
                Console.ReadKey();
                ReadFileUsingFileStream(sourcePath, bufferSize);
                ColorfulMessage("\nFile Read Successfully", ConsoleColor.Green);
                stopwatch.Stop();
                TimeSpan timeSpan1 = stopwatch.Elapsed;
                stopwatch.Restart();
                ColorfulMessage("\nPress Enter to read the file using the buffered stream", ConsoleColor.Yellow);
                ReadFileUsingBufferedStream(sourcePath, bufferSize);
                TimeSpan timeSpan2 = stopwatch.Elapsed;
                ColorfulMessage("\nFile Read Successfully", ConsoleColor.Green);
                ColorfulMessage($"\nTime Taken by File Stream : {timeSpan1.TotalSeconds} seconds", ConsoleColor.Yellow);
                ColorfulMessage($"\nTime Taken by Buffered Stream : {timeSpan2.TotalSeconds} seconds", ConsoleColor.Yellow);
                stopwatch.Stop();
            }
            else if (File.Exists(sourcePath) == false)
            {
                ColorfulMessage("Source file doesn't exists");
            }
            else if (File.Exists(destinationPath) == false)
            {
                ColorfulMessage("Destination file doesn't exists");
            }
            else
            {
                Console.WriteLine("Error Occurred");
            }
        }

        /// <summary>
        /// Read the file using the FileStream
        /// </summary>
        /// <param name="sourcePath">It is file path of the source</param>
        /// <param name="bufferSize">It consists of the buffer size</param>
        public static void ReadFileUsingFileStream(string sourcePath, int bufferSize)
        {
            using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open))
            {
                byte[] buffer = new byte[bufferSize];
                while (fileStream.Read(buffer, 0, buffer.Length) != 0)
                {
                    // Read the file by the chunk
                }
            }
        }

        /// <summary>
        /// Read the file using the FileStream
        /// </summary>
        /// <param name="sourcePath">It is file path of the source</param>
        /// <param name="bufferSize">It is consists of buffer size</param>
        public static void ReadFileUsingBufferedStream(string sourcePath, int bufferSize)
        {
            using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream, bufferSize))
                {
                    byte[] buffer = new byte[bufferSize];
                    while (fileStream.Read(buffer, 0, buffer.Length) != 0)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// It will process the file and save the processed data
        /// </summary>
        /// <param name="sourcePath">File path of the source file</param>
        /// <param name="destinationPath">File path of the destination file</param>
        public static void SaveTheProcessedData(string sourcePath, string destinationPath)
        {
            ColorfulMessage("\nWait, To process the data in the file", ConsoleColor.Yellow);
            if (File.Exists(sourcePath) == false || File.Exists(destinationPath) == false)
            {
                ColorfulMessage("The file does not exist!!!");
            }
            else
            {
                ColorfulMessage("\nProcessing the file...", ConsoleColor.Yellow);
                MemoryStream memoryStream = new MemoryStream();
                using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                {
                    fileStream.CopyTo(memoryStream);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(memoryStream))
                using (StreamWriter writer = new StreamWriter(destinationPath))
                {
                    string data = reader.ReadLine();
                    while (data != null)
                    {
                        writer.WriteLine(data.ToUpper());
                        data = reader.ReadLine();
                    }
                }

                using (StreamReader reader = new StreamReader(destinationPath))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    ColorfulMessage("\nSuccessfully Processed Data", ConsoleColor.Green);
                    Console.WriteLine($"\nProcessed Data First Line : {reader.ReadLine()}");
                }
            }
        }

        /// <summary>
        /// It will print the colorful message
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="color">Color of the message</param>
        public static void ColorfulMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
