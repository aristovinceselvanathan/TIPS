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
            int option1;
            string option2, name, isName, isDecimal;
            decimal salary;
            Developer developer;
            Manager manager;

            Console.WriteLine("Name of the Employee : ");
            isName = Console.ReadLine();
            if (IsName(isName))
            {
                Console.WriteLine("Salary of the Employee : ");
                isDecimal = Console.ReadLine();

                if (decimal.TryParse(isDecimal, out salary))
                {
                    name = isName;
                    Console.WriteLine("Did You want to create the 1. Developer or 2. Manager : ");
                    int.TryParse(Console.ReadLine(), out option1);

                    switch (option1)
                    {
                        case 1:
                            developer = new Developer(name, salary);
                            Console.WriteLine("Did you want print the details : Y or N");
                            option2 = Console.ReadLine();

                            if (option2.Equals("Y") || option2.Equals("y"))
                            {
                                developer.PrintDetails();
                            }
                            else if (option2.Equals("N") || option2.Equals("n"))
                            {
                                Console.WriteLine("Eoption1iting...");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                            }

                            break;
                        case 2:
                            manager = new Manager(name, salary);
                            Console.WriteLine("Did you want print the details : Y or N");
                            option2 = Console.ReadLine();

                            if (option2.Equals("Y") || option2.Equals("y"))
                            {
                                manager.PrintDetails();
                            }
                            else if (option2.Equals("N") || option2.Equals("n"))
                            {
                                Console.WriteLine("Eoption1iting...");
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
            else
            {
                Console.WriteLine("Invalid Name");
            }
        }

        /// <summary>
        /// Method checks for the string is valid alphabetic name.
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsName(string s)
        {
            Regex r = new Regex("^[a-zA-Z\\s]+$");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
