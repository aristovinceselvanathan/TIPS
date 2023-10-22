namespace Assignment20
{
    /// <summary>
    /// Generate Data Class
    /// </summary>
    public class GenerateData
    {
        /// <summary>
        /// Generate The List of the Products
        /// </summary>
        /// <returns>List consists of the product data</returns>
        public static List<Product> GenerateProducts()
        {
            var products = new List<Product>
            {
                new Product(1, "The Great Gatsby", 14.99, "Books"),
                new Product(2, "iPhone 13", 799.99, "Electronics"),
                new Product(3, "Cotton T-Shirt", 19.99, "Apparel"),
                new Product(4, "Coffee Maker", 59.99, "Appliances"),
                new Product(5, "Gaming Laptop", 1299.99, "Electronics"),
                new Product(6, "Bluetooth Speaker", 49.99, "Electronics"),
                new Product(7, "Running Shoes", 79.99, "Footwear"),
                new Product(8, "HD Smart TV", 599.99, "Electronics"),
                new Product(9, "Laptop Bag", 29.99, "Accessories"),
                new Product(10, "Coffee Table", 149.99, "Furniture"),
                new Product(11, "Digital Camera", 299.99, "Electronics"),
                new Product(12, "Desk Chair", 89.99, "Furniture"),
                new Product(13, "Dress Shirt", 34.99, "Apparel"),
                new Product(14, "Portable Charger", 19.99, "Electronics"),
                new Product(15, "Kitchen Blender", 39.99, "Appliances"),
            };
            return products;
        }

        /// <summary>
        /// Generate The List of the Supplier
        /// </summary>
        /// <returns>List consists of the supplier data</returns>
        public static List<Supplier> GenerateSupplier()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier(1, "Supplier X", 1),
                new Supplier(2, "Supplier Y", 2),
                new Supplier(3, "Supplier Z", 3),
                new Supplier(4, "Supplier A", 4),
                new Supplier(2, "Supplier Y", 5),
                new Supplier(5, "Supplier B", 6),
                new Supplier(6, "Supplier C", 7),
                new Supplier(2, "Supplier Y", 8),
                new Supplier(7, "Supplier D", 9),
                new Supplier(8, "Supplier E", 10),
                new Supplier(2, "Supplier Y", 11),
                new Supplier(9, "Supplier F", 12),
                new Supplier(3, "Supplier Z", 13),
                new Supplier(10, "Supplier G", 14),
                new Supplier(4, "Supplier A", 15),
                new Supplier(1, "Supplier X", 5),
                new Supplier(3, "Supplier Z", 4),
            };
            return suppliers;
        }

        /// <summary>
        /// Generate The List of the Order
        /// </summary>
        /// <returns>List consists of the order data</returns>
        public static List<Order> GenerateOrder()
        {
            var orders = new List<Order>
            {
                new Order(1, new DateTime(2023, 10, 15, 8, 30, 0), true),
                new Order(2, new DateTime(2023, 10, 16, 14, 45, 0), false),
                new Order(3, new DateTime(2023, 09, 17, 10, 15, 0), true),
                new Order(4, new DateTime(2023, 10, 18, 9, 0, 0), true),
                new Order(5, new DateTime(2023, 09, 19, 16, 20, 0), false),
                new Order(6, new DateTime(2023, 08, 20, 11, 30, 0), true),
                new Order(7, new DateTime(2023, 07, 21, 13, 15, 0), false),
                new Order(8, new DateTime(2023, 02, 22, 12, 0, 0), true),
                new Order(9, new DateTime(2023, 01, 23, 15, 45, 0), true),
                new Order(10, new DateTime(2023, 03, 24, 17, 0, 0), false),
            };
            return orders;
        }
    }
}
