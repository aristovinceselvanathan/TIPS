namespace Employee_Hierarchy
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method it askes for the Name, Salary and type of the role.
        /// It will print the details of the role.
        /// </summary>
        /// <param name="args">It takes the argument from command line</param>
        public static void Main(string[] args)
        {
            string x, name, match1, match2;
            decimal salary;
            Developer d1;
            Manager m1;
            Console.WriteLine("Name of the Employee : ");
            match1 = NullException(Console.ReadLine());
            Console.WriteLine("Salary of the Employee : ");
            match2 = NullException(Console.ReadLine());
            if (IsName(match1) && IsDecimal(match2))
            {
                name = match1;
                salary = Convert.ToDecimal(match2);
                Console.WriteLine("Did You want to create the 1. Developer or 2. Manager : ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        d1 = new Developer(name, salary);
                        Console.WriteLine("Did you want print the details : Y or N");
                        x = NullException(Console.ReadLine());
                        if (x.Equals("Y") || x.Equals("y"))
                        {
                            d1.PrintDetails();
                        }

                        break;
                    case 2:
                        m1 = new Manager(name, salary);
                        Console.WriteLine("Did you want print the details : Y or N");
                        x = NullException(Console.ReadLine());
                        if (x.Equals("Y") || x.Equals("y"))
                        {
                            m1.PrintDetails();
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
        /// Method checks string is null or not.
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
        /// Method checks for the string is valid alphabet name.
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsName(string s)
        {
            Regex r = new Regex("^[a-zA-Z'-]+$");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
