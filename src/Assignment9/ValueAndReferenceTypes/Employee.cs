﻿namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Employee Class
    /// </summary>
    internal class Employee
    {
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