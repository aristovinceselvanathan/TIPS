using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    /// <summary>
    /// Utility class
    /// </summary>
    internal static class Utility
    {
        private static string _logFileName = "log";
        private static FileOperation<Income> _fileOperationIncome = new FileOperation<Income>();

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

        /// <summary>
        /// Get the string input from the user
        /// </summary>
        /// <param name="entityName">Name of the entity</param>
        /// <param name="userInterface">UserInterface to be called to entered end</param>
        /// <returns>string entered by the user</returns>
        public static string GetTheStringInput(string entityName, UserInterface userInterface)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Regex regex = new Regex("^[A-Za-z0-9]+$");
            Console.Write($"Enter the {entityName} : ");
            string userEnteredInput = Console.ReadLine();
            Console.WriteLine();
            if (regex.IsMatch(userEnteredInput))
            {
                return userEnteredInput;
            }
            else if (string.Compare(userEnteredInput, "end", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                userInterface.StartUserInterface(0);
            }

            Utility.PrintErrorMessage("Invalid Input - Please enter the valid characters");
            _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Input - Please enter the valid characters in the GetTheStringInput");
            return GetTheStringInput(entityName, userInterface);
        }

        /// <summary>
        /// Get the integer input from the user
        /// </summary>
        /// <param name="entityName">Name of the entity</param>
        /// <param name="userInterface">UserInterface to be called to entered end</param>
        /// <returns>string entered by the user</returns>
        public static int GetTheIntegerInput(string entityName, UserInterface userInterface)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Enter the {entityName} : ");
            string userEnteredInput = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(userEnteredInput, out int userEnteredValue))
            {
                return userEnteredValue;
            }
            else if (string.Compare(userEnteredInput, "end", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                userInterface.StartUserInterface(0);
            }

            Utility.PrintErrorMessage("Invalid Input - Please enter the valid integers");
            _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Input - Please enter the valid integers in the GetTheIntegerInput");
            return GetTheIntegerInput(entityName, userInterface);
        }

        /// <summary>
        /// Get the integer input from the user
        /// </summary>
        /// <param name="userInterface">UserInterface to be called to entered end</param>
        /// <returns>string entered by the user</returns>
        public static DateTime GetTheDateInput(UserInterface userInterface)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Regex regex = new Regex("^(0[1-9]|[12][0-9]|3[01])(-|/).(0[1-9]|1[012])(-|/).\\d{4}$");
            Console.WriteLine("Can I use the current date ? 1 - Yes, 2 - No");
            int userEnteredNumber = GetTheIntegerInput("Choice", userInterface);
            if (userEnteredNumber == 1)
            {
                return DateTime.Now.Date;
            }
            else if (userEnteredNumber == 2)
            {
                Console.Write($"Enter the Date(DD-MM-YYYY) : ");
                string userEnteredInput = Console.ReadLine();
                Console.WriteLine();
                if (regex.IsMatch(userEnteredInput))
                {
                    return DateTime.ParseExact(userEnteredInput, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (string.Compare(userEnteredInput, "end", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    userInterface.StartUserInterface(0);
                }
            }
            else
            {
                Utility.PrintErrorMessage("Enter the valid option - Please enter the option 1 or 2");
                _fileOperationIncome.LogToTheFile(_logFileName, "Enter the valid option - Please enter the option 1 or 2 in the GetTheDateInput");
            }

            Console.WriteLine();
            Utility.PrintErrorMessage("Invalid Input - Please enter the valid date of format (dd-mm-yyyy)");
            _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Input - Please enter the valid date of format (dd-mm-yyyy) in the GetTheDateInput");
            return GetTheDateInput(userInterface);
        }
    }
}