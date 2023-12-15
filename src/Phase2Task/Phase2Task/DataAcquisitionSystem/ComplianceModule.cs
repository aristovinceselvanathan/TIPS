using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public class ComplianceModule
    {
        public List<Parameter> Parameters { get; private set; }

        public void SetParameters(Parameter.ParameterType parameterType, int highValue, int lowValue)
        {
            if (parameterType == Parameter.ParameterType.Current)
            {
                Parameters.ElementAt(0).HighValue = highValue;
                Parameters.ElementAt(0).LowValue = lowValue;
                return;
            }
            Parameters.ElementAt(1).HighValue = highValue;
            Parameters.ElementAt(1).LowValue = lowValue;
        }
    }
}
