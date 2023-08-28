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
            string isNumber, isDecimal, number;
            decimal balance;
            SavingsAccount savingsaccount;
            CheckingAccount checkingaccout;

            Console.WriteLine("Account Number : ");
            isNumber = Console.ReadLine();
            if (IsNumber(isNumber))
            {
                Console.WriteLine("Account Balance : ");
                isDecimal = Console.ReadLine();

                if (decimal.TryParse(isDecimal, out balance))
                {
                    number = isNumber;
                    Console.WriteLine("Did You want to create the 1. Savings Account or 2. Checking Account : ");
                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                savingsaccount = new SavingsAccount(number, balance);
                                Services(savingsaccount);
                                break;
                            case 2:
                                checkingaccout = new CheckingAccount(number, balance);
                                Services(checkingaccout);
                                break;
                            default:
                                Console.WriteLine("Invalid Option");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Decimal Value");
                }
            }
            else
            {
                Console.WriteLine("Invalid Account Number");
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
                Console.WriteLine("Did you want to 1.Withdraw or 2.Deposit 3.Exit: ");
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
                                Console.WriteLine("Invalid Decimal Value");
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
                                Console.WriteLine("Invalid Decimal Value");
                            }

                            break;
                        case 3:
                            flag = false;
                            Console.WriteLine("Exiting....");
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

                Console.WriteLine("Press any key to continue : ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Method checks for the string is number or not because account number consists of numbers
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsNumber(string s)
        {
            Regex r = new Regex("^\\d*$");

            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
