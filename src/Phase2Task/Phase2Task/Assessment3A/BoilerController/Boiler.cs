using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerConsoleApplication
{
    public class Boiler
    {
        public string BoilerState { get; private set; }
        public bool InterLock { get; private set; }

        public Boiler()
        {
            BoilerState = "Lockout";
        }

        public void StartBoilerSequence()
        {
            //Todo : change the interlock
            InterLock = true;
            if (InterLock)
            {
                PrePurgeCycle();
                Ignition();
                Operational();
            }
            else
            {
                FileOperation.LogToTheFile("InterLock State is Open");
                Console.WriteLine("InterLock State is Open");
            }
        }
        private void PrePurgeCycle()
        {
            BoilerState = "Pre - Purge";
            Thread.Sleep(10000);
        }
        private void Ignition()
        {
            BoilerState = "Ignition";
            Thread.Sleep(10000);
        }

        private void Operational()
        {
            BoilerState = "Operational";
        }
        public void StopBoilerSequence()
        {
            Utility.PrintTheSuccessfulMessage("Boiler Stopped");
            FileOperation.LogToTheFile("Boiler Stopped");
            BoilerState = "Ready";
            InterLock = false;
        }
        public void StimulateBoilerError()
        {
            FileOperation.LogToTheFile("Boiler have crashed");
            throw new Exception("Boiler have crashed");
        }
        public void ToggleInterLockSwitch()
        {
            if (InterLock)
            {
                InterLock = false;
                FileOperation.LogToTheFile("InterLock is Open");
                Utility.PrintTheSuccessfulMessage("InterLock is Open");
            }
            else
            {
                InterLock = true;
                FileOperation.LogToTheFile("InterLock is Closed");
                Utility.PrintTheSuccessfulMessage("InterLock is Closed");
            }
        }
        public void ResetLockOut()
        {
            InterLock = false;
            FileOperation.LogToTheFile("Reset to Default Open");
            Utility.PrintTheSuccessfulMessage("Reset to Default Open");
        }
    }
}
