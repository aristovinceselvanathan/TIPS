namespace EmployeeHierarchy
{
    /// <summary>
    /// Developer Class
    /// </summary>
    internal class Developer : Employee
    {
        /// <summary>
        /// Method prints the details (such as Name, Position, Salary, Bonus) of the Developer object
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
        /// Method to calculate the bonus of the Developer
        /// </summary>
        /// <returns>It returns decimal</returns>
        protected override decimal CalculateBonus()
        {
            return this.Salary / 5;
        }
    }
}
