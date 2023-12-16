using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    public partial class Parameter
    {
        public string parameterType;
        public int HighValue;
        public int LowValue;

        public Parameter(int highValue, int lowValue, string parameterType)
        {
            HighValue = highValue;
            LowValue = lowValue;
            this.parameterType = parameterType;
        }
        public Parameter()
        {

        }
    }
}
