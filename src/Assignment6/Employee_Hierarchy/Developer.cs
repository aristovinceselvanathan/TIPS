namespace Employee_Hierarchy
{
    /// <summary>
    /// Developer Class and it inherits the developer class
    /// </summary>
    internal class Developer : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// It inherits the Employee class and call the constructor of base class by passing the values
        /// </summary>
        /// <param name="name">It takes the name of the user as string</param>
        /// <param name="salary">It takes the salary of the user as decimal</param>
        public Developer(string name, decimal salary)
            : base(name, salary)
        {
            Console.WriteLine("This is a Developer Class");
        }

        /// <summary>
        /// Method prints the details (such as Name, Position, Salary, Bonus) of the Developer object
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"Name : {this.Name}");
            Console.WriteLine($"Position : Developer");
            Console.WriteLine($"Salary : {this.Salary}");
            decimal bonus = this.CalculateBonus();
            Console.WriteLine($"Bonus : {bonus}");
        }

        /// <summary>
        /// Method overrides the abstract class method
        /// Method to calculate the bonus of the Developer
        /// </summary>
        /// <returns>It returns decimal</returns>
        protected override decimal CalculateBonus()
        {
            return this.Salary / 5;
        }
    }
}
