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
        /// <param name="args">It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            Employee employee = new Employee("1001", "Tom Cruise", "IT");
            int value = 100;

            Console.WriteLine("Reference Type : \n");
            Console.WriteLine(employee);
            Console.WriteLine($"\nValue is {value}");
            ChangeValues(employee, value);
            Console.WriteLine("After the function call:");
            Console.WriteLine(employee);
            Console.WriteLine($"\nValue is after the function call : {value}\n");
            Console.WriteLine("To create the Large Number of Local Variable");
            ExtendedValueAndReferenceType.LargeNumberLocalVariable(); // While declaring the local variable inside the loop it will make variable out of scope, there is no significant changes in heap size
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
            Console.WriteLine("To create the Large Array of Integer");
            ExtendedValueAndReferenceType.LargeArray();  // While creating the array of the large size it will allocate the large heap size about increase of 71.0 KB
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
        }

        /// <summary>
        /// Method will change the value of the parameter int the predefined manner by using value type and reference type
        /// </summary>
        /// <param name="employee">Employee class as the input to change it</param>
        /// <param name="value">Value as input and change it</param>
        public static void ChangeValues(Employee employee, int value)
        {
            Console.WriteLine("\n\nUpdate Employee Details and Value in the Function");

            employee.Id = "1002";
            employee.Name = "Jim Cook";
            employee.Designation = "Admin";
            Console.WriteLine(employee);
            value = 200;
            Console.WriteLine($"\nValue in the function: {value}\n\n");
        }
    }
}