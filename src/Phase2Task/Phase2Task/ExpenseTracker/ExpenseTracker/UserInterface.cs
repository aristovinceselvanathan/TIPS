using System;
using System.Text.RegularExpressions;
using ConsoleTables;

namespace ExpenseTracker
{
    /// <summary>
    /// UserInterface Class.
    /// </summary>
    public partial class UserInterface
    {
        private FileOperation<Expense> _fileOperationExpense = new FileOperation<Expense>();
        private FileOperation<Income> _fileOperationIncome = new FileOperation<Income>();
        private List<Expense> _expenses = new List<Expense>();
        private List<Income> _incomes = new List<Income>();
        private string _logFileName = "log";
        private List<Expense> _tempExpenses = new List<Expense>();
        private List<Income> _tempIncomes = new List<Income>();

        private enum TypeOfEntry
        {
            Expenses = 1,
            Income,
        }

        private enum Options
        {
            AddTheEntry = 1,
            RemoveTheEntry,
            UpdateTheEntry,
            DisplayTheEntry,
            Exit,
        }

        private enum Property
        {
            DateOfEntry = 1,
            Amount,
            Description,
        }

        /// <summary>
        /// Gets the Expenses.
        /// </summary>
        /// <value>
        /// Expenses
        /// </value>
        public List<Expense> Expenses { get => _expenses; }

        /// <summary>
        /// Gets the Incomes.
        /// </summary>
        /// <value>
        /// Incomes
        /// </value>
        public List<Income> Incomes { get => _incomes; }

        /// <summary>
        /// To start the user interface.
        /// </summary>
        /// <param name="operationToBePerformed">To select the operation to be performed</param>
        public void StartUserInterface(int operationToBePerformed = 1)
        {
            bool flag = true;
            if (operationToBePerformed == 1)
            {
                Utility.PrintSuccessfulMessage("Login Successful\n");
                LoadFromTheFile();
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }

            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Welcome to Expense Tracker\n");
                Console.Clear();
                Console.WriteLine("Menu\n\n1 - Add The Entry\n2 - Remove The Entry\n3 - Update the Entry\n4 - Display the Entries\n5 - Exit" +
                    "\n\nType end in the field to return to main menu\n");
                int userEnteredChoice = Utility.GetTheIntegerInput("Choice");
                Options options = (Options)userEnteredChoice;

                switch (options)
                {
                    case Options.AddTheEntry:
                        Console.Clear();
                        ManipulateEntry(AddTheEntry);
                        break;
                    case Options.RemoveTheEntry:
                        Console.Clear();
                        ManipulateEntry(RemoveTheEntry);
                        break;
                    case Options.UpdateTheEntry:
                        Console.Clear();
                        ManipulateEntry(UpdateTheEntry);
                        break;
                    case Options.DisplayTheEntry:
                        Console.Clear();
                        PrintTheEntry(3);
                        break;
                    case Options.Exit:
                        Utility.PrintSuccessfulMessage("Exiting...\n");
                        _fileOperationIncome.LogToTheFile(_logFileName, "Exited the Application");
                        _fileOperationExpense.LogToTheFile("log", $"Successfully loaded to the files");
                        LoadToTheFile();
                        flag = false;
                        break;
                    default:
                        Utility.PrintErrorMessage("Invalid Choice - Please enter the choice in range between 1 to 6");
                        _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Choice - Please enter the choice in range between 1 to 6");
                        break;
                }

                if (flag == false)
                {
                    System.Environment.Exit(0);
                }

                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Process to be done when exiting the console application
        /// </summary>
        public void LoadToTheFile()
        {
            _fileOperationExpense.LoadToTheFile("expense", _expenses);
            _fileOperationIncome.LoadToTheFile("income", _incomes);
            _fileOperationExpense.LogToTheFile(_logFileName, "Loaded to the files in the Load to the File");
        }

        /// <summary>
        /// To add the entry to expense or the income.
        /// </summary>
        /// <param name="operationFunction">Reference to the function</param>
        public void ManipulateEntry(Predicate<int> operationFunction)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Add The Entry :\n\n1.Expense\n\n2.Income\n");
            int userSelectedOption = Utility.GetTheIntegerInput("Choice");
            TypeOfEntry typeOfEntry = (TypeOfEntry)userSelectedOption;

            switch (typeOfEntry)
            {
                case TypeOfEntry.Expenses:
                    operationFunction(1);
                    break;
                case TypeOfEntry.Income:
                    operationFunction(2);
                    break;
                default:
                    Utility.PrintErrorMessage("Enter the valid option - Please enter the option 1 or 2");
                    _fileOperationIncome.LogToTheFile(_logFileName, "Enter the valid option - Please enter the option 1 or 2 in the Manipulate Entry");
                    break;
            }
            Console.WriteLine("Operation Performed Successfully");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Add the entry details into the expense or income.
        /// </summary>
        /// <param name="typeOfEntry">Enum of the entry</param>
        /// <returns>status of the operation</returns>
        public bool AddTheEntry(int typeOfEntry)
        {
            Console.WriteLine("Add the Required Details : \n");
            DateTime dateOfTheEntry = Utility.GetTheDateInput();
            int amount = Utility.GetTheIntegerInput("Amount");
            string description;

            switch (typeOfEntry)
            {
                case 1:
                    description = Utility.GetTheStringInput("Category");
                    _expenses.Add(new Expense(dateOfTheEntry, amount, description));
                    break;
                case 2:
                    description = Utility.GetTheStringInput("Source");
                    _incomes.Add(new Income(dateOfTheEntry, amount, description));
                    break;
                default:
                    Utility.PrintErrorMessage("Invalid Option - Please enter the valid number 1 or 2");
                    _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Option - Please enter the valid number 1 or 2 in the Add the Entry");
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Remove the entry details into the expense or income.
        /// </summary>
        /// <param name="typeOfEntry">Enum of the entry</param>
        /// <returns>status of the operation</returns>
        public bool RemoveTheEntry(int typeOfEntry)
        {
            Console.Clear();
            Console.WriteLine("Remove the Entry");
            if (PrintTheEntry(typeOfEntry))
            {
                int userEnteredChoice = Utility.GetTheIntegerInput("S.No") - 1;
                switch (typeOfEntry)
                {
                    case 1:
                        _expenses.RemoveAt(_expenses.IndexOf(_tempExpenses.ElementAt(userEnteredChoice )));
                        break;
                    case 2:
                        _incomes.RemoveAt(_incomes.IndexOf(_incomes.ElementAt(userEnteredChoice)));
                        break;
                    default:
                        Utility.PrintErrorMessage("Invalid Option - Please enter in choice 1 or 2");
                        _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Option - Please enter in choice 1 or 2 in the remove the entry");
                        return false;
                }

                Utility.PrintSuccessfulMessage("Removed Successfully");
                _fileOperationExpense.LogToTheFile(_logFileName, "Removed Successfully in the Remove");
                return true;
            }
            else
            {
                Utility.PrintErrorMessage("List is Empty\n");
                _fileOperationIncome.LogToTheFile(_logFileName, "List is Empty in the Remove Entry");
            }
            return false;
        }
    }
}
