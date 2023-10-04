namespace Logger
{
    /// <summary>
    /// Plain Text Logger Class
    /// </summary>
    public class PlainTextLogger : ILogger
    {
        /// <summary>
        /// Log the message into the console
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
