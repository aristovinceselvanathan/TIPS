namespace Logger
{
    /// <summary>
    /// SimpleLoggerFactory Class
    /// </summary>
    public class SimpleLoggerFactory : LoggerFactory
    {
        /// <summary>
        /// CreateLogger will create the logger based on input
        /// </summary>
        /// <param name="type">Type of the logger</param>
        /// <returns>Reference of the ILogger</returns>
        public override ILogger CreateLogger(string type)
        {
            switch (type)
            {
                case "JSON":
                    return new JSONLogger();
                case "PlainText":
                    return new PlainTextLogger();
                default:
                    throw new Exception("Invalid Type");
            }
        }
    }
}
