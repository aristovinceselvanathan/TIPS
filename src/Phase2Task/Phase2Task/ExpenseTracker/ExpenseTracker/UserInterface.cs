using System;
using System.Text.RegularExpressions;
using ConsoleTables;

namespace ExpenseTracker
{
    /// <summary>
    /// UserInterface Class
    /// </summary>
    public class UserInterface
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
        /// To start the user interface
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
                int userEnteredChoice = GetTheIntegerInput("Choice");
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
        /// To Load the data from the file
        /// </summary>
        public void LoadFromTheFile()
        {
            List<Expense> expenseTemp = _fileOperationExpense.LoadFromTheFile("expense");
            List<Income> incomeTemp = _fileOperationIncome.LoadFromTheFile("income");

            if (expenseTemp != null)
            {
                _expenses = expenseTemp;
                _fileOperationIncome.LogToTheFile(_logFileName, "Successfully Fetched - Expenses.json");
            }

            if (incomeTemp != null)
            {
                _incomes = incomeTemp;
                _fileOperationIncome.LogToTheFile(_logFileName, "Successfully Fetched - Incomes.json");
            }
        }

        /// <summary>
        /// Process to be done when exiting the console application
        /// </summary>
        /// <param name="sender">sender object that invoke the method</param>
        /// <param name="e">EventArgs of the data to be given to t</param>
        public void CurrentDomain_ProcessExit_LoadToTheFile(object sender, EventArgs e)
        {
            _fileOperationExpense.LoadToTheFile("expense", _expenses);
            _fileOperationIncome.LoadToTheFile("income", _incomes);
            _fileOperationExpense.LogToTheFile(_logFileName, "Loaded to the files in the Load to the File");
        }

        /// <summary>
        /// To add the entry to expense or the income
        /// </summary>
        /// <param name="operationFunction">Reference to the function</param>
        public void ManipulateEntry(Predicate<int> operationFunction)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Add The Entry :\n\n1.Expense\n\n2.Income\n");
            int userSelectedOption = GetTheIntegerInput("Choice");
            TypeOfEntry typeOfEntry = (TypeOfEntry)userSelectedOption;

            switch (typeOfEntry)
            {
                case TypeOfEntry.Expenses:
                    if (_expenses.Count() != 0)
                    {
                        operationFunction(1);
                    }
                    else
                    {
                        Utility.PrintErrorMessage("Expense List is Empty");
                    }

                    break;
                case TypeOfEntry.Income:
                    if (_incomes.Count() != 0)
                    {
                        operationFunction(2);
                    }
                    else
                    {
                        Utility.PrintErrorMessage("Income List is Empty");
                    }

                    break;
                default:
                    Utility.PrintErrorMessage("Enter the valid option - Please enter the option 1 or 2");
                    _fileOperationIncome.LogToTheFile(_logFileName, "Enter the valid option - Please enter the option 1 or 2 in the Manipulate Entry");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Add the entry details into the expense or income
        /// </summary>
        /// <param name="typeOfEntry">Enum of the entry</param>
        /// <returns>status of the operation</returns>
        public bool AddTheEntry(int typeOfEntry)
        {
            Console.Clear();
            Console.WriteLine("Add the Required Details : \n");
            DateTime dateOfTheEntry = GetTheDateInput();
            int amount = GetTheIntegerInput("Amount");
            string description;

            switch (typeOfEntry)
            {
                case 1:
                    description = GetTheStringInput("Category");
                    _expenses.Add(new Expense(dateOfTheEntry, amount, description));
                    break;
                case 2:
                    description = GetTheStringInput("Source");
                    _incomes.Add(new Income(dateOfTheEntry, amount, description));
                    break;
                default:
                    Utility.PrintErrorMessage("Invalid Option - Please enter the valid number 1 or 2");
                    _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Option - Please enter the valid number 1 or 2 in the Add the Entry");
                    return false;
            }

            _expenses.Sort();
            _incomes.Sort();
            return true;
        }

        /// <summary>
        /// Remove the entry details into the expense or income
        /// </summary>
        /// <param name="typeOfEntry">Enum of the entry</param>
        /// <returns>status of the operation</returns>
        public bool RemoveTheEntry(int typeOfEntry)
        {
            Console.Clear();
            Console.WriteLine("Remove the Entry");

            if (PrintTheEntry(typeOfEntry))
            {
                int userEnteredChoice = GetTheIntegerInput("S.No");
                switch (typeOfEntry)
                {
                    case 1:
                        _expenses.RemoveAt(_expenses.IndexOf(_tempExpenses.ElementAt(userEnteredChoice)));
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

        /// <summary>
        /// Update the entry details into the expense or income
        /// </summary>
        /// <param name="typeOfEntry">Enum of the entry</param>
        /// <returns>status of the operation</returns>
        public bool UpdateTheEntry(int typeOfEntry)
        {
            Console.Clear();
            Console.WriteLine("Update the Entry");
            if (PrintTheEntry(typeOfEntry))
            {
                int userEnteredChoice = GetTheIntegerInput("S.No");
                switch (typeOfEntry)
                {
                    case 1:
                        GetTheUpdateDetails(1, _expenses.IndexOf(_tempExpenses.ElementAt(userEnteredChoice)));
                        break;
                    case 2:
                        GetTheUpdateDetails(2, _expenses.IndexOf(_tempExpenses.ElementAt(userEnteredChoice)));
                        break;
                    default:
                        Utility.PrintErrorMessage("Invalid Option - Please enter in choice 1 or 2");
                        _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Option - Please enter in choice 1 or 2 in the Update Entry");
                        return false;
                }

                Utility.PrintSuccessfulMessage("Updated Successfully\n");
                _fileOperationExpense.LogToTheFile(_logFileName, "Updated Successfully in the Update");
                return true;
            }
            else
            {
                Utility.PrintErrorMessage("List is empty\n");
                _fileOperationIncome.LogToTheFile(_logFileName, "List is Empty in the Update Entry");
            }
            return false;
        }

        /// <summary>
        /// Get the details for the update
        /// </summary>
        /// <param name="typeOfTheEntry">Type of the list is accessed</param>
        /// <param name="indexValue">Index of the entry to be changed</param>
        public void GetTheUpdateDetails(int typeOfTheEntry, int indexValue)
        {
            bool flag = true;
            while (flag)
            {
                Console.Write("1.Change the Date\n2.Change the Amount\n3.Change the Category\n");
                int userEnteredChoice = GetTheIntegerInput("Choice");
                Property property = (Property)userEnteredChoice;
                switch (property)
                {
                    case Property.DateOfEntry:
                        if (typeOfTheEntry == 1)
                        {
                            _expenses.ElementAt(indexValue).EntryDate = GetTheDateInput();
                        }
                        else
                        {
                            _incomes.ElementAt(indexValue).EntryDate = GetTheDateInput();
                        }

                        break;
                    case Property.Amount:
                        if (typeOfTheEntry == 1)
                        {
                            _expenses.ElementAt(indexValue).Amount = GetTheIntegerInput("Amount");
                        }
                        else
                        {
                            _incomes.ElementAt(indexValue).Amount = GetTheIntegerInput("Amount");
                        }

                        break;
                    case Property.Description:
                        if (typeOfTheEntry == 1)
                        {
                            _expenses.ElementAt(indexValue).Category = GetTheStringInput("Category");
                        }
                        else
                        {
                            _incomes.ElementAt(indexValue).Source = GetTheStringInput("Source");
                        }

                        break;
                }

                Console.WriteLine("Did you want to change any other entity ? 1 - Yes, 2 - No");
                int userChoice = GetTheIntegerInput("Choice");
                if (userChoice == 2)
                {
                    flag = false;
                }
            }
        }

        /// <summary>
        /// Print the details of the entry
        /// </summary>
        /// <param name="typeOfEntry">type of the entry to be viewed</param>
        /// <returns>Details are present or not</returns>
        public bool PrintTheEntry(int typeOfEntry)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int index = 0;
            int totalExpense = 0, totalIncome = 0;
            Tuple<DateTime, DateTime> dates = Filter(typeOfEntry, _tempExpenses, _tempIncomes);
            Console.WriteLine("Details of the Transactions : \n");
            ConsoleTable consoleTable = new ConsoleTable("S.No", "Date", "Spend", "Earn", "Source/Category");
            switch (typeOfEntry)
            {
                case 1:
                    _tempExpenses.ForEach(x =>
                    {
                        consoleTable.AddRow(index++, x.EntryDate, x.Amount, null, x.Category);
                        totalExpense += x.Amount;
                    });
                    break;
                case 2:
                    _tempIncomes.ForEach(x =>
                    {
                        consoleTable.AddRow(index++, x.EntryDate, null, x.Amount, x.Source);
                        totalIncome += x.Amount;
                    });
                    break;
                case 3:
                    PrintTheBothDetails(consoleTable, totalExpense, totalIncome, dates.Item1, dates.Item2);
                    break;
            }

            if (consoleTable.Rows.Count != 0 && typeOfEntry != 3)
            {
                consoleTable.Write(Format.MarkDown);
                Console.WriteLine($"Total Expense : {totalExpense}");
                Console.WriteLine($"Total Income : {totalIncome}");
                Console.WriteLine($"Total Balance: {totalIncome - totalExpense}\n");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        /// <summary>
        /// Print the both the expenses and income simultaneously
        /// </summary>
        /// <param name="consoleTable">ConsoleTable to print in table</param>
        /// <param name="totalExpense">Total expense of the range</param>
        /// <param name="totalIncome">Total income of the range</param>
        /// <param name="startDate">Start of the Date of the filter</param>
        /// <param name="endDate">End of the Date of the filter</param>
        public void PrintTheBothDetails(ConsoleTable consoleTable, int totalExpense, int totalIncome, DateTime startDate, DateTime endDate)
        {
            int expenseIndex = 0, incomeIndex = 0, index = 0;
            Expense currentExpense = null;
            Income currentIncome = null;
            if (expenseIndex < _expenses.Count())
            {
                currentExpense = _expenses.ElementAt(expenseIndex);
            }

            if (incomeIndex < _incomes.Count())
            {
                currentIncome = _incomes.ElementAt(incomeIndex);
            }

            if (_expenses.Count >= 1 && _incomes.Count >= 1)
            {
                for (int i = 0; i < (_expenses.Count() + _incomes.Count()); i++)
                {
                    if (currentExpense.EntryDate <= currentIncome.EntryDate && (incomeIndex < _incomes.Count && expenseIndex < _expenses.Count) && (currentExpense.EntryDate >= startDate && currentExpense.EntryDate <= endDate))
                    {
                        consoleTable.AddRow(i, currentExpense.EntryDate.Date, currentExpense.Amount, null, currentExpense.Category);
                        totalExpense += currentExpense.Amount;
                        expenseIndex++;
                    }
                    else if (currentIncome.EntryDate <= currentExpense.EntryDate && (incomeIndex < _incomes.Count && expenseIndex < _expenses.Count) && (currentIncome.EntryDate >= startDate && currentIncome.EntryDate <= endDate))
                    {
                        consoleTable.AddRow(i, currentIncome.EntryDate.Date, null, currentIncome.Amount, currentIncome.Source);
                        totalIncome += currentIncome.Amount;
                        incomeIndex++;
                    }
                    else if (expenseIndex >= _expenses.Count && incomeIndex < _incomes.Count && (currentIncome.EntryDate >= startDate && currentIncome.EntryDate <= endDate))
                    {
                        consoleTable.AddRow(i, currentIncome.EntryDate.Date, null, currentIncome.Amount, currentIncome.Source);
                        totalIncome += currentIncome.Amount;
                        incomeIndex++;
                    }
                    else if (incomeIndex >= _incomes.Count && expenseIndex < _expenses.Count && (currentExpense.EntryDate >= startDate && currentExpense.EntryDate <= endDate))
                    {
                        consoleTable.AddRow(i, currentExpense.EntryDate.Date, currentExpense.Amount, null, currentExpense.Category);
                        totalExpense += currentExpense.Amount;
                        expenseIndex++;
                    }
                }
            }
            else if (currentExpense != null && _expenses.Count >= 1 && (currentExpense.EntryDate >= startDate && currentExpense.EntryDate <= endDate))
            {
                _expenses.ForEach(x =>
                {
                    consoleTable.AddRow(index++, x.EntryDate.Date, x.Amount, null, x.Category);
                    totalExpense += x.Amount;
                });
            }
            else if (currentIncome != null && _incomes.Count >= 1 && (currentIncome.EntryDate >= startDate && currentIncome.EntryDate <= endDate))
            {
                _incomes.ForEach(x =>
                {
                    consoleTable.AddRow(index++, x.EntryDate.Date, null, x.Amount, x.Source);
                    totalIncome += x.Amount;
                });
            }

            if (consoleTable.Rows.Count != 0)
            {
                consoleTable.Write(Format.MarkDown);
                Console.WriteLine($"Total Expense : {totalExpense}");
                Console.WriteLine($"Total Income : {totalIncome}");
                Console.WriteLine($"Total Balance: {totalIncome - totalExpense}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Perform the filter operation
        /// </summary>
        /// <param name="typeOfEntry">type of the entry to select</param>
        /// <param name="expenses">Entries of the expenses</param>
        /// <param name="incomes">Entries of the incomes</param>
        /// <returns>startDate and endDate of the filter</returns>
        public Tuple<DateTime, DateTime> Filter(int typeOfEntry, List<Expense> expenses, List<Income> incomes)
        {
            DateTime startDate = DateTime.MinValue.Date, endDate = DateTime.MaxValue.Date;
            Console.Clear();
            Console.WriteLine("Filter the Entries : \n");
            Console.WriteLine("1 - Filter by Date Range\n2 - Filter by Category\n3 - Filter by Amount\n4 - No Filter\n");
            int userEnteredNumber = GetTheIntegerInput("Choice");
            if (userEnteredNumber == 1)
            {
                Console.WriteLine("Enter the Start Date\n");
                startDate = GetTheDateInput();
                Console.WriteLine("\nEnter the End Date\n");
                endDate = GetTheDateInput();
                if (typeOfEntry == 1)
                {
                    _tempExpenses = _expenses.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToList();
                }
                else if (typeOfEntry == 2)
                {
                    _tempIncomes = _incomes.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToList();
                }
            }
            else if (userEnteredNumber == 2)
            {
                string userEnteredInput = GetTheStringInput("Category / Source");
                if (typeOfEntry == 1)
                {
                    _tempExpenses = _expenses.Where(x => string.Compare(userEnteredInput, x.Category, StringComparison.InvariantCultureIgnoreCase) == 0).ToList();
                }
                else if (typeOfEntry == 2)
                {
                    _tempIncomes = _incomes.Where(x => string.Compare(userEnteredInput, x.Source, StringComparison.InvariantCultureIgnoreCase) == 0).ToList();
                }
            }
            else if (userEnteredNumber == 3)
            {
                int startAmount = GetTheIntegerInput("Start Amount");
                int endAmount = GetTheIntegerInput("End Amount");
                if (typeOfEntry == 1)
                {
                    _tempExpenses = _expenses.Where(x => x.Amount >= startAmount && x.Amount <= endAmount).ToList();
                }
                else if (typeOfEntry == 2)
                {
                    _tempIncomes = _incomes.Where(x => x.Amount >= startAmount && x.Amount <= endAmount).ToList();
                }
            }
            else if (userEnteredNumber == 4)
            {
                Console.WriteLine("No Filter is applied\n");
                if (typeOfEntry == 1)
                {
                    _tempExpenses = _expenses;
                }
                else if (typeOfEntry == 2)
                {
                    _tempIncomes = _incomes;
                }

                _fileOperationExpense.LogToTheFile(_logFileName, "No Filter is applied in the Filter");
            }
            else
            {
                Utility.PrintErrorMessage("Invalid Choice - Please enter the valid choice 1 or 2");
                _fileOperationExpense.LogToTheFile(_logFileName, "Invalid Choice - Please enter the valid choice 1 or 2 in the Filter");
            }

            return Tuple.Create(startDate, endDate);
        }

        /// <summary>
        /// Get the string input from the user
        /// </summary>
        /// <param name="entityName">Name of the entity</param>
        /// <returns>string entered by the user</returns>
        public string GetTheStringInput(string entityName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Regex regex = new Regex("^[A-Za-z0-9]+$");
            Console.Write($"Enter the {entityName} : ");
            string userEnteredInput = Console.ReadLine();
            Console.WriteLine();
            if (regex.IsMatch(userEnteredInput))
            {
                return userEnteredInput;
            }
            else if (string.Compare(userEnteredInput, "end", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                StartUserInterface(0);
            }

            Utility.PrintErrorMessage("Invalid Input - Please enter the valid characters");
            _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Input - Please enter the valid characters in the GetTheStringInput");
            return GetTheStringInput(entityName);
        }

        /// <summary>
        /// Get the integer input from the user
        /// </summary>
        /// <param name="entityName">Name of the entity</param>
        /// <returns>string entered by the user</returns>
        public int GetTheIntegerInput(string entityName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Enter the {entityName} : ");
            string userEnteredInput = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(userEnteredInput, out int userEnteredValue))
            {
                return userEnteredValue;
            }
            else if (string.Compare(userEnteredInput, "end", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                StartUserInterface(0);
            }

            Utility.PrintErrorMessage("Invalid Input - Please enter the valid integers");
            _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Input - Please enter the valid integers in the GetTheIntegerInput");
            return GetTheIntegerInput(entityName);
        }

        /// <summary>
        /// Get the integer input from the user
        /// </summary>
        /// <returns>string entered by the user</returns>
        public DateTime GetTheDateInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Regex regex = new Regex("^(0[1-9]|[12][0-9]|3[01])(-|/).(0[1-9]|1[012])(-|/).\\d{4}$");
            Console.WriteLine("Can I use the current date ? 1 - Yes, 2 - No");
            int userEnteredNumber = GetTheIntegerInput("Choice");
            if (userEnteredNumber == 1)
            {
                return DateTime.Now.Date;
            }
            else if (userEnteredNumber == 2)
            {
                Console.Write($"Enter the Date(DD-MM-YYYY) : ");
                string userEnteredInput = Console.ReadLine();
                Console.WriteLine();
                if (regex.IsMatch(userEnteredInput))
                {
                    return DateTime.ParseExact(userEnteredInput, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                else if (string.Compare(userEnteredInput, "end", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    StartUserInterface(0);
                }
            }
            else
            {
                Utility.PrintErrorMessage("Enter the valid option - Please enter the option 1 or 2");
                _fileOperationIncome.LogToTheFile(_logFileName, "Enter the valid option - Please enter the option 1 or 2 in the GetTheDateInput");
            }

            Console.WriteLine();
            Utility.PrintErrorMessage("Invalid Input - Please enter the valid date of format (dd-mm-yyyy)");
            _fileOperationIncome.LogToTheFile(_logFileName, "Invalid Input - Please enter the valid date of format (dd-mm-yyyy) in the GetTheDateInput");
            return GetTheDateInput();
        }
    }
}
