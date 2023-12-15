using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// The compliance module.
    /// </summary>
    public class ComplianceModule
    {
        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public List<Parameter> Parameters { get; private set; }

        /// <summary>
        /// Sets the parameters.
        /// </summary>
        /// <param name="parameterType">The parameter type.</param>
        /// <param name="highValue">The high value.</param>
        /// <param name="lowValue">The low value.</param>
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

        /// <summary>
        /// Changes the parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void ChangeParameters(List<Parameter> parameters)
        {
            Parameters = parameters;
        }
    }
}
