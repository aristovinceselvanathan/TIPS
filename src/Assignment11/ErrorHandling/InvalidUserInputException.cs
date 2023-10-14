namespace ErrorHandling
{
    /// <summary>
    /// Exception class to handle the invalid user
    /// </summary>
    internal class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message">Message about the error to throw exception</param>
        public InvalidUserInputException(string message)
            : base(message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}