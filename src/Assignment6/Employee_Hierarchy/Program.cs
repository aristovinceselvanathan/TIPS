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
            match1 = ChecksStringIsNull(Console.ReadLine());
            Console.WriteLine("Salary of the Employee : ");
            match2 = ChecksStringIsNull(Console.ReadLine());

            if (IsName(match1) && decimal.TryParse(match2, out salary))
            {
                name = match1;
                Console.WriteLine("Did You want to create the 1. Developer or 2. Manager : ");
                int.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        d1 = new Developer(name, salary);
                        Console.WriteLine("Did you want print the details : Y or N");
                        x = ChecksStringIsNull(Console.ReadLine());

                        if (x.Equals("Y") || x.Equals("y"))
                        {
                            d1.PrintDetails();
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
                        m1 = new Manager(name, salary);
                        Console.WriteLine("Did you want print the details : Y or N");
                        x = ChecksStringIsNull(Console.ReadLine());

                        if (x.Equals("Y") || x.Equals("y"))
                        {
                            m1.PrintDetails();
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
        /// Method checks string is null or not.
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
