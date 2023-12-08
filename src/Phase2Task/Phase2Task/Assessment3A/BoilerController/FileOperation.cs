using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerConsoleApplication
{
    public static class FileOperation
    {
        public static void LogToTheFile(string errorMessage)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter("..\\..\\..\\Data\\Log.txt"))
                {
                    streamWriter.WriteLine(errorMessage);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unable to write to the file : {ex.Message}");
            }
        }
        public static string ReadTheLog()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader("..\\..\\..\\Data\\Log.txt"))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to read from the file : {ex.Message}");
            }
            return string.Empty;
        }
    }
}
