namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that creates the Value and Reference Type objects
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            Employee employee1 = new Employee();
            int value = 100;

            employee1.Id = "1001";
            employee1.Name = "Tom Cruise";
            employee1.Designation = "IT";

            Console.WriteLine("Reference Type : Employee System");
            Console.WriteLine(employee1);
            ChangeEmployee(employee1);
            Console.WriteLine(employee1);
            Console.WriteLine("Value Type : Update Value ");
            Console.WriteLine($"Value is {value}");
            UpdateValue(value);
            Console.WriteLine($"Value is after calling the function to change value is {value}");
            Console.WriteLine("To create the Large Number of Local Variable");
            LargeNumberLocalVariable();
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
            Console.WriteLine("To create the Large Array of Integer");
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
            Console.WriteLine("Employee Update Details");

            employee.Id = "1002";
            employee.Name = "Jim Cook";
            employee.Designation = "Admin";
            Console.WriteLine(employee);
        }

        /// <summary>
        /// It updates the variable by value type
        /// </summary>
        /// <param name="value">It takes the value as integer</param>
        public static void UpdateValue(int value)
        {
            value = 200;
            Console.WriteLine($"Value in the function: {value}");
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
    }
}