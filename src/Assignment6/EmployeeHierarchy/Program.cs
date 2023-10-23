namespace EmployeeHierarchy
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            Developer = 1,
            Manager = 2,
            Exit = 3,
        }

        /// <summary>
        /// Main method it ask for the Name, Salary and type of the role.
        /// It will print the details about the role.
        /// </summary>
        /// <param name="args">It takes the argument from command line</param>
        public static void Main(string[] args)
        {
            bool flag = true;

            Console.WriteLine("Welcome to Employee Management System");
            while (flag)
            {
                Console.WriteLine("Do You want to create the 1.Developer 2.Manager 3.Exit : ");
                if (int.TryParse(Console.ReadLine(), out int optionOfTypeOfRole))
                {
                    Options option = (Options)optionOfTypeOfRole;
                    switch (option)
                    {
                        case Options.Developer:
                            Developer developer = new Developer();
                            CreateRoleOfEmployee(developer);
                            break;
                        case Options.Manager:
                            Manager manager = new Manager();
                            CreateRoleOfEmployee(manager);
                            break;
                        case Options.Exit:
                            flag = false;
                            break;
                        default:
                            WarningMessageFromConsole("Option");
                            break;
                    }
                }
                else
                {
                    WarningMessageFromConsole("Option");
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Exiting...");
        }

        /// <summary>
        /// It creates the role of the employee and the print the details of the employee
        /// </summary>
        /// <param name="employee">It takes the employee reference can have child objects</param>
        public static void CreateRoleOfEmployee(Employee employee)
        {
            string userInputName, userInputBalance, optionOfChoice;
            decimal salary;

            Console.WriteLine("Name of the Employee : ");
            userInputName = Console.ReadLine();

            if (IsValidNameOfEmployee(userInputName))
            {
                Console.WriteLine("Salary of the Employee : ");
                userInputBalance = Console.ReadLine();

                if (decimal.TryParse(userInputBalance, out salary))
                {
                    employee.Name = userInputName;
                    employee.Salary = salary;

                    Console.WriteLine("Do you want to print the details : Y or N");
                    optionOfChoice = Console.ReadLine();
                    if (string.Equals(optionOfChoice, "y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        employee.PrintDetails();
                    }
                    else if (string.Equals(optionOfChoice, "n", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Exiting...");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else
                {
                    WarningMessageFromConsole("Salary");
                }
            }
            else
            {
                WarningMessageFromConsole("Name");
            }
        }

        /// <summary>
        /// Method checks for the string is valid alphabetic name.
        /// </summary>
        /// <param name="name">It takes the name of the user</param>
        /// <returns>It returns valid name</returns>
        public static bool IsValidNameOfEmployee(string name)
        {
            Regex r = new Regex("^[a-zA-Z\\s]+$");
            if (r.IsMatch(name))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// It shows the colorful warning message of the invalid input
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the event occurred</param>
        public static void WarningMessageFromConsole(string nameOfInput)
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
