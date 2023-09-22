namespace Task5
{
    /// <summary>
    /// Product Class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets hello
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets hello
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets hello
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public decimal? Price { get; set; }

        /// <summary>
        /// Overrides the toString
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"Product Name : {this.Name} Category : {this.Category} Price : {this.Price},";
        }
    }
}