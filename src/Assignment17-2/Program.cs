namespace Logger
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// It is main method that will log into the console
        /// </summary>
        /// <param name="args">It is string array in the parameter of the main method</param>
        public static void Main(string[] args)
        {
            LoggingSystem loggingSystem = LoggingSystem.Instance;
            Console.WriteLine("Welcome to Logger System\n");
            loggingSystem.LogMethod("This is Plain Text Logger", "PlainText");
            loggingSystem.LogMethod("This is JSON Logger", "JSON");
        }
    }
}