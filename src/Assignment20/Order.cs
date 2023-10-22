namespace Assignment20
{
    using System;

    /// <summary>
    /// Order Class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="orderID">Id of the order</param>
        /// <param name="orderDate">Date of the order</param>
        /// <param name="orderStatus">Status of the order</param>
        public Order(int orderID, DateTime orderDate, bool orderStatus)
        {
            this.OrderID = orderID;
            this.OrderDate = orderDate;
            this.OrderStatus = orderStatus;
        }

        /// <summary>
        /// Gets or sets Order Id
        /// </summary>
        /// <value>
        /// Integer
        /// </value>
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets Order Date
        /// </summary>
        /// <value>
        /// Integer
        /// </value>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets Order Status
        /// </summary>
        /// <value>
        /// Integer
        /// </value>
        public bool OrderStatus { get; set; }

        /// <summary>
        /// To print the order class as a string
        /// </summary>
        /// <returns>Values of the product</returns>
        public override string ToString()
        {
            return $"Order ID: {this.OrderID}, Order Date : {this.OrderDate}, Order Status: {this.OrderStatus}";
        }
    }
}