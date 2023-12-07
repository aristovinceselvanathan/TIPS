using Newtonsoft.Json;

namespace ExpenseTracker
{
    /// <summary>
    /// File Operation Class
    /// </summary>
    /// <typeparam name="T">Denotes the type of class</typeparam>
    internal class FileOperation<T>
    {
        /// <summary>
        /// Load data to the file by using json serialize
        /// </summary>
        /// <param name="fileName">File name of the data to stored</param>
        /// <param name="entriesDirectory">List of the data to be stored</param>
        /// <typeparam name="T">Type of entry</typeparam>
        public void LoadToTheFile<T>(string fileName, List<T> entriesDirectory)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter($"..\\..\\..\\Data\\{fileName}.json"))
                {
                    string jsonData = JsonConvert.SerializeObject(entriesDirectory, Formatting.Indented);
                    writer.WriteLine(jsonData);
                }

                Utility.PrintSuccessfulMessage($"Successfully loaded to the {fileName}\n");
            }
            catch (Exception exception)
            {
                Utility.PrintErrorMessage($"Unable to access the file : {exception.Message}\n");
            }
        }

        /// <summary>
        /// Load data to the file by using json serialize
        /// </summary>
        /// <param name="fileName">File name of the data to be restored</param>
        /// <returns>List of the data to be restored</returns>
        /// <typeparam name="T">Type of entry</typeparam>
        public List<T> LoadFromTheFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader($"..\\..\\..\\Data\\{fileName}.json"))
                {
                    List<T> entriesDirectory = JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
                    Utility.PrintSuccessfulMessage($"Successfully loaded to the {fileName}\n");
                    return entriesDirectory;
                }
            }
            catch (Exception exception)
            {
                Utility.PrintErrorMessage($"Unable to access the file : {exception.Message}\n");
            }

            return null;
        }

        /// <summary>
        /// Log details to the file
        /// </summary>
        /// <param name="fileName">File name of the log to stored</param>
        /// <param name="logMessage">log message to be stored</param>
        public void LogToTheFile(string fileName, string logMessage)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter($"..\\..\\..\\Data\\{fileName}.txt", true))
                {
                    writer.WriteLine($"{DateTime.Now}:{logMessage}");
                }
            }
            catch (Exception exception)
            {
                Utility.PrintErrorMessage($"Unable to access the file : {exception.Message}\n");
            }
        }
    }
}
