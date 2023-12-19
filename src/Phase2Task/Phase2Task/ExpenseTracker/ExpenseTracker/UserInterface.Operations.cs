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
        /// <summary>
        /// To Load the data from the file.
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
        /// Print the both the expenses and income simultaneously.
        /// </summary>
        /// <param name="consoleTable">ConsoleTable to print in table</param>
        /// <param name="expenses">List of the expenses</param>
        /// <param name="incomes">List of the incomes</param>
        /// <param name="totalExpense">Total expense of the range</param>
        /// <param name="totalIncome">Total income of the range</param>
        /// <param name="startDate">Start of the Date of the filter</param>
        /// <param name="endDate">End of the Date of the filter</param>
        public void PrintTheBothDetails(ConsoleTable consoleTable, List<Expense> expenses, List<Income> incomes, int totalExpense, int totalIncome, DateTime startDate, DateTime endDate)
        {
            int expenseIndex = 0, incomeIndex = 0, index = 1;
            Expense currentExpense = null;
            Income currentIncome = null;
            if (expenseIndex < expenses.Count())
            {
                currentExpense = expenses.ElementAt(expenseIndex);
            }

            if (incomeIndex < incomes.Count())
            {
                currentIncome = incomes.ElementAt(incomeIndex);
            }

            if (expenses.Count >= 1 && incomes.Count >= 1)
            {
                for (int i = 0; i < (expenses.Count() + incomes.Count()); i++)
                {
                    if (currentExpense.EntryDate <= currentIncome.EntryDate && (incomeIndex < incomes.Count && expenseIndex < expenses.Count) && (currentExpense.EntryDate >= startDate && currentExpense.EntryDate <= endDate))
                    {
                        consoleTable.AddRow(i, currentExpense.EntryDate.Date, currentExpense.Amount, null, currentExpense.Category);
                        totalExpense += currentExpense.Amount;
                        expenseIndex++;
                    }
                    else if (currentIncome.EntryDate <= currentExpense.EntryDate && (incomeIndex < incomes.Count && expenseIndex < expenses.Count) && (currentIncome.EntryDate >= startDate && currentIncome.EntryDate <= endDate))
                    {
                        consoleTable.AddRow(i, currentIncome.EntryDate.Date, null, currentIncome.Amount, currentIncome.Source);
                        totalIncome += currentIncome.Amount;
                        incomeIndex++;
                    }
                    else if (expenseIndex >= expenses.Count && incomeIndex < incomes.Count && (currentIncome.EntryDate >= startDate && currentIncome.EntryDate <= endDate))
                    {
                        consoleTable.AddRow(i, currentIncome.EntryDate.Date, null, currentIncome.Amount, currentIncome.Source);
                        totalIncome += currentIncome.Amount;
                        incomeIndex++;
                    }
                    else if (incomeIndex >= incomes.Count && expenseIndex < expenses.Count && (currentExpense.EntryDate >= startDate && currentExpense.EntryDate <= endDate))
                    {
                        consoleTable.AddRow(i, currentExpense.EntryDate.Date, currentExpense.Amount, null, currentExpense.Category);
                        totalExpense += currentExpense.Amount;
                        expenseIndex++;
                    }
                }
            }
            else if (currentExpense != null && expenses.Count >= 1 && (currentExpense.EntryDate >= startDate && currentExpense.EntryDate <= endDate))
            {
                expenses.ForEach(x =>
                {
                    consoleTable.AddRow(index++, x.EntryDate.Date, x.Amount, null, x.Category);
                    totalExpense += x.Amount;
                });
            }
            else if (currentIncome != null && incomes.Count >= 1 && (currentIncome.EntryDate >= startDate && currentIncome.EntryDate <= endDate))
            {
                incomes.ForEach(x =>
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
        /// Perform the filter operation.
        /// </summary>
        /// <param name="typeOfEntry">type of the entry to select</param>
        /// <param name="expenses">Entries of the expenses</param>
        /// <param name="incomes">Entries of the incomes</param>
        /// <returns>startDate and endDate of the filter</returns>
        public Tuple<DateTime, DateTime, int> Filter(int typeOfEntry, List<Expense> expenses, List<Income> incomes)
        {
            DateTime startDate = DateTime.MinValue.Date, endDate = DateTime.MaxValue.Date;
            Console.WriteLine("Filter the Entries : \n");
            Console.WriteLine("1 - Filter by Date Range\n2 - Filter by Category\n3 - Filter by Amount\n4 - No Filter\n");
            int userEnteredNumber = Utility.GetTheIntegerInput("Choice");
            if (userEnteredNumber == 1)
            {
                Console.WriteLine("Enter the Start Date\n");
                startDate = Utility.GetTheDateInput();
                Console.WriteLine("\nEnter the End Date\n");
                endDate = Utility.GetTheDateInput();
                if (typeOfEntry == 1)
                {
                    _tempExpenses = _expenses.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToList();
                }
                else if (typeOfEntry == 2)
                {
                    _tempIncomes = _incomes.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToList();
                }
                else
                {
                    _tempExpenses = _expenses.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToList();
                    _tempIncomes = _incomes.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToList();
                }
            }
            else if (userEnteredNumber == 2)
            {
                string userEnteredInput = Utility.GetTheStringInput("Category / Source");
                if (typeOfEntry == 1)
                {
                    _tempExpenses = _expenses.Where(x => string.Compare(userEnteredInput, x.Category, StringComparison.InvariantCultureIgnoreCase) == 0).ToList();
                }
                else if (typeOfEntry == 2)
                {
                    _tempIncomes = _incomes.Where(x => string.Compare(userEnteredInput, x.Source, StringComparison.InvariantCultureIgnoreCase) == 0).ToList();
                }
                else
                {
                    _tempExpenses = _expenses.Where(x => string.Compare(userEnteredInput, x.Category, StringComparison.InvariantCultureIgnoreCase) == 0).ToList();
                    _tempIncomes = _incomes.Where(x => string.Compare(userEnteredInput, x.Source, StringComparison.InvariantCultureIgnoreCase) == 0).ToList();
                }
            }
            else if (userEnteredNumber == 3)
            {
                int startAmount = Utility.GetTheIntegerInput("Start Amount");
                int endAmount = Utility.GetTheIntegerInput("End Amount");
                if (typeOfEntry == 1)
                {
                    _tempExpenses = _expenses.Where(x => x.Amount >= startAmount && x.Amount <= endAmount).ToList();
                }
                else if (typeOfEntry == 2)
                {
                    _tempIncomes = _incomes.Where(x => x.Amount >= startAmount && x.Amount <= endAmount).ToList();
                }
                else
                {
                    _tempExpenses = _expenses.Where(x => x.Amount >= startAmount && x.Amount <= endAmount).ToList();
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
                else
                {
                    _tempExpenses = _expenses;
                    _tempIncomes = _incomes;
                }

                _fileOperationExpense.LogToTheFile(_logFileName, "No Filter is applied in the Filter");
            }
            else
            {
                Utility.PrintErrorMessage("Invalid Choice - Please enter the valid choice 1 or 2");
                _fileOperationExpense.LogToTheFile(_logFileName, "Invalid Choice - Please enter the valid choice 1 or 2 in the Filter");
            }

            return Tuple.Create(startDate, endDate, userEnteredNumber);
        }

        /// <summary>
        /// Print the details of the entry.
        /// </summary>
        /// <param name="typeOfEntry">type of the entry to be viewed</param>
        /// <returns>Details are present or not</returns>
        public bool PrintTheEntry(int typeOfEntry)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int index = 1;
            int totalExpense = 0, totalIncome = 0;
            Tuple<DateTime, DateTime, int> filterdatas = Filter(typeOfEntry, _tempExpenses, _tempIncomes);
            Console.WriteLine("Details of the Transactions : \n");
            ConsoleTable consoleTable = new ConsoleTable("S.No", "Date", "Spend", "Earn", "Source/Category");
            switch (typeOfEntry)
            {
                case 1:
                    if (_expenses.Count() != 0)
                    {
                        _tempExpenses.ForEach(x =>
                        {
                            consoleTable.AddRow(index++, x.EntryDate, x.Amount, null, x.Category);
                            totalExpense += x.Amount;
                        });
                    }
                    else
                    {
                        Console.WriteLine("Expense List is Empty");
                    }

                    break;
                case 2:
                    if (_incomes.Count() != 0)
                    {
                        _tempIncomes.ForEach(x =>
                        {
                            consoleTable.AddRow(index++, x.EntryDate, null, x.Amount, x.Source);
                            totalIncome += x.Amount;
                        });
                    }
                    else
                    {
                        Console.WriteLine("Income List is Empty");
                    }
                    break;
                case 3:
                    if (filterdatas.Item3 != 0)
                    {
                        PrintTheBothDetails(consoleTable, _tempExpenses, _tempIncomes, totalExpense, totalIncome, filterdatas.Item1, filterdatas.Item2);
                    }
                    else
                    {
                        PrintTheBothDetails(consoleTable, _expenses, _incomes, totalExpense, totalIncome, filterdatas.Item1, filterdatas.Item2);
                    }
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
        /// Update the entry details into the expense or income.
        /// </summary>
        /// <param name="typeOfEntry">Enum of the entry</param>
        /// <returns>status of the operation</returns>
        public bool UpdateTheEntry(int typeOfEntry)
        {
            Console.WriteLine("Update the Entry");
            if (PrintTheEntry(typeOfEntry))
            {
                int userEnteredChoice = Utility.GetTheIntegerInput("S.No") - 1;
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
        /// Get the details for the update.
        /// </summary>
        /// <param name="typeOfTheEntry">Type of the list is accessed</param>
        /// <param name="indexValue">Index of the entry to be changed</param>
        public void GetTheUpdateDetails(int typeOfTheEntry, int indexValue)
        {
            bool flag = true;
            while (flag)
            {
                Console.Write("1.Change the Date\n2.Change the Amount\n3.Change the Category\n");
                int userEnteredChoice = Utility.GetTheIntegerInput("Choice");
                Property property = (Property)userEnteredChoice;
                switch (property)
                {
                    case Property.DateOfEntry:
                        if (typeOfTheEntry == 1)
                        {
                            _expenses.ElementAt(indexValue).EntryDate = Utility.GetTheDateInput();
                        }
                        else
                        {
                            _incomes.ElementAt(indexValue).EntryDate = Utility.GetTheDateInput();
                        }

                        break;
                    case Property.Amount:
                        if (typeOfTheEntry == 1)
                        {
                            _expenses.ElementAt(indexValue).Amount = Utility.GetTheIntegerInput("Amount");
                        }
                        else
                        {
                            _incomes.ElementAt(indexValue).Amount = Utility.GetTheIntegerInput("Amount");
                        }

                        break;
                    case Property.Description:
                        if (typeOfTheEntry == 1)
                        {
                            _expenses.ElementAt(indexValue).Category = Utility.GetTheStringInput("Category");
                        }
                        else
                        {
                            _incomes.ElementAt(indexValue).Source = Utility.GetTheStringInput("Source");
                        }

                        break;
                }

                Console.WriteLine("Did you want to change any other entity ? 1 - Yes, 2 - No");
                int userChoice = Utility.GetTheIntegerInput("Choice");
                if (userChoice == 2)
                {
                    flag = false;
                }
            }
        }
    }
}