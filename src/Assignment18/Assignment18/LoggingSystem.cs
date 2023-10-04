namespace Assignment18
{
    /// <summary>
    /// Logging System
    /// </summary>
    public class LoggingSystem
    {

        private static LoggingSystem instance;

        private static readonly object padlock = new object();

        private LoggingSystem() { }

        // Implement Singleton logic here using Double-Checked Locking

        /// <summary>
        /// Gets instance
        /// </summary>
        /// <value>
        /// Reference of Logging System
        /// </value>
        public static LoggingSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
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
        /// Log the message in the console
        /// </summary>
        /// <param name="message">It is message to be printed</param>
        /// <param name="type">It is type of the message</param>
        public void LogMethod(string message, string type)
        {

        }

        public interface ILogger { void Log(string message); }
        public abstract class LoggerFactory { public abstract ILogger CreateLogger(string type); }

        public class PlainTextLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class JSONLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class SimpleLoggerFactory : LoggerFactory
        {
            public override ILogger CreateLogger(string type)
            {
                switch(type)
                {
                    case "JSON":
                        return new JSONLogger();
                    case "PlainText":
                        return new PlainTextLogger();
                    default:
                        return new Exception("Invalid Type");
                }
            }
        }

    }
}
