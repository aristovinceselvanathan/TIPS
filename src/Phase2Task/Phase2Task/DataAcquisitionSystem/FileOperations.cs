using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// The file operations.
    /// </summary>
    public class FileOperations
    {
        public static DataAcquisitionSettings LoadSettingsFromJson()
        {
            DataAcquisitionSettings dataAcquisitionSettings;
            using(StreamReader reader = new StreamReader("Settings.json"))
            {
                dataAcquisitionSettings = JsonConvert.DeserializeObject<DataAcquisitionSettings>(reader.ReadToEnd());
            }
            return dataAcquisitionSettings;
        }

        /// <summary>
        /// Logs the data to file.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public static void LogDataToFile(string logMessage, string logfile)
        {
            using(StreamWriter writer = new StreamWriter(logfile, true))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
