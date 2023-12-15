using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public class DataAcquisitionModule
    {
        Random random = new Random();
        public delegate void ChangeValue();
        public event ChangeValue ValueChanged;
        public int current;
        public int temperature;
        public (int, int) currentValue
        {
            get
            {
                return (current, temperature);
            }
            private set
            {
                current = value.Item1;
                temperature = value.Item2;
                ValueChanged.Invoke();
            }
        }

        public void GenerateData(DataAcquisitionSettings dataAcquisitionSettings)
        {
            int valueForCurrent = random.Next(dataAcquisitionSettings.Parameters.ElementAt(0).LowValue, dataAcquisitionSettings.Parameters.ElementAt(0).HighValue);
            int valueForTemperature = random.Next(dataAcquisitionSettings.Parameters.ElementAt(1).LowValue, dataAcquisitionSettings.Parameters.ElementAt(1).HighValue);\
            currentValue = (valueForCurrent , valueForTemperature);
        }
    }
}
