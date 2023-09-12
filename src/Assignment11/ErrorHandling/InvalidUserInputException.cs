namespace ErrorHandling
{
    /// <summary>
    /// It is exception class to handle the invalid user
    /// </summary>
    internal class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// It creates the custom message for the error
        /// </summary>
        /// <param name="message">It takes the custom message as the input</param>
        public InvalidUserInputException(string message)
            : base($"{message}")
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}