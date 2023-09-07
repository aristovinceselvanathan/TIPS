namespace IDisposableDemo
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that writes the text into the file.
        /// </summary>
        /// <param name="args">It takes the string array from command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Text Editor");
            string path = "Hello.txt";
            using (FileWriter fileWriter = new FileWriter(path))
            {
                fileWriter.WriteToTheFile("Hello, How are you?");   // It writes the Hello, How are you? to the file
            }

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string content = reader.ReadToEnd();   // It reads the file content
                    Console.WriteLine($"Content {content}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}