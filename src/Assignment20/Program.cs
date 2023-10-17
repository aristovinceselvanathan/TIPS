namespace Assignment20
{
    using System.Linq.Dynamic.Core;
    using System.Linq.Expressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            FilteredProducts = 1,
            GroupByCategory = 2,
            JoinWithSupplier = 3,
            SecondMaxInTheArray = 4,
            OrdersBefore30Days = 5,
            BookCategory = 6,
            UserChoiceQuery = 7,
            DisplayAllList = 8,
            JoinUsingQueryBuilder = 9,
            Exit = 10,
        }

        /// <summary>
        /// It is entry point of the program
        /// </summary>
        /// <param name="args">String array in parameters of the main method</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            List<Product> products = GenerateData.GenerateProducts();
            List<Supplier> suppliers = GenerateData.GenerateSupplier();
            List<Order> orders = GenerateData.GenerateOrder();
            while (flag)
            {
                Console.WriteLine("Welcome to LINQ Fundamentals");
                Console.WriteLine("1 - Filter the Products,\n2 - Group By Category,\n3 - Join the Supplier with Products,\n4 - Second Max in the array,\n5 - Orders Before 30 Days," +
                    "\n6 - Book Category Alone\n7 - Choose the Category to select\n8 - Display all the List\n9 - JoinUsingQueryBuilder\n10 - Exit");
                Console.Write("Enter the Choice : ");
                if (int.TryParse(Console.ReadLine(), out int userInput) && userInput > 0 && userInput <= 9)
                {
                    Options options = (Options)userInput;
                    switch (options)
                    {
                        case Options.FilteredProducts:
                            FilteredProducts(products);
                            break;
                        case Options.GroupByCategory:
                            GroupByCategory(products);
                            break;
                        case Options.JoinWithSupplier:
                            SupplierJoin(products, suppliers);
                            break;
                        case Options.SecondMaxInTheArray:
                            SecondMaxInArray();
                            break;
                        case Options.OrdersBefore30Days:
                            OrdersBefore30Days(orders);
                            break;
                        case Options.BookCategory:
                            BookCategory(products);
                            break;
                        case Options.UserChoiceQuery:
                            UserPreferredSort(products);
                            break;
                        case Options.DisplayAllList:
                            DisplayAll(products, orders, suppliers);
                            break;
                        case Options.JoinUsingQueryBuilder:
                            JoinUsingQueryBuilder(products, suppliers);
                            break;
                        case Options.Exit:
                            flag = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input - Please enter the values from 1 to 9");
                }

                if (flag)
                {
                    ClearScreen();
                }
            }
        }
        public List<Product> Sort(List<Product> products, string propertyName, bool ascending)
        {
            var parameter = Expression.Parameter(typeof(Product), propertyName"")
        }
        /// <summary>
        /// Filter the Products belong to electronics category and price greater than $300
        /// </summary>
        /// <param name="products">Filtered list of product data</param>
        public static void FilteredProducts(List<Product> products)
        {
            Console.WriteLine("\nFilter the Products under the Category Electronics and Price Greater than $300 : \n");
            var filteredProducts = products.Where(product => product.ProductCategory == "Electronics" && product.ProductPrice > 500).Select(product => new { product.ProductName, product.ProductPrice }).OrderByDescending(product => product.ProductPrice);
            foreach (var item in filteredProducts)
            {
                Console.WriteLine($"{item.ProductName} : {item.ProductPrice}");
            }
            Console.WriteLine($"Average : {Math.Round(filteredProducts.Average(product => product.ProductPrice), 2)}");
        }

        /// <summary>
        /// Group the products list by the category-wise
        /// </summary>
        /// <param name="products">List of grouped products based on category</param>
        public static void GroupByCategory(List<Product> products)
        {
            Console.WriteLine("\nGroup by the Category : \n");
            var groupedProducts = products.GroupBy(product => product.ProductCategory).Select(productCategory => new { category = productCategory.Key, count = productCategory.Count(), expensiveProduct = productCategory.Max(product => product.ProductPrice) });
            foreach (var item in groupedProducts)
            {
                Console.WriteLine($"Category : {item.category}, Count : {item.count}, Expensive Product : {item.expensiveProduct}");
            }
        }

        /// <summary>
        /// To perform the inner join with the supplier and products
        /// </summary>
        /// <param name="products">List of the product data</param>
        /// <param name="suppliers">List of the supplier data</param>
        public static void SupplierJoin(List<Product> products, List<Supplier> suppliers)
        {
            Console.WriteLine("\nSupplier of the Products : \n");
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
        /// Asking query from the user to sort the list by Dynamic LINQ
        /// </summary>
        /// <param name="products">List of the products data</param>
        public static void UserPreferredSort(List<Product>products)
        {
            Func<Product, bool> electronicsProducts = product => product.ProductCategory == "Electronics";
            List<Product> electronicsFilteredProducts = FilterProducts(products, electronicsProducts);
            Console.WriteLine($"\nElectronics Product :\n{string.Join("\n", electronicsFilteredProducts)}");
            Console.Write("\nSort By Property to Sort by (ProductPrice, ProductCategory, ProductName) : ");
            string queryOfUser = Console.ReadLine();
            List<string> query = new List<string> { "ProductPrice", "ProductCategory", "ProductName" };
            if (query.Contains(queryOfUser))
            {
                Console.Write("Specify the ascending or descending : ");
                string orderByUser = Console.ReadLine().ToLower();
                if (orderByUser.Equals("ascending") || orderByUser.Equals("descending"))
                {
                    string property = $"{queryOfUser} {orderByUser}";
                    var sortedProducts = electronicsFilteredProducts.AsQueryable().OrderBy(property).ToList();
                    Console.WriteLine($"\nSorted by {property}:\n{string.Join("\n", sortedProducts)}");
                }
                else
                {
                    Console.WriteLine("Invalid Order By - Please Specify the ascending or descending");
                }
            }
            else
            {
                Console.WriteLine("Invalid Property - Please Specify in this (ProductPrice, ProductCategory, ProductName)");
            }
        }

        /// <summary>
        /// Find the second max in the array by the LINQ
        /// </summary>
        public static void SecondMaxInArray()
        {
            Random rand = new Random();
            int[] integerArray = Enumerable.Range(1, 100).OrderBy(i => rand.Next()).Take(35).ToArray();
            Console.WriteLine("\nInteger Array is \n[{0}]", string.Join(", ", integerArray));
            var result1 = integerArray.OrderByDescending(x => x).Select(x => x).Skip(1).FirstOrDefault();
            Console.WriteLine($"\nSecond Highest Number : {result1}");
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
                Console.WriteLine($"\nInvalid Input, Please Enter the Valid Number from {int.MinValue} to {int.MaxValue}\n");
            }
        }

        /// <summary>
        /// Filter the orders before the 30 days from now
        /// </summary>
        /// <param name="orders">List of the order data</param>
        public static void OrdersBefore30Days(List<Order> orders)
        {
            var recentOrders = orders.Where(order => order.OrderDate >= DateTime.Now.Date.AddDays(-30)).OrderByDescending(order => order.OrderID).Select(order => new { orderid = order.OrderID }).ToList();
            Console.WriteLine($"\nOrders before 30days :\n{string.Join(", ", recentOrders)}");
            var completedOrder = orders.Where(order => order.OrderStatus == true).ToList();
            Console.WriteLine($"\nCompleted Orders : {completedOrder.Count}");
        }

        /// <summary>
        /// Join Using Query Builder
        /// </summary>
        /// <param name="products">List of products data</param>
        /// <param name="suppliers">List of supplier data</param>
        public static void JoinUsingQueryBuilder(List<Product> products, List<Supplier> suppliers)
        {
            var result = new QueryBuilder<Product>(products).Filter(p => p.ProductPrice > 300)
                .SortBy(p => p.ProductPrice)
                .Join(suppliers, product => product.ProductId, supplier => supplier.SupplierId, (product, supplier) => new { product.ProductId, product.ProductName, supplier.SupplierName })
                .Execute();
            var enumeratorOfResult = result.GetEnumerator();
            while(enumeratorOfResult.MoveNext())
            {
                Console.WriteLine($"{enumeratorOfResult.Current.ProductId} : {enumeratorOfResult.Current.ProductName} : {enumeratorOfResult.Current.}");
            }
        }

        /// <summary>
        /// Filter the products belong to the book category
        /// </summary>
        /// <param name="products">List of the order data</param>
        public static void BookCategory(List<Product> products)
        {
            var productsOfBook = products.Where(order => order.ProductCategory == "Books").OrderByDescending(order => order.ProductPrice).Select(order => new { Id = order.ProductId, Name = order.ProductName, Price = order.ProductPrice });
            Console.WriteLine($"\nProducts in Book Category :\n{string.Join(", ", productsOfBook)}");
        }

        /// <summary>
        /// Filter the Products by using the lambda expression
        /// </summary>
        /// <param name="products">List of the product data</param>
        /// <param name="filter">lambda filter function</param>
        /// <returns>Filtered list of the product based on the lambda expression</returns>
        public static List<Product> FilterProducts(List<Product> products, Func<Product, bool> filter)
        {
            return products.Where(filter).ToList();
        }

        /// <summary>
        /// Clear the screen in the console
        /// </summary>
        public static void ClearScreen()
        {
            Console.WriteLine("\nPress Enter to Clear and Escape to continue");
            ConsoleKey consoleKey = Console.ReadKey(true).Key;
            if (consoleKey.Equals(ConsoleKey.Enter))
            {
                Console.Clear();
            }
            else if (consoleKey.Equals(ConsoleKey.Escape))
            {
                return;
            }
            else
            {
                Console.WriteLine("\nInvalid Key Please press the valid key");
                ClearScreen();
            }
        }

        /// <summary>
        /// Display all the list present in the program
        /// </summary>
        /// <param name="products">List of products data</param>
        /// <param name="orders">List of the orders data</param>
        /// <param name="suppliers">List of the suppliers data</param>
        public static void DisplayAll(List<Product> products, List<Order> orders, List<Supplier> suppliers)
        {
            Console.WriteLine($"\nProducts List:\n\n{string.Join("\n", products)}");
            Console.WriteLine($"\nOrders List:\n\n{string.Join("\n", orders)}");
            Console.WriteLine($"\nSupplier List:\n\n{string.Join("\n", suppliers)}");
        }
    }
}