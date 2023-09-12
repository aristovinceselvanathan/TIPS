namespace Assignment3
{
    /// <summary>
    /// Account Class
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or Sets the string
        /// </summary>
        /// <value>
        /// Email from main method
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether active
        /// </summary>
        /// <value>
        /// Active status
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or Sets the DateTime
        /// </summary>
        /// <value>
        /// CreatedDate
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets the Ilist that contains Roles
        /// </summary>
        /// <value>
        /// Roles
        /// </value>
        public IList<string> Roles { get; set; }
    }
}