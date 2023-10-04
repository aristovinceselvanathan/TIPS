namespace Logger
{
    /// <summary>
    /// JSON Logger Class
    /// </summary>
    public class JSONLogger : ILogger
    {
        /// <summary>
        /// Log the message to the console
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public void Log(string message)
        {
            Console.WriteLine($"{{\"message\": \"{message}\"}}");
        }
    }
}
