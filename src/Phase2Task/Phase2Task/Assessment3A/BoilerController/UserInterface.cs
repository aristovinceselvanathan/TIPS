using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerConsoleApplication
{
    internal class UserInterface
    {
        private enum StartOptions
        {
            StartTheBoilerSequence = 1,
            ToggleRunInterLockSwitch,
            ResetLockout,
            ViewLogs,
            ExitApplication,
        }
        public void StartTheUserInterface()
        {
            Boiler boiler = new Boiler();
            bool flag = true, stopflag = false;
            while (flag)
            {
                Console.WriteLine("Boiler Controller Initialized\n");
                StartBoilerView(boiler);
                int userEnteredValue = Utility.GetTheIntegerInput("Choice");
                StartOptions options = (StartOptions)userEnteredValue;
                Console.Clear();
                switch (options)
                {
                    case StartOptions.StartTheBoilerSequence:
                        stopflag = StartBoilerSequence(boiler);
                        break;
                    case StartOptions.ToggleRunInterLockSwitch:
                        boiler.ToggleInterLockSwitch();
                        break;
                    case StartOptions.ResetLockout:
                        boiler.ResetLockOut();
                        break;
                    case StartOptions.ViewLogs:
                        ReadTheLog();
                        break;
                    case StartOptions.ExitApplication:
                        Console.WriteLine("Exiting...");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option - Please Enter the valid option from 1 to 5");
                        break;
                }
                if (flag && !stopflag)
                {
                    Console.WriteLine("\nPress the Escape key to exit or Press any to continue to Main Menu: ");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        flag = false;
                        Console.WriteLine("Exiting...");
                    }
                }
                Console.Clear();
            }
        }
        public bool StartBoilerSequence(Boiler boiler)
        {
            if(boiler.InterLock == false)
            {
                Utility.PrintTheWarningMessage("InterLock is in open state -  Please toggle it\n");
                StartTheUserInterface();
            }
            else
            {
                return boiler.StartBoilerSequence();
            }
            return false;
        }
        public void StartBoilerView(Boiler boiler)
        {
            Console.WriteLine($"Status : {boiler.BoilerState}");
            Console.WriteLine(boiler.InterLock == true ? "Interlock : Closed\n" : "Interlock : Open\n");
            Console.WriteLine($"1.Start Boiler Sequence\n2.Toggle Run InterLock(Open/Closed)\n3.Reset Lockout\n4.View EvenEvent Log\n5.Exit Application");
        }
        public void ReadTheLog()
        {
            string logEntries = FileOperation.ReadTheLog();
            Console.WriteLine($"Logged Data : \n{logEntries}");
        }
    }
}
