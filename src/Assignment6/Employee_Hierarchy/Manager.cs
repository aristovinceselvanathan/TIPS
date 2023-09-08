namespace Employee_Hierarchy
{
    /// <summary>
    /// Manager Class and it inherits the Employee class
    /// </summary>
    internal class Manager : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// It inherits the Employee class and call the constructor of base class by passing the values
        /// </summary>
        /// <param name="name">It takes the name of the user as string</param>
        /// <param name="salary">It takes the salary of the user as decimal</param>
        public Manager(string name, decimal salary)
            : base(name, salary)
        {
            Console.WriteLine("This is a Manager Class");
        }

        /// <summary>
        /// Method prints the details (such as Name, Position, Salary, Bonus) of the Manager object
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"Name : {this.Name}");
            Console.WriteLine($"Position : {this.GetType().Name}");
            Console.WriteLine($"Salary : {this.Salary}");
            decimal bonus = this.CalculateBonus();
            Console.WriteLine($"Bonus : {bonus}");
        }

        /// <summary>
        /// Method overrides the abstract class method
        /// Method to calculate the bonus of the manager
        /// </summary>
        /// <returns>It returns decimal</returns>
        protected override decimal CalculateBonus()
        {
            return this.Salary / 10;
        }
    }
}
