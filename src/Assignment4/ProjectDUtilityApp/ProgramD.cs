namespace ProjectDUtilityApp
{
    using System.Text.RegularExpressions;

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
            Console.WriteLine("Hello, World!");
        }

        /// <summary>
        /// Method checks for the string is null or not.
        /// </summary>
        /// <param name="s">It takes the input as string</param>
        /// <returns>It returns string</returns>
        public string CheckStringIsNull(string? s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return " ";
            }

            return s;
        }

        /// <summary>
        /// It matches string with the regex pattern.
        /// </summary>
        /// <param name="input">It takes string as an input to be matched with the pattern</param>
        /// <returns>It returns boolean</returns>
        public bool PatternMatch(string input)
        {
            Regex regex = new Regex("[0-9]+");
            if (regex.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
