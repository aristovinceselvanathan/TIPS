namespace BoilerController
{
    internal class Program
    {
        private enum Options
        {
            ToggleInterLock = 1,
            ResetLock,
            StartTheOperation,
            ViewEventLogs,
            Exit,
        }
        static void Main(string[] args)
        {
            bool flag = true;
            using (Boiler boiler = new Boiler())
            {
                while (flag)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Boiler State : {boiler.currentBoilerStatus}\nInterLock State : {boiler.currentInterLockStatus.InterLockSwitch}     Reset Lock : {boiler.resetLock}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("1.Toggle The InterLock\n2.Trigger the ResetLock\n3.Start The Sequence\n4.View Event Logs\n5.Exit\n");
                    Options userEnteredOptions = (Options)Utility.GetTheIntegerInput("Choice");
                    switch (userEnteredOptions)
                    {
                        case Options.ToggleInterLock:
                            boiler.SwitchInterLock();
                            break;
                        case Options.ResetLock:
                            boiler.ResetLock();
                            break;
                        case Options.StartTheOperation:
                            boiler.StartTheSequence();
                            break;
                        case Options.ViewEventLogs:
                            Console.WriteLine("Log Entries : ");
                            Console.WriteLine(FileOperation.LogFromTheFile());
                            break;
                        case Options.Exit:
                            flag = false;
                            FileOperation.LogToTheFile("Exiting...");
                            break;
                        default:
                            FileOperation.LogToTheFile("Invalid Option - Please Enter the options from 1 to 4", true);
                            break;
                    }
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
    }
}