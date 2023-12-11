namespace ExpenseTracker
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private static UserInterface _userInterface = new UserInterface();

        /// <summary>
        /// To Run the user interface
        /// </summary>
        /// <param name="args">It is string array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(_userInterface.CurrentDomain_ProcessExit_LoadToTheFile);
            bool flag = true;
            while (flag)
            {
                FileOperation<Expense> fileOperation = new FileOperation<Expense>();
                Console.WriteLine("Login Credentials\n");
                string username = Utility.GetTheStringInput("Username", _userInterface);
                string password = Utility.GetTheStringInput("Password", _userInterface);
                if (username.Equals("Admin") && password.Equals("Admin123"))
                {
                    fileOperation.LogToTheFile("log", "Login SuccessFull");
                    _userInterface.StartUserInterface();
                }
                else
                {
                    Console.WriteLine("Invalid Username or Password\n");
                    fileOperation.LogToTheFile("log", "Invalid Username or Password");
                }

                Console.WriteLine("Enter the escape key to exit or any key to continue");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    flag = false;
                    Console.WriteLine("Exiting...");
                }

                Console.Clear();
            }
        }
    }
}