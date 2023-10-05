using System.IO;

namespace LoggingSystem
{
    /// <summary>
    /// Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method
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
