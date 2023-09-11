namespace EmployeeHierarchy
{
    /// <summary>
    /// Employee abstract class
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Gets or sets the Salary of the employee
        /// </summary>
        /// <value>It contains decimal</value>
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets the Name of the employee
        /// </summary>
        /// <value>It contains string</value>
        public string Name { get; set; }

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
