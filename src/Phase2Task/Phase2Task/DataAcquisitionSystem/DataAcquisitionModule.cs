using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem
{
    internal class DataAcquisitionModule
    {
        public int Rate { get; private set; }

        public List<Parameter> Parameters { get; private set; }
    }
}
