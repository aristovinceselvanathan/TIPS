namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Employee Class
    /// </summary>
    internal class Employee
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string Id { get; set;  }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string Designation { get; set; }

        /// <summary>
        /// It overrides the ToString method
        /// </summary>
        /// <returns>It returns the string</returns>
        public override string ToString()
        {
            return $"Employee Details: \nId : {this.Id} \nName : {this.Name} \nDesignation : {this.Designation}";
        }
    }
}