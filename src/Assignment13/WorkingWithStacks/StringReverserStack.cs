namespace StringReverser
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// StringReverser Class
    /// </summary>
    /// <typeparam name="T">It takes the type</typeparam>
    internal class StringReverserStack<T>
    {
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

        /// <summary>
        /// It takes the string input from the user and reverse it using stack
        /// </summary>
        /// <param name="stack">It takes the stack</param>
        public void StringReverser(Stack<T> stack)
        {
            string userInput, output = " ";

            Console.WriteLine("Welcome to String Reverser");
            Console.WriteLine("Enter the string to reverse it : ");
            userInput = Console.ReadLine().Trim();
            if (ValidUserInput(userInput))
            {
                foreach (var item in userInput)
                {
                    stack.Push(TryConvert(item));
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

        // Helper method to try to convert a string to type T
        private static T TryConvert(char input)
        {
            try
            {
                // You can use TypeConverter or parse methods specific to T's type here
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
