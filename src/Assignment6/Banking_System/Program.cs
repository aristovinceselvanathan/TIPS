namespace Banking_System
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method it takes the account number, balance, type and ask to withdraw the amount.
        /// </summary>
        /// <param name="args">It takes the argument from command line Interface<</param>
        public static void Main(string[] args)
        {
            string isValidAccountNumber, isValidBalance, accountNumber;
            decimal balance;

            Console.WriteLine("Account Number : ");
            isValidAccountNumber = Console.ReadLine();
            if (IsNumberValid(isValidAccountNumber))
            {
                Console.WriteLine("Account Balance : ");
                isValidBalance = Console.ReadLine();

                if (decimal.TryParse(isValidBalance, out balance))
                {
                    accountNumber = isValidAccountNumber;
                    Console.WriteLine("Did You want to create the 1. Savings Account or 2. Checking Account : ");
                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                SavingsAccount savingsAccount = new SavingsAccount(accountNumber, balance);
                                Services(savingsAccount);
                                break;
                            case 2:
                                CheckingAccount checkingAccount = new CheckingAccount(accountNumber, balance);
                                Services(checkingAccount);
                                break;
                            default:
                                InvalidWarning("Option");
                                break;
                        }
                    }
                    else
                    {
                        InvalidWarning("Input");
                    }
                }
                else
                {
                    InvalidWarning("Balance");
                }
            }
            else
            {
                InvalidWarning("Account Number");
            }
        }

        /// <summary>
        /// This function performs the deposit and withdraw function
        /// </summary>
        /// <param name="user">Object of the child class</param>
        public static void Services(BankAccount user)
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine($"Account Number : {user.AccountNumber}");
                Console.WriteLine($"Balance : {user.Balance}");
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
                                InvalidWarning("Balance");
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
                                InvalidWarning("Balance");
                            }

                            break;
                        case 3:
                            flag = false;
                            Console.WriteLine("Exiting....");
                            break;
                        default:
                            InvalidWarning("Option");
                            break;
                    }
                }
                else
                {
                    InvalidWarning("Input");
                }

                Console.WriteLine("Press any to Continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Method checks for the string is number or not because account number consists of numbers
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsNumberValid(string s)
        {
            Regex r = new Regex("^\\d*$");

            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// It shows the clourful warning message of the invalid input
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the input</param>
        public static void InvalidWarning(string nameOfInput)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Invalid {nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
