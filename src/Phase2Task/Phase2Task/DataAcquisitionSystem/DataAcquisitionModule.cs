using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public class DataAcquisitionModule
    {
        Random random = new Random();
        public delegate void ChangeValue(ComplianceModule complianceModule);
        public event ChangeValue ValueChanged;
        public int current = 0;
        public int temperature = 0;
        public ComplianceModule complianceModule;

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
                ValueChanged.Invoke(complianceModule);
            }
        }
        public DataAcquisitionModule(ComplianceModule complianceRules)
        {
            complianceModule = complianceRules;
            ValueChanged += DataChanged;
        }
        public void GenerateData(DataAcquisitionSettings dataAcquisitionSettings)
        {
            int valueForCurrent = random.Next(dataAcquisitionSettings.Parameters.ElementAt(0).LowValue, dataAcquisitionSettings.Parameters.ElementAt(0).HighValue);
            int valueForTemperature = random.Next(dataAcquisitionSettings.Parameters.ElementAt(1).LowValue, dataAcquisitionSettings.Parameters.ElementAt(1).HighValue);
            currentValue = (valueForCurrent, valueForTemperature);
        }

        public void DataChanged(ComplianceModule complianceModule)
        {
            try
            {
                if (current > complianceModule.Parameters.ElementAt(0).HighValue)
                {
                    throw new Exception("Current is above compliance limit");
                }
                else if (current < complianceModule.Parameters.ElementAt(0).LowValue)
                {
                    throw new Exception("Current is below compliance limit");
                }
                if (temperature > complianceModule.Parameters.ElementAt(1).HighValue)
                {
                    throw new Exception("Temperature is below compliance limit");
                }
                if (temperature < complianceModule.Parameters.ElementAt(1).LowValue)
                {
                    throw new Exception("Temperature is below compliance limit");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught : {ex.Message}");
            }
        }
    }
}
