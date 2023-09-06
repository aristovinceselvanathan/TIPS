namespace Employee_Hierarchy
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method it ask for the Name, Salary and type of the role.
        /// It will print the details about the role.
        /// </summary>
        /// <param name="args">It takes the argument from command line</param>
        public static void Main(string[] args)
        {
            int optionOfTypeOfRole;
            string optionOfChoice, nameOfUser, isValidName, isValidDecimal;
            decimal salary;

            Console.WriteLine("Name of the Employee : ");
            isValidName = Console.ReadLine();

            if (IsNameValid(isValidName))
            {
                nameOfUser = isValidName;
                Console.WriteLine("Salary of the Employee : ");
                isValidDecimal = Console.ReadLine();

                if (decimal.TryParse(isValidDecimal, out salary))
                {
                    Console.WriteLine("Did You want to create the 1.Developer 2.Manager 3.Exit : ");
                    if (int.TryParse(Console.ReadLine(), out optionOfTypeOfRole))
                    {
                        switch (optionOfTypeOfRole)
                        {
                            case 1:
                                Developer developer = new Developer(nameOfUser, salary);
                                Console.WriteLine("Did you want print the details : Y or N");
                                optionOfChoice = Console.ReadLine();

                                if (optionOfChoice.Equals("Y") || optionOfChoice.Equals("y"))
                                {
                                    developer.PrintDetails();
                                }
                                else if (optionOfChoice.Equals("N") || optionOfChoice.Equals("n"))
                                {
                                    Console.WriteLine("Exiting...");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                }

                                break;
                            case 2:
                                Manager manager = new Manager(nameOfUser, salary);
                                Console.WriteLine("Did you want print the details : Y or N");
                                optionOfChoice = Console.ReadLine();

                                if (optionOfChoice.Equals("Y") || optionOfChoice.Equals("y"))
                                {
                                    manager.PrintDetails();
                                }
                                else if (optionOfChoice.Equals("N") || optionOfChoice.Equals("n"))
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
        /// <param name="name">It takes the name of the user as input</param>
        /// <returns>It returns valid name</returns>
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
        /// It shows the colourful warning message of the invalid input
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
