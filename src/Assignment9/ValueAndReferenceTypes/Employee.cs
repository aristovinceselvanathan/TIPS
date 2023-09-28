namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Employee Class describes the employee details
    /// </summary>
    internal class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="employeeId">Id Of the employee</param>
        /// <param name="nameOfEmployee">Name of the employee</param>
        /// <param name="designationOfEmployee">Designation of the employee</param>
        public Employee(string employeeId, string nameOfEmployee, string designationOfEmployee)
        {
            this.Id = employeeId;
            this.Name = nameOfEmployee;
            this.Designation = designationOfEmployee;
        }

        /// <summary>
        /// Gets or Sets Id of the employee
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string Id { get; set;  }

        /// <summary>
        /// Gets or Sets Name of the employee
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Designation of the employee
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string Designation { get; set; }

        /// <summary>
        /// It overrides the ToString method
        /// </summary>
        /// <returns>It returns the string of the details about employee</returns>
        public override string ToString()
        {
            return $"Employee Details: \nId : {this.Id} \nName : {this.Name} \nDesignation : {this.Designation}";
        }
    }
}