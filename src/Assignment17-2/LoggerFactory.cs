namespace Logger
{
    /// <summary>
    /// Logger Factory Abstract class
    /// </summary>
    public abstract class LoggerFactory
    {
        /// <summary>
        /// Abstract Method CreateLogger
        /// </summary>
        /// <param name="type">Type of the logger</param>
        /// <returns>Reference of the ILogger</returns>
        public abstract ILogger CreateLogger(string type);
    }
}
