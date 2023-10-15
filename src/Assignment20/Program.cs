using System.Drawing;
using System.Linq.Dynamic.Core;

namespace Assignment20
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// It is entry point of the program
        /// </summary>
        /// <param name="args">String array in parameters of the main method</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to LINQ Fundamentals");
            List<Product> products = new List<Product>();
            List<Supplier> suppliers = new List<Supplier>();
            List<Order> orders = new List<Order>();
            products.Add(new Product(1, "The Great Gatsby", 14.99, "Books"));
            products.Add(new Product(2, "iPhone 13", 799.99, "Electronics"));
            products.Add(new Product(3, "Cotton T-Shirt", 19.99, "Apparel"));
            products.Add(new Product(4, "Coffee Maker", 59.99, "Appliances"));
            products.Add(new Product(5, "Gaming Laptop", 1299.99, "Electronics"));
            products.Add(new Product(6, "Bluetooth Speaker", 49.99, "Electronics"));
            products.Add(new Product(7, "Running Shoes", 79.99, "Footwear"));
            products.Add(new Product(8, "HD Smart TV", 599.99, "Electronics"));
            products.Add(new Product(9, "Laptop Bag", 29.99, "Accessories"));
            products.Add(new Product(10, "Coffee Table", 149.99, "Furniture"));
            products.Add(new Product(11, "Digital Camera", 299.99, "Electronics"));
            products.Add(new Product(12, "Desk Chair", 89.99, "Furniture"));
            products.Add(new Product(13, "Dress Shirt", 34.99, "Apparel"));
            products.Add(new Product(14, "Portable Charger", 19.99, "Electronics"));
            products.Add(new Product(15, "Kitchen Blender", 39.99, "Appliances"));
            suppliers.Add(new Supplier(1, "Supplier X", 1));
            suppliers.Add(new Supplier(2, "Supplier Y", 2));
            suppliers.Add(new Supplier(3, "Supplier Z", 3));
            suppliers.Add(new Supplier(4, "Supplier A", 4));
            suppliers.Add(new Supplier(2, "Supplier Y", 5));
            suppliers.Add(new Supplier(5, "Supplier B", 6));
            suppliers.Add(new Supplier(6, "Supplier C", 7));
            suppliers.Add(new Supplier(2, "Supplier Y", 8));
            suppliers.Add(new Supplier(7, "Supplier D", 9));
            suppliers.Add(new Supplier(8, "Supplier E", 10));
            suppliers.Add(new Supplier(2, "Supplier Y", 11));
            suppliers.Add(new Supplier(9, "Supplier F", 12));
            suppliers.Add(new Supplier(3, "Supplier Z", 13));
            suppliers.Add(new Supplier(10, "Supplier G", 14));
            suppliers.Add(new Supplier(4, "Supplier A", 15));
            suppliers.Add(new Supplier(1, "Supplier X", 5));
            suppliers.Add(new Supplier(3, "Supplier Z", 4));
            orders.Add(new Order(1, 101, new DateTime(2023, 10, 15, 8, 30, 0), true, 100.00m));
            orders.Add(new Order(2, 102, new DateTime(2023, 10, 16, 14, 45, 0), false, 75.50m));
            orders.Add(new Order(3, 103, new DateTime(2023, 09, 17, 10, 15, 0), true, 120.25m));
            orders.Add(new Order(4, 104, new DateTime(2023, 10, 18, 9, 0, 0), true, 80.75m));
            orders.Add(new Order(5, 105, new DateTime(2023, 09, 19, 16, 20, 0), false, 65.90m));
            orders.Add(new Order(6, 106, new DateTime(2023, 08, 20, 11, 30, 0), true, 150.50m));
            orders.Add(new Order(7, 107, new DateTime(2023, 07, 21, 13, 15, 0), false, 90.25m));
            orders.Add(new Order(8, 108, new DateTime(2023, 02, 22, 12, 0, 0), true, 110.75m));
            orders.Add(new Order(9, 109, new DateTime(2023, 01, 23, 15, 45, 0), true, 200.10m));
            orders.Add(new Order(10, 110, new DateTime(2023, 03, 24, 17, 0, 0), false, 60.30m));
            FilteredProducts(products);
            GroupByCategory(products);
            SupplierJoin(products, suppliers);
            SecondMax();
            Order(orders);
            BookCategory(products);
            Func<Product, bool> electronicsProducts = product => product.ProductCategory == "Electronics";
            List<Product> electronicsFilteredProducts = FilterProducts(products, electronicsProducts);
            Console.WriteLine($"Electronics Product : {string.Join(", ", electronicsProducts)}");
            Console.Write("Sort By Property to Sort by (eg : Price) : ");
            string property = $"{Console.ReadLine()} ascending";
            var sortedProducts = products.AsQueryable().OrderBy(property).ToList();
            Console.WriteLine($"{string.Join(",", sortedProducts)}");
        }

        /// <summary>
        /// Filter the Products
        /// </summary>
        /// <param name="products">product</param>
        public static void FilteredProducts(List<Product> products)
        {
            Console.WriteLine("Filter the Products under the Category Electronics and Price Greater than $300 : ");
            var filteredProducts = products.Where(product => product.ProductCategory == "Electronics" && product.ProductPrice > 500).Select(product => new { product.ProductName, product.ProductPrice }).OrderByDescending(product => product.ProductPrice);
            foreach (var item in filteredProducts)
            {
                Console.WriteLine($"{item.ProductName} : {item.ProductPrice}");
            }
            Console.WriteLine($"Average : {Math.Round(filteredProducts.Average(product => product.ProductPrice), 2)}");
        }

        /// <summary>
        /// Filter the Products
        /// </summary>
        /// <param name="products">product</param>
        public static void GroupByCategory(List<Product> products)
        {
            Console.WriteLine("Group by the Category : ");
            var groupedProducts = products.GroupBy(product => product.ProductCategory).Select(productCategory => new { category = productCategory.Key, count = productCategory.Count(), expensiveProduct = productCategory.Max(product => product.ProductPrice) });
            foreach (var item in groupedProducts)
            {
                Console.WriteLine($"Category : {item.category}, Count : {item.count}, Expensive Product : {item.expensiveProduct}");
            }
        }

        /// <summary>
        /// Filter the Products
        /// </summary>
        /// <param name="products">product</param>
        /// <param name="suppliers">producsdfwet</param>
        public static void SupplierJoin(List<Product> products, List<Supplier> suppliers)
        {
            Console.WriteLine("Supplier of the Products : ");
            var supplierInnerJoinProducts = from product in products
                                            join supplier in suppliers
                                            on product.ProductId equals supplier.ProductId
                                            orderby supplier.SupplierName
                                            select new
                                            {
                                                productName = product.ProductName,
                                                supplierName = supplier.SupplierName,
                                            };
            var enumerator1 = supplierInnerJoinProducts.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                Console.WriteLine($"{enumerator1.Current.productName} : {enumerator1.Current.supplierName}");
            }
        }

        /// <summary>
        /// Filter the Products
        /// </summary>
        public static void SecondMax()
        {
            Random rand = new Random();
            int[] integerArray = Enumerable.Range(1, 100).OrderBy(i => rand.Next()).Take(35).ToArray();
            Console.WriteLine("Integer Array is [{0}]", string.Join(", ", integerArray));
            var result1 = integerArray.OrderByDescending(x => x).Select(x => x).Skip(1).FirstOrDefault();
            Console.WriteLine($"Second Highest Number : {result1}");
            Console.Write("Enter the Target Number : ");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                var result2 = from n1 in integerArray
                              from n2 in integerArray
                              where n1 != n2 && n1 + n2 == target
                              select new { n1, n2 };
                var enumerator2 = result2.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    Console.Write($"{enumerator2.Current.ToString()}, ");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Invalid Input, Please Enter the Valid Number from {int.MinValue} to {int.MaxValue}");
            }
        }

        /// <summary>
        /// Filter the Products
        /// </summary>
        /// <param name="orders">orders</param>
        public static void Order(List<Order> orders)
        {
            var recentOrders = orders.Where(order => order.OrderDate >= DateTime.Now.Date.AddDays(-30)).OrderByDescending(order => order.OrderDate).Select(order => new { orderid = order.OrderID, amount = order.TotalAmount }).ToList();
            Console.WriteLine($"Orders before 30days : {string.Join(", ", recentOrders)}");
            var completedOrder = orders.Where(order => order.OrderStatus == true).ToList();
            Console.WriteLine($"Completed Orders : {completedOrder.Count}");
        }

        /// <summary>
        /// Filter the Products
        /// </summary>
        /// <param name="products">orders</param>
        public static void BookCategory(List<Product> products)
        {
            var productsOfBook = products.Where(order => order.ProductCategory == "Books").OrderByDescending(order => order.ProductPrice).Select(order => new { Id = order.ProductId, Name = order.ProductName, Price = order.ProductPrice });
            Console.WriteLine($"Products in Book Category : {string.Join(", ", productsOfBook)}");
        }

        /// <summary>
        /// Filter the Products
        /// </summary>
        /// <param name="products">product</param>
        /// <param name="filter">filter</param>
        /// <returns>products</returns>
        public static List<Product> FilterProducts(List<Product> products, Func<Product, bool> filter)
        {
            return products.Where(filter).ToList();
        }
    }
}