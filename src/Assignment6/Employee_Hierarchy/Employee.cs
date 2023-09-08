namespace Employee_Hierarchy
{
    /// <summary>
    /// Employee abstract class
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// Method sets the name and salary of the object
        /// </summary>
        /// <param name="name">It takes the name of the employee as string</param>
        /// <param name="salary">It takes the salary of the employee as decimal</param>
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Gets or sets the Salary of the employee
        /// </summary>
        /// <value>It contains decimal</value>
        protected decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets the Name of the employee
        /// </summary>
        /// <value>It contains string</value>
        protected string Name { get; set; }

        /// <summary>
        /// It prints the details of the employee
        /// </summary>
        public virtual void PrintDetails()
        {
            Console.WriteLine($"Name : {this.Name}");
            Console.WriteLine($"Salary : {this.Salary}");
        }

        /// <summary>
        /// Abstract method to calculate Bonus of the employee
        /// </summary>
        /// <returns>It returns decimal</returns>
        protected abstract decimal CalculateBonus();
    }
}
