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
            bool flag = true;
            decimal balance, amount;
            SavingsAccount s1;
            CheckingAccount c1;

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
                        s1 = new SavingsAccount(number, balance);
                        while (flag)
                        {
                            Console.WriteLine($"Balance : {s1.Balance}");
                            Console.WriteLine("Did you want to 1.Withdraw or 2.Deposit 3.Exit: ");
                            int.TryParse(Console.ReadLine(), out option);
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("How much amount want to withdraw:");
                                    if (!decimal.TryParse(Console.ReadLine(), out amount))
                                    {
                                        Console.WriteLine("Invalid Input");
                                    }
                                    else
                                    {
                                        s1.Withdraw(amount);
                                    }

                                    break;

                                case 2:
                                    Console.WriteLine("How mush amount want to deposit: ");
                                    if (!decimal.TryParse(Console.ReadLine(), out amount))
                                    {
                                        Console.WriteLine("Invalid Input");
                                    }
                                    else
                                    {
                                        s1.Withdraw(amount);
                                    }

                                    s1.Deposit(amount);
                                    break;
                                case 3:
                                    flag = false;
                                    Console.WriteLine("Exiting.....");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Option");
                                    break;
                            }
                        }

                        break;
                    case 2:
                        c1 = new CheckingAccount(number, balance);
                        while (flag)
                        {
                            Console.WriteLine($"Balance : {c1.Balance}");
                            Console.WriteLine("Did you want to 1.Withdraw or 2.Deposit 3.Exit: ");
                            int.TryParse(Console.ReadLine(), out option);
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("How much amount want to withdraw:");
                                    decimal.TryParse(Console.ReadLine(), out amount);
                                    c1.Withdraw(amount);
                                    break;

                                case 2:
                                    Console.WriteLine("How mush amount want to deposit: ");
                                    decimal.TryParse(Console.ReadLine(), out amount);
                                    c1.Deposit(amount);
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
            Regex r = new Regex("\\d+");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
