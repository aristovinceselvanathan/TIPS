using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerController
{
    public partial class InterLock
    {
        public InterLockState InterLockSwitch { get; private set; }

        public InterLock()
        {
            InterLockSwitch = InterLockState.Open;
        }

        public void ToggleInterLock()
        {
            if (InterLockSwitch == InterLockState.Open)
            {
                InterLockSwitch = InterLockState.Closed;
            }
            else
            {
                InterLockSwitch = InterLockState.Open;
            }
        }
    }
}