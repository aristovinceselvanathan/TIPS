using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public partial class Parameter
    {
        public ParameterType parameterType;
        public int HighValue;
        public int LowValue;

        public Parameter(int highValue, int lowValue, ParameterType parameterType)
        {
            HighValue = highValue;
            LowValue = lowValue;
            this.parameterType = parameterType;
        }
    }
}
