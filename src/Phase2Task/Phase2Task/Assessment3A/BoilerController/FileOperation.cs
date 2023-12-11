using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerController
{
    public static class FileOperation
    {
        public static void LogToTheFile(string message, bool warningMessage = false, string fileName = "log")
        {
            if (warningMessage == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(message);
            string logMessage = $"{DateTime.Now}, {message}";
            using (StreamWriter streamWrite = new StreamWriter($"{fileName}.csv", true))
            {
                streamWrite.WriteLine(logMessage);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string LogFromTheFile(string fileName = "log")
        {
            string output = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader($"{fileName}.csv"))
                {
                    output = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log File data not found");
            }
            return output;
        }
    }
}