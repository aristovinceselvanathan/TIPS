using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    /// <summary>
    /// The data acquisition settings.
    /// </summary>
    public class DataAcquisitionSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAcquisitionSettings"/> class.
        /// </summary>
        /// <param name="rate">The rate.</param>
        /// <param name="parameters">The parameters.</param>
        public DataAcquisitionSettings(int rate, List<Parameter> parameters)
        {
            Rate = rate;
            Parameters = parameters;
        }

        /// <summary>
        /// Gets the rate.
        /// </summary>
        public int Rate { get; private set; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        public List<Parameter> Parameters { get; private set; }
    }
}
