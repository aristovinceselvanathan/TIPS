namespace ValueAndReferenceTypes
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            Employee employee1 = new Employee();
            string isId, isName, isDesignation;
            int value = 100;

            Console.WriteLine("Reference Type : Employee System");
            Console.WriteLine("Enter the Employee ID : ");
            isId = Console.ReadLine();

            if (IsID(isId))
            {
                employee1.Id = isId;
                Console.WriteLine("Enter the Name : ");
                isName = Console.ReadLine();
                if (IsName(isName))
                {
                    employee1.Name = isName;
                    Console.WriteLine("Enter the Designation : ");
                    isDesignation = Console.ReadLine();
                    if (IsDesignation(isDesignation))
                    {
                        employee1.Designation = isDesignation;
                        Console.WriteLine(employee1);
                        ChangeEmployee(employee1);
                        Console.WriteLine(employee1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Designation");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Name");
                }
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }

            Console.WriteLine("Value Type: Update Value ");
            UpdateValue(value);
            Console.WriteLine($"Value is {value}");

            Console.WriteLine("TO create the Large Number of Local Variable");
            LargeNumberLocalVariable();
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
            LargeArray();
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
        }

        /// <summary>
        /// It will change the value by reference
        /// </summary>
        /// <param name="employee">It takes the class as the input</param>
        public static void ChangeEmployee(Employee employee)
        {
            string isId, isName, isDesignation;

            Console.WriteLine("Employee Update Details");
            Console.WriteLine("Enter the Employee ID : ");
            isId = Console.ReadLine();

            if (IsID(isId))
            {
                employee.Id = isId;
                Console.WriteLine("Enter the Name : ");
                isName = Console.ReadLine();
                if (IsName(isName))
                {
                    employee.Name = isName;
                    Console.WriteLine("Enter the Designation : ");
                    isDesignation = Console.ReadLine();
                    if (IsDesignation(isDesignation))
                    {
                        employee.Designation = isDesignation;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Designation");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Name");
                }
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }

        /// <summary>
        /// It updates the variable by value type
        /// </summary>
        /// <param name="value">It takes the value as integer</param>
        public static void UpdateValue(int value)
        {
            value = 200;
            Console.WriteLine($"Value is {value}");
        }

        /// <summary>
        /// Method creates the large array of Integers.
        /// </summary>
        public static void LargeArray()
        {
            int[] arr = new int[1000000000];
            for (int i = 0; i < 1000000000; i++)
            {
                arr[i] = i;
            }

            Console.ReadKey();
            arr = null;
        }

        /// <summary>
        /// Method creates the large numbers of local variables.
        /// </summary>
        public static void LargeNumberLocalVariable()
        {
            for (int i = 0; i < 1000000000; i++)
            {
                int a = i;
            }
        }

        /// <summary>
        /// Method checks for the name is valid
        /// </summary>
        /// <param name="name">It takes the name of the employee as a string</param>
        /// <returns>It returns the boolean</returns>
        public static bool IsName(string name)
        {
            Regex pattern = new Regex("^[a-zA-Z\\s]*$");
            if (pattern.IsMatch(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method checks for the id is valid
        /// </summary>
        /// <param name="id">It takes the id of the employee as a string</param>
        /// <returns>It returns the boolean</returns>
        public static bool IsID(string id)
        {
            Regex pattern = new Regex("^\\d+$");
            if (pattern.IsMatch(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method checks for the name is valid
        /// </summary>
        /// <param name="designation">It takes the name of the employee as a string</param>
        /// <returns>It returns the boolean</returns>
        public static bool IsDesignation(string designation)
        {
            Regex pattern = new Regex("^[a-zA-Z\\s]*$");
            if (pattern.IsMatch(designation))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}