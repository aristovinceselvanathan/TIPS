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
        public DataAcquisitionSettings LoadSettingsFromJson()
        {
            DataAcquisitionSettings dataAcquisitionSettings;
            using(StreamReader reader = new StreamReader("Settings.json"))
            {
                dataAcquisitionSettings = JsonConvert.DeserializeObject<DataAcquisitionSettings>(reader.ReadToEnd());
            }
            return dataAcquisitionSettings;
        }
        public void LogDataToFile(string logMessage)
        {
            using(StreamWriter writer = new StreamWriter("Log.txt"))
            {
                writer.WriteLine(logMessage);
            }
        }
        public void Load()
        {
            using(StreamWriter writer = new StreamWriter("Settings.json"))
            {
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(new Parameter(120, 100, Parameter.ParameterType.Current));
                parameters.Add(new Parameter(50, 30, Parameter.ParameterType.Temperature));
                DataAcquisitionSettings dataAcquisitionSettings= new DataAcquisitionSettings(1, parameters);
                string data = JsonConvert.SerializeObject(dataAcquisitionSettings, Formatting.Indented);
                writer.WriteLine(data);
            }
        }
    }
}
