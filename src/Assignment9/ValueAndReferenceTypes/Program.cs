namespace ValueAndReferenceTypes
{
    using ExtendedValueAndReferenceType;

    /// <summary>
    /// Program Class that contains the entry of the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that creates the Value and Reference Type field and print the fields
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            Employee employee = new Employee();
            int value = 100;

            Console.WriteLine("Reference Type : Employee System");
            Console.WriteLine($"Value is {value}");
            Console.WriteLine(employee);
            ChangeValues(employee, value);
            Console.WriteLine("After the function call:");
            Console.WriteLine(employee);
            Console.WriteLine($"Value is after calling the function to change value is {value}\n");
            Console.WriteLine("To create the Large Number of Local Variable");
            ExtendedValueAndReferenceType.LargeNumberLocalVariable();
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
            Console.WriteLine("To create the Large Array of Integer");
            ExtendedValueAndReferenceType.LargeArray();
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
        }

        /// <summary>
        /// Method will change the value of the parameter int the predefined manner by using value type and reference type
        /// </summary>
        /// <param name="employee">It takes the employee class as the input to change it</param>
        /// <param name="value">It will take the value as input and change it</param>
        public static void ChangeValues(Employee employee, int value)
        {
            Console.WriteLine("Employee Update Details");

            employee.Id = "1002";
            employee.Name = "Jim Cook";
            employee.Designation = "Admin";
            Console.WriteLine(employee);
            value = 200;
            Console.WriteLine($"Value in the function: {value}");
        }
    }
}