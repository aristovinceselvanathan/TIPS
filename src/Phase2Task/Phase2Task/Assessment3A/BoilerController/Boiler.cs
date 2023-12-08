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
               InitializeTheSequence();
            }
            else
            {
                FileOperation.LogToTheFile("InterLock State is Open");
                Console.WriteLine("InterLock State is Open");
            }
        }
        private bool KeyPressed(Thread thread)
        {
            while (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                return true;
            }
            return false;
        }

        private bool StopTheExecution()
        {
            Console.Write("Press the escape key to Stop The Operation or Press any to continue: ");
            if(Console.ReadKey().Key == ConsoleKey.Escape)
            {
                return false;
            }
            return true;
        }

        private void InitializeTheSequence()
        {
            bool flag = false;
            PrePurgeCycle();
            if(StopTheExecution())
            {
                Ignition();
                flag = true;
            }
            if (flag && StopTheExecution())
            {
                Operational();
            }
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
