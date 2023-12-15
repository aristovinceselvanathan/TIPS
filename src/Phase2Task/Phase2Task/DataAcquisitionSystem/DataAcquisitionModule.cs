using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// The data acquisition module.
    /// </summary>
    public class DataAcquisitionModule
    {
        Random random = new Random();
        public delegate void ChangeValue(ComplianceModule complianceModule);
        public event ChangeValue ValueChanged;
        public int current = 0;
        public int temperature = 0;
        public ComplianceModule complianceModule;

        /// <summary>
        /// Gets the current value.
        /// </summary>
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
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAcquisitionModule"/> class.
        /// </summary>
        /// <param name="complianceRules">The compliance rules.</param>
        public DataAcquisitionModule(ComplianceModule complianceRules)
        {
            complianceModule = complianceRules;
            ValueChanged += DataChanged;
        }
        /// <summary>
        /// Generates the data.
        /// </summary>
        /// <param name="dataAcquisitionSettings">The data acquisition settings.</param>
        public void GenerateData(DataAcquisitionSettings dataAcquisitionSettings)
        {
            int valueForCurrent = random.Next(dataAcquisitionSettings.Parameters.ElementAt(0).LowValue, dataAcquisitionSettings.Parameters.ElementAt(0).HighValue);
            int valueForTemperature = random.Next(dataAcquisitionSettings.Parameters.ElementAt(1).LowValue, dataAcquisitionSettings.Parameters.ElementAt(1).HighValue);
            currentValue = (valueForCurrent, valueForTemperature);
        }

        /// <summary>
        /// Data the changed.
        /// </summary>
        /// <param name="complianceModule">The compliance module.</param>
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
                FileOperations fileOperations = new FileOperations();
                Console.SetCursorPosition(40, 1);
                Console.WriteLine($"Exception caught : {ex.Message}");
                FileOperations.LogDataToFile($"{DateTime.Now}: {ex.Message}");
                Console.WriteLine("\n1.Start\n2.Stop\n3.Configure Compliance\n4.Refresh Configurations\n0.Exit");
            }
        }
    }
}
