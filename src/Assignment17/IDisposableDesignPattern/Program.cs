namespace IDisposableDesignPattern
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            InsertData = 1,
            AddTextToFile = 2,
            ClearList = 3,
            CloseTheFile = 4,
            Exit = 5,
        }

        /// <summary>
        /// It will asks the user to managed or unmanaged resources based on list or file
        /// </summary>
        /// <param name="args">It is string array of the main method</param>
        public static void Main(string[] args)
        {
            ManagedResources managedResources = new ManagedResources();
            UnmanagedResources unmanagedResources = new UnmanagedResources("hello.txt");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Welcome Resource Management of C#");
                Console.Write("Enter the choice \n\n1 - Insert the data into list, 2 - Add text into the file, 3 - Clear Data in List, 4 - Close the file, 5 - Exit : ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    Options options = (Options)result;
                    switch (options)
                    {
                        case Options.InsertData:
                            AddData(managedResources);
                            break;
                        case Options.AddTextToFile:
                            AddTextToFile(unmanagedResources);
                            break;
                        case Options.ClearList:
                            managedResources.ClearData();
                            break;
                        case Options.CloseTheFile:
                            unmanagedResources.CloseFile();
                            break;
                        case Options.Exit:
                            flag = false;
                            Console.WriteLine("\nExiting...");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Option - Enter correct option");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid Input");
                }

                Console.WriteLine("\nPress any key to continue : ");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        /// <summary>
        /// Add the data into the data list and visualize the data in the list
        /// </summary>
        /// <param name="managedResources">Reference of the managed resources object</param>
        public static void AddData(ManagedResources managedResources)
        {
            string userData;
            Console.Write("\nEnter the Data to be added : ");
            userData = Console.ReadLine();
            if (!string.IsNullOrEmpty(userData))
            {
                managedResources.AddData(userData);
                Console.WriteLine("\nDo you want to visualize the data press escape or enter to continue.");
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                if (consoleKey == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nData Present is : ");
                    managedResources.DataList.ForEach(x => { Console.Write($"{x}, "); });
                }
                else if (consoleKey == ConsoleKey.Enter)
                {
                    Console.WriteLine("\nGoing to Menu...");
                }
                else
                {
                    Console.WriteLine("\nInvalid Key.., Going to Menu");
                }
            }
            else
            {
                Console.WriteLine("\nData is empty. Please add some values to it.");
            }
        }

        /// <summary>
        /// Add the data into the file and checks for the empty string
        /// </summary>
        /// <param name="unmanagedResources">Reference of the unmanaged resources object</param>
        public static void AddTextToFile(UnmanagedResources unmanagedResources)
        {
            string userData;
            Console.Write("\nEnter the Data to be added : ");
            userData = Console.ReadLine();
            if (!string.IsNullOrEmpty(userData))
            {
                unmanagedResources.WriteToTheFile(userData);
            }
            else
            {
                Console.WriteLine("\nData is empty. Please add some values to it.");
            }
        }
    }
}