namespace FileDataProcessor
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method it will perform the read operation
        /// </summary>
        /// <param name="args">It is string array of the main method</param>
        public static void Main(string[] args)
        {
            string inputFilePath = "source.txt";
            string outputFilePath = "destination.txt";
            Console.WriteLine("Welcome to File Data Processor");
            Console.WriteLine("\nPress enter to continue, Press Escape Key to Exit.");
            ConsoleKey consoleKey = Console.ReadKey(true).Key;
            if (consoleKey == ConsoleKey.Escape)
            {
                Console.WriteLine("Exiting...");
                return;
            }
            else if (consoleKey == ConsoleKey.Enter)
            {
                DataProcessor.ReadFromTheFile(inputFilePath, outputFilePath);
                DataProcessor.SaveTheProcessedData(inputFilePath, outputFilePath);
            }
            else
            {
                Console.WriteLine("Invalid Key Pressed");
                Console.WriteLine("Exiting...");
            }
        }
    }
}