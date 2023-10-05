namespace FileDataProcessorAsync
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">It is string array of the main method</param>
        /// <returns>Task</returns>
        public static async Task Main(string[] args)
        {
            ColorfulMessage("Welcome to File Processor Simultaneously");
            string[] sources = {"source1.txt", "source2.txt", "source3.txt" };
            await FileDataProcessorAsync.FileProcessAsync(sources, "destination\\");
        }

        /// <summary>
        /// It will print the colorful message
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="color">Color of the message</param>
        public static void ColorfulMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}