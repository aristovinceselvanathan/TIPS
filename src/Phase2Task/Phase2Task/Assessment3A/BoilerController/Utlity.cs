using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoilerConsoleApplication
{
    public static class Utility
    {
        public static void PrintTheSuccessfulMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintTheWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static int GetTheIntegerInput(string entity)
        {
            Console.Write($"Enter the {entity} : ");
            string userInput = Console.ReadLine();
            if(int.TryParse(userInput, out int userIntegerValue))
            {
                return userIntegerValue;
            }
            else if(string.Compare(userInput, "end", StringComparison.InvariantCultureIgnoreCase) == 0) 
            {
                return 0;
            }
            else
            {
                FileOperation.LogToTheFile("Invalid Integer - Please enter the numbers");
                Utility.PrintTheWarningMessage("Invalid Integer - Please enter the numbers");
            }
            return GetTheIntegerInput(entity);
        }
        public static string GetTheStringInput(string entity)
        {
            Console.Write($"Enter the {entity} : ");
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            string userInput = Console.ReadLine();
            if (regex.IsMatch(userInput))
            {
                return userInput;
            }
            else if (string.Compare(userInput, "end", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return string.Empty;
            }
            else
            {
                FileOperation.LogToTheFile("Invalid Integer - Please enter the numbers");
                Utility.PrintTheWarningMessage("Invalid Integer - Please enter the numbers");
            }
            return GetTheStringInput(entity);
        }
    }
}
