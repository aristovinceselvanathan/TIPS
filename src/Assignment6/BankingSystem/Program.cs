namespace BankingSystem
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            SavingsAccount = 1,
            CheckingAccount = 2,
            Exit = 3,
        }

        /// <summary>
        /// Main method it takes the account number, balance, type and ask to withdraw the amount.
        /// </summary>
        /// <param name="args">It takes the argument from command line Interface<</param>
        public static void Main(string[] args)
        {
            string isValidAccountNumber, accountNumber;
            decimal balance;
            bool flag = true;

            Console.WriteLine("Welcome to XYZ Bank");

            while (flag)
            {
                Console.WriteLine("Did You want to create the 1. Savings Account, 2. Checking Account 3.Exit: ");
                if (int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 3)
                {
                    Console.WriteLine("Account Number : ");
                    isValidAccountNumber = Console.ReadLine();

                    if (IsAccountNumberValid(isValidAccountNumber))
                    {
                        Console.WriteLine("Account Balance : ");
                        if (decimal.TryParse(Console.ReadLine(), out balance))
                        {
                            accountNumber = isValidAccountNumber;
                            Options options = (Options)option;
                            switch (options)
                            {
                                case Options.SavingsAccount:
                                    SavingsAccount savingsAccount = new SavingsAccount(accountNumber, balance);
                                    Services(savingsAccount);
                                    break;
                                case Options.CheckingAccount:
                                    CheckingAccount checkingAccount = new CheckingAccount(accountNumber, balance);
                                    Services(checkingAccount);
                                    break;
                                case Options.Exit:
                                    Console.WriteLine("Exiting...");
                                    flag = false;
                                    break;
                                default:
                                    WarningMessageFromConsole("Enter only the above options!!");
                                    break;
                            }
                        }
                        else
                        {
                            WarningMessageFromConsole("Balance");
                        }
                    }
                    else
                    {
                        WarningMessageFromConsole("Account Number");
                    }
                }
                else
                {
                    WarningMessageFromConsole("Option");
                }
            }
        }

        /// <summary>
        /// This function performs the deposit and withdraw function
        /// </summary>
        /// <param name="user">user is reference of the bank account class can have both the child class</param>
        public static void Services(BankAccount user)
        {
            bool flag = true;

            while (flag)
            {
                user.PrintDetailsOfAccount();
                Console.WriteLine("Did you want to 1.Withdraw 2.Deposit 3.Exit: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("How much amount want to withdraw:");
                            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                            {
                                if (amount > 0)
                                {
                                    user.Withdraw(amount);
                                }
                                else
                                {
                                    Console.WriteLine("Enter a Valid Amount");
                                }
                            }
                            else
                            {
                                WarningMessageFromConsole("Balance");
                            }

                            break;

                        case 2:
                            Console.WriteLine("How mush amount want to deposit: ");
                            if (decimal.TryParse(Console.ReadLine(), out amount))
                            {
                                if (amount > 0)
                                {
                                    user.Deposit(amount);
                                }
                                else
                                {
                                    Console.WriteLine("Enter a Valid Amount");
                                }
                            }
                            else
                            {
                                WarningMessageFromConsole("Balance");
                            }

                            break;
                        case 3:
                            flag = false;
                            Console.WriteLine("Exiting....");
                            break;
                        default:
                            WarningMessageFromConsole("Option");
                            break;
                    }
                }
                else
                {
                    WarningMessageFromConsole("Input");
                }

                Console.WriteLine("Press any to Continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Method checks for the string is number or not because account number consists of numbers
        /// </summary>
        /// <param name="accountNumber">It takes the account number and evaluates contains only numbers</param>
        /// <returns>It returns bool</returns>
        public static bool IsAccountNumberValid(string accountNumber)
        {
            Regex r = new Regex("^\\d*$");

            if (r.IsMatch(accountNumber))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// It shows the colourful warning message of the invalid input
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the input</param>
        public static void WarningMessageFromConsole(string nameOfInput)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Invalid {nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
