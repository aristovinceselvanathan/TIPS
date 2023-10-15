namespace Assignment20
{
    /// <summary>
    /// Product Class
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">Id of the Product</param>
        /// <param name="productName">Name of the Product</param>
        /// <param name="productPrice">Price of the Product</param>
        /// <param name="productCategory">Category of the Product</param>
        public Product(int productId, string productName, double productPrice, string productCategory)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductPrice = productPrice;
            this.ProductCategory = productCategory;
        }

        /// <summary>
        /// Gets or sets Product ID
        /// </summary>
        /// <value>
        /// Integer
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets Product Name
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets Product Price
        /// </summary>
        /// <value>
        /// Double
        /// </value>
        public double ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets Product Category
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string ProductCategory { get; set; }
    }
}
