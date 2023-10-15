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
        /// <param name="customerID">Id of the customer</param>
        /// <param name="orderDate">Date of the order</param>
        /// <param name="orderStatus">Status of the order</param>
        /// <param name="totalAmount">Amount of the order</param>
        public Order(int orderID, int customerID, DateTime orderDate, bool orderStatus, decimal totalAmount)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.OrderDate = orderDate;
            this.OrderStatus = orderStatus;
            this.TotalAmount = totalAmount;
        }

        /// <summary>
        /// Gets or sets Order Id
        /// </summary>
        /// <value>
        /// Integer
        /// </value>
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets Customer Id
        /// </summary>
        /// <value>
        /// Integer
        /// </value>
        public int CustomerID { get; set; }

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
        /// Gets or sets Total Amount
        /// </summary>
        /// <value>
        /// Decimal
        /// </value>
        public decimal TotalAmount { get; set; }
    }
}