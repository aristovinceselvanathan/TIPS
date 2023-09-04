namespace ProjectDUtilityApp
{
    /// <summary>
    /// ProgramD Class
    /// </summary>
    public class ProgramD
    {
        /// <summary>
        /// Main method that prints the Hello World
        /// </summary>
        /// <param name="args">It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, This is Utility Class");
        }

        /// <summary>
        /// It shows the warning message of the invalid input
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the input</param>
        public void InvalidNumberWarning(string nameOfInput)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Invalid {nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// It shows the message of the answer in the calculator
        /// </summary>
        /// <param name="answer">It takes the answer as a input</param>
        public void CorrectAnswerColor(string answer)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Answer is {answer}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
