namespace ErrorHandling
{
    /// <summary>
    /// It is exception class to handle the invalid user
    /// </summary>
    internal class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        public InvalidUserInputException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// It creates the custom message for the error
        /// </summary>
        /// <param name="userName">It takes the name of user as the input</param>
        public InvalidUserInputException(string userName)
            : base($"{userName}")
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}