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
        /// <param name="message">User Entered Message to throw exception</param>
        public InvalidUserInputException(string message)
            : base($"{message}")
        {
            Console.ForegroundColor = ConsoleColor.Red; // It sets the color of the console text.
        }
    }
}