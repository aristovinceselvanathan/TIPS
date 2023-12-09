using System.IO;

namespace LoggingSystem
{
    /// <summary>
    /// Program Class it consists of the entry point of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Access same file multiple times
        /// </summary>
        /// <param name="args">It is string array of the main method</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Logger System");
            int numberOfUser = 5;
            Parallel.For(1, numberOfUser + 1, i =>
            {
                Logger.LogError("Error Occurred", i);
            });
            Logger.ReadTheLogFile();
        }
    }
}
