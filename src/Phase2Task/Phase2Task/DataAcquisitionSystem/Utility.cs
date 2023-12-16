using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public static class Utility
    {
        public static int GetIntegerInput(string entityName)
        {
            Console.Write($"Enter the {entityName}: ");
            string userInput = Console.ReadLine();
            if(!int.TryParse(userInput, out int result))
            {
                Console.WriteLine("Enter the integer input!!!");
                return GetIntegerInput(entityName);
            }
            return result;
        }
        public static string GetStringInput(string entityName)
        {
            Console.Write($"Enter the {entityName}: ");
            string userInput = Console.ReadLine();
            if(string.IsNullOrEmpty(userInput))
            {
                return GetStringInput(entityName);
            }
            return userInput;
        }
    }
}
