using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    /// <summary>
    /// Utility class
    /// </summary>
    internal class Utility
    {
        /// <summary>
        /// Print the error message in red color
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Print the successful message in green color
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public static void PrintSuccessfulMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
