using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public bool StartBoilerSequence()
        {

            InterLock = true;
            if (InterLock)
            {
               return InitializeTheSequence();
            }
            else
            {
                FileOperation.LogToTheFile("InterLock State is Open");
                Console.WriteLine("InterLock State is Open");
            }
            return false;
        }
        private bool KeyPressed(Thread thread)
        {
            while (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return true;
            }
            return false;
        }

        private bool StopTheExecution()
        {
            Console.Write("Press the Escape key to Stop The Operation or Press any to continue: ");
            if(Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return false;
            }
            Console.WriteLine();
            return true;
        }

        private bool InitializeTheSequence()
        {
            bool flag = false;
            PrePurgeCycle();
            if(BoilerState.Equals("Pre - Purge") && StopTheExecution())
            {
                Ignition();
                flag = true;
            }
            else
            {
                InterLock = false;
                return true;
            }
            if (BoilerState.Equals("Ignition") && flag && StopTheExecution())
            {
                Operational();
            }
            else
            {
                InterLock = false;
                return true;
            }
            return false;
        }
        private void PrePurgeCycle()
        {
            Console.Clear();
            int countDown = 10;
            BoilerState = "Pre - Purge";
            while (countDown >= 0)
            {
                Console.WriteLine($"Boiler State : {BoilerState}");
                Console.WriteLine($"CountDown for this State : {countDown}");
                countDown--;
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.WriteLine("Press the E Key to Stimulate the Error or Any Key to Continue");
            if(Console.ReadKey().Key == ConsoleKey.E)
            {
                StimulateBoilerError();
            }
        }
        private void Ignition()
        {
            Console.Clear();
            BoilerState = "Ignition";
            int countDown = 10;
            while (countDown >= 0)
            {
                Console.WriteLine($"Boiler State : {BoilerState}");
                Console.WriteLine($"CountDown for this State : {countDown}");
                countDown--;
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.WriteLine("Press the E Key to Stimulate the Error or Any Key to Continue");
            if (Console.ReadKey().Key == ConsoleKey.E)
            {
                StimulateBoilerError();
            }
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
            try
            {
                throw new Exception("Boiler have crashed");
            }
            catch(Exception e)
            {
                BoilerState = "LockOut";
                InterLock = false;
                FileOperation.LogToTheFile("Boiler have crashed");
            }
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
