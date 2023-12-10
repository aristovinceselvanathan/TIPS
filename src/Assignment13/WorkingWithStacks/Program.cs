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
            Console.WriteLine("Welcome to String Reverser");
            Console.WriteLine("Enter the string to reverse it : ");
            string userInput = Console.ReadLine().Trim();
            StringReverserStack<char> stringReverserStack = new ();
            Stack<char> stack = new Stack<char>();
            Console.WriteLine($"Reversed String : {stringReverserStack.StringReverser(stack, userInput)}");
        }
    }
}