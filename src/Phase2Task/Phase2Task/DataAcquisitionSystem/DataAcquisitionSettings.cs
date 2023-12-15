using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public class DataAcquisitionSettings
    {
        public DataAcquisitionSettings(int rate, List<Parameter> parameters)
        {
            Rate = rate;
            Parameters = parameters;
        }

        public int Rate { get; private set; }

        public List<Parameter> Parameters { get; private set; }
    }
}
