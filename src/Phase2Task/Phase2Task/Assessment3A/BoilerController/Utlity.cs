using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerController
{
    public static class Utility
    {
        public static int GetTheIntegerInput(string entityName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Enter the {entityName}: ");
            string userEnteredText = Console.ReadLine();
            if (int.TryParse(userEnteredText, out int userInput))
            {
                return userInput;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input");
            Console.ForegroundColor = ConsoleColor.White;
            return GetTheIntegerInput(entityName);
        }
    }
}
