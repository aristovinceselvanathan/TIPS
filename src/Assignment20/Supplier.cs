namespace Assignment20
{
    /// <summary>
    /// Supplier Class
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="supplierId">Id of the Supplier</param>
        /// <param name="supplierName">Name of the Supplier</param>
        /// <param name="productId">Id of the Product</param>
        public Supplier(int supplierId, string supplierName, int productId)
        {
            this.ProductId = productId;
            this.SupplierName = supplierName;
            this.SupplierId = supplierId;
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
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets Product Price
        /// </summary>
        /// <value>
        /// Integer
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// To print the order class as a string
        /// </summary>
        /// <returns>values of the product</returns>
        public override string ToString()
        {
            return $"Product ID: {this.ProductId}, Supplier Name : {this.SupplierName}, Supplier Id: {this.SupplierId}";
        }
    }
}
