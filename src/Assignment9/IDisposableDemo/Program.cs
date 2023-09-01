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
            Console.WriteLine("Enter the File Path : ");
            string path = Console.ReadLine();
            using (FileWriter fileWriter = new FileWriter(path))
            {
                fileWriter.WriteToTheFile("Hello World");   // It writes the Hello World to the file
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
                Console.WriteLine("File not found");
            }
        }
    }
}