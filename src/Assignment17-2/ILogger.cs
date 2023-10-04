namespace Logger
{
    /// <summary>
    /// ILogger Interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// It will log the message in the console
        /// </summary>
        /// <param name="message">Message to be printed</param>
        void Log(string message);
    }
}