namespace DelegatesForSorting
{
    /// <summary>
    /// Product Class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets Name of the Product
        /// </summary>
        /// <value>
        /// String type of the name
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Category of the Product
        /// </summary>
        /// <value>
        /// String type of Category
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets Price of the Product
        /// </summary>
        /// <value>
        /// Decimal type of the Price
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Overrides the toString
        /// </summary>
        /// <returns>It returns the details of the product</returns>
        public override string ToString()
        {
            return $"Product Name : {this.Name} Category : {this.Category} Price : {this.Price},";
        }
    }
}