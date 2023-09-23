namespace StringReverser
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class that contains the entry point of the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// It takes the string input from the user and reverse it using stack
        /// </summary>
        /// <param name="args">It takes the string array from the command interface</param>
        public static void Main(string[] args)
        {
            StringReverserStack<char> stringReverserStack = new ();
            Stack<char> stack = new Stack<char>();

            stringReverserStack.StringReverser(stack);
        }
    }
}