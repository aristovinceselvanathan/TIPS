using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    internal class FileOperations
    {
        public DataAcquisitionModule LoadSettingsFromJson()
        {
            DataAcquisitionModule dataAcquisitionModule;
            using(StreamReader reader = new StreamReader("Setting.json"))
            {
                dataAcquisitionModule = JsonConvert.DeserializeObject<DataAcquisitionModule>(reader.ReadToEnd());
            }
            return dataAcquisitionModule;
        }
        public void LogDataToFile(string logMessage)
        {
            using(StreamWriter writer = new StreamWriter("Log.txt"))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
