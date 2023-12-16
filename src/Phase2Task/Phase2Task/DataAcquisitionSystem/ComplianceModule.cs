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

        public ComplianceModule()
        {
            Parameters = new List<Parameter>();
        }

        /// <summary>
        /// Changes the parameters.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        public void ChangeParameters(Parameter parameter)
        {
            Parameters.Add(parameter);
        }
    }
}
