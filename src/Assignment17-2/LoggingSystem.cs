namespace Logger
{
    /// <summary>
    /// Logging System Class
    /// </summary>
    public class LoggingSystem
    {
        private static readonly object Padlock = new object();
        private static LoggingSystem instance;

        private LoggingSystem()
        {
        }

        // Implement Singleton logic here using Double-Checked Locking

        /// <summary>
        /// Gets instance and lock the object of the current thread (Singleton Logic)
        /// </summary>
        /// <value>
        /// Reference of LoggingSystem
        /// </value>
        public static LoggingSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (Padlock)
                    {
                        if (instance == null)
                        {
                            instance = new LoggingSystem();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// It will select the type of the logger
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="type">Type of the message</param>
        public void LogMethod(string message, string type)
        {
            ILogger logger = new SimpleLoggerFactory().CreateLogger(type);
            logger.Log(message);
        }
    }
}
