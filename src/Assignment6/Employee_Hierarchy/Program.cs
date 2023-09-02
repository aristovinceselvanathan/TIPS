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

            if (IsNameValid(isName))
            {
                Console.WriteLine("Salary of the Employee : ");
                isDecimal = Console.ReadLine();

                if (decimal.TryParse(isDecimal, out salary))
                {
                    name = isName;
                    Console.WriteLine("Did You want to create the 1.Developer 2.Manager 3.Exit : ");
                    if (int.TryParse(Console.ReadLine(), out option1))
                    {
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
                                    Console.WriteLine("Exiting...");
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
                                    Console.WriteLine("Exiting...");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                }

                                break;
                            case 3:
                                Console.WriteLine("Exiting...");
                                break;
                            default:
                                InvalidWarning("Option");
                                break;
                        }
                    }
                    else
                    {
                        InvalidWarning("Option");
                    }
                }
                else
                {
                    InvalidWarning("Salary");
                }
            }
            else
            {
                InvalidWarning("Name");
            }
        }

        /// <summary>
        /// Method checks for the string is valid alphabetic name.
        /// </summary>
        /// <param name="name">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsNameValid(string name)
        {
            Regex r = new Regex("^[a-zA-Z\\s]+$");
            if (r.IsMatch(name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// It shows the warning message of the invalid input
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the input</param>
        public static void InvalidWarning(string nameOfInput)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Invalid {nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Exiting.....");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
