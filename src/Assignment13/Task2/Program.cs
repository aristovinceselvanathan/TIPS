namespace Task2
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// It takes the string input from the user and reverse it using stack
        /// </summary>
        /// <param name="args">It takes the string array from the command interface</param>
        public static void Main(string[] args)
        {
            string userInput, output = " ";
            Stack<char> stack = new ();

            Console.WriteLine("Welcome to String Reverser");
            Console.WriteLine("Enter the string to reverse it : ");
            userInput = Console.ReadLine().Trim();
            if (ValidUserInput(userInput))
            {
                foreach (var item in userInput)
                {
                    stack.Push(item);
                }

                for (int i = 0; i < userInput.Length; i++)
                {
                    output += stack.Pop();
                }

                Console.WriteLine($"Given String : {userInput}");
                Console.WriteLine($"Reversed String : {output.Trim()}");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        /// <summary>
        /// It checks for the user input matches the alphabetic pattern
        /// </summary>
        /// <param name="userInput">User input alphabetic characters</param>
        /// <returns>Return true if it matches the condition,else false</returns>
        public static bool ValidUserInput(string userInput)
        {
            Regex pattern = new Regex("^[0-9A-Za-z\\s!@#$&()-`.+,/\"]+$");
            if (pattern.IsMatch(userInput))
            {
                return true;
            }

            return false;
        }
    }
}