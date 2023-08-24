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
            string m1, m2, number;
            decimal balance;
            SavingsAccount savingsacc;
            CheckingAccount checkingacc;

            Console.WriteLine("Account Number : ");
            m1 = ChecksStringIsNull(Console.ReadLine());
            Console.WriteLine("Account Balance : ");
            m2 = ChecksStringIsNull(Console.ReadLine());

            if (IsNumber(m1) && decimal.TryParse(m2, out balance))
            {
                number = m1;
                Console.WriteLine("Did You want to create the 1. Savings Account or 2. Checking Account : ");
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid Input");
                }

                switch (option)
                {
                    case 1:
                        savingsacc = new SavingsAccount(number, balance);
                        Services(savingsacc);
                        break;
                    case 2:
                        checkingacc = new CheckingAccount(number, balance);
                        Services(checkingacc);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
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
                int.TryParse(Console.ReadLine(), out int option);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("How much amount want to withdraw:");
                        decimal.TryParse(Console.ReadLine(), out decimal amount);

                        if (amount > 0)
                        {
                           user.Withdraw(amount);
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid Amount");
                        }

                        break;

                    case 2:
                        Console.WriteLine("How mush amount want to deposit: ");
                        decimal.TryParse(Console.ReadLine(), out amount);

                        if (amount > 0)
                        {
                            user.Deposit(amount);
                        }
                        else
                        {
                            Console.WriteLine("Enter a Valid Amount");
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

                Console.WriteLine("Press any key to continue : ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Method checks string is null
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns string</returns>
        public static string ChecksStringIsNull(string? s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return " ";
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// Method checks for the string is number or not because account number consists of numbers
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsNumber(string s)
        {
            Regex r = new Regex("^\\d+$");

            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
