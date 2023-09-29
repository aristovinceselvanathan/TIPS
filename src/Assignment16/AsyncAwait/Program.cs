namespace AsyncAwait
{
    /// <summary>
    /// Program Class contains the entry point of the program
    /// </summary>
    public class Program
    {
        private enum Options
        {
            Website = 1,
            Exit = 2,
        }

        /// <summary>
        /// Main method load the content from the web and print the content.
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            Task<string> data = null;

            while (flag)
            {
                Console.Write("Welcome to Data Extractor from Website \n\nChoose the Option 1 - Enter the Website 2 - Exit : ");
                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    Options option = (Options)userInput;
                    switch (option)
                    {
                        case Options.Website:
                            Console.Write("\nEnter the Website : ");
                            data = GetFromServer.GetFromWeb(Console.ReadLine());
                            break;
                        case Options.Exit:
                            SuccessfulColor("\nExiting....");
                            flag = false;
                            break;
                        default:
                            InvalidWarning("\nInvalid Option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Number");
                }

                Console.Out.WriteLine(data.Result);
                Console.WriteLine("Press Escape to Exit, Press Delete to Clear and Continue, Press Enter to Continue");
                ConsoleKey userPressedKey = Console.ReadKey().Key;
                if (userPressedKey == ConsoleKey.Escape)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else if (userPressedKey == ConsoleKey.Delete)
                {
                    Console.Clear();
                }
                else if (userPressedKey == ConsoleKey.Enter)
                {
                    Console.WriteLine("Going Back...");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// It shows the warning message of the invalid input
        /// </summary>
        /// <param name="nameOfInput">Name of the input to display the message</param>
        public static void InvalidWarning(string nameOfInput)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// It shows the message of the answer in the calculator
        /// </summary>
        /// <param name="input">input that display the message</param>
        public static void SuccessfulColor(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{input}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}