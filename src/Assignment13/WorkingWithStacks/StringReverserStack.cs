namespace StringReverser
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// StringReverser Class
    /// </summary>
    /// <typeparam name="T">It takes the type of the Data for Parameter</typeparam>
    public class StringReverserStack<T>
    {
        /// <summary>
        /// It checks for the user input matches the alphabetic pattern
        /// </summary>
        /// <param name="userInput">User input contains only alphabetic characters</param>
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
        /// <param name="stack">It takes the stack to reverse the string</param>
        /// <param name="userInput">It takes the user Input to reverse it</param>
        /// <returns>It returns the string in reversed manner</returns>
        public string StringReverser(Stack<T> stack, string userInput)
        {
            string output = " ";
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

                return output.TrimStart();
            }
            else
            {
                return "Invalid Input";
            }
        }

        // Helper method to try to convert a string to type T
        private static T TryConvert(char input)
        {
            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
