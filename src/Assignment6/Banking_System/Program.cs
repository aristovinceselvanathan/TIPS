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
            decimal salary;
            SavingsAccount s1;
            CheckingAccount c1;
            Console.WriteLine("Account Number : ");
            m1 = NullException(Console.ReadLine());
            Console.WriteLine("Account Balance : ");
            m2 = NullException(Console.ReadLine());
            if (IsNumber(m1) && IsDecimal(m2))
            {
                number = m1;
                salary = Convert.ToDecimal(number);
                Console.WriteLine("Did You want to create the 1. Savings Account or 2. Checking Account : ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        s1 = new SavingsAccount(number, salary);
                        Console.WriteLine("Did you want to withdraw : Y or N");
                        x = NullException(Console.ReadLine());
                        if (x.Equals("Y") || x.Equals("y"))
                        {
                            decimal amt = Convert.ToDecimal(Console.ReadLine());
                            s1.Withdraw(amt);
                        }

                        break;
                    case 2:
                        c1 = new CheckingAccount(number, salary);
                        Console.WriteLine("Did you want to withdraw : Y or N");
                        x = NullException(Console.ReadLine());
                        if (x.Equals("Y") || x.Equals("y"))
                        {
                            decimal amt = Convert.ToDecimal(Console.ReadLine());
                            c1.Withdraw(amt);
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
        /// Method checks for the input is valid decimal
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns boolean</returns>
        public static bool IsDecimal(string s)
        {
            Regex r = new Regex("^\\d+\\.?\\d*$");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method checks for the string is number or not because account number consists of numbers
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsNumber(string s)
        {
            Regex r = new Regex("^[0-9]{10}$");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
