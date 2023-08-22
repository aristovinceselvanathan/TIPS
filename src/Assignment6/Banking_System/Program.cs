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
            string x, m1, m2, number;
            decimal balance, amt;
            SavingsAccount s1;
            CheckingAccount c1;

            Console.WriteLine("Account Number : ");
            m1 = NullException(Console.ReadLine());
            Console.WriteLine("Account Balance : ");
            m2 = NullException(Console.ReadLine());

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
                        Console.WriteLine("Did you want to withdraw : Y or N");
                        x = NullException(Console.ReadLine());
                        if (x.Equals("Y") || x.Equals("y"))
                        {
                            Console.WriteLine("How much amount want to withdraw?");
                            decimal.TryParse(Console.ReadLine(), out amt);
                            s1.Withdraw(amt);
                        }
                        else if (x.Equals("N") || x.Equals("n"))
                        {
                            Console.WriteLine("Exiting...");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }

                        break;
                    case 2:
                        c1 = new CheckingAccount(number, balance);
                        Console.WriteLine("Did you want to withdraw : Y or N");
                        x = NullException(Console.ReadLine());
                        if (x.Equals("Y") || x.Equals("y"))
                        {
                            Console.WriteLine("How much amount want to withdraw?");
                            decimal.TryParse(Console.ReadLine(), out amt);
                            c1.Withdraw(amt);
                        }
                        else if (x.Equals("N") || x.Equals("n"))
                        {
                            Console.WriteLine("Exiting...");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }

                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        /// <summary>
        /// Method checks it is null
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns string</returns>
        public static string NullException(string? s)
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
