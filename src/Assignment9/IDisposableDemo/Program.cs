namespace IDisposableDemo
{
    /// <summary>
    /// Program Class it contains the entry point of the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that writes the predefined text into the file by using the file writer and reads from the file.
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}