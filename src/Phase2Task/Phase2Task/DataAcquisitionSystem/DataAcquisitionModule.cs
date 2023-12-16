using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public Dictionary<string, int> Parameters = new Dictionary<string, int>();
        public ComplianceModule complianceModule;

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
            foreach (var item in dataAcquisitionSettings.Parameters)
            {
                if (Parameters.ContainsKey(item.parameterType))
                {
                    Parameters[item.parameterType] = random.Next(item.LowValue, item.HighValue);
                }
                else
                {
                    Parameters.Add(item.parameterType, random.Next(item.LowValue, item.HighValue));
                }
            }
            ValueChanged.Invoke(complianceModule);
        }

        /// <summary>
        /// Data the changed.
        /// </summary>
        /// <param name="complianceModule">The compliance module.</param>
        public void DataChanged(ComplianceModule complianceModule)
        {
            try
            {
                for (int i = 0; i < complianceModule.Parameters.Count; i++)
                {
                    if (Parameters.ElementAt(i).Value > complianceModule.Parameters.ElementAt(i).HighValue)
                    {
                        throw new Exception($"{complianceModule.Parameters.ElementAt(i).parameterType} is above compliance limit");
                    }
                    if (Parameters.ElementAt(i).Value < complianceModule.Parameters.ElementAt(i).LowValue)
                    {
                        throw new Exception($"{complianceModule.Parameters.ElementAt(i).parameterType} is below compliance limit");
                    }
                }
            }
            catch (Exception ex)
            {
                FileOperations fileOperations = new FileOperations();
                FileOperations.LogDataToFile($"{DateTime.Now}: {ex.Message}", "log.txt");
            }
        }
    }
}
