namespace DelegatesForSorting
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// SortDelegate can hold the reference to the sorting method
    /// </summary>
    /// <param name="product1">Reference of the product1 to compare the details</param>
    /// <param name="product2">Reference of the product2 to compare the details</param>
    /// <returns>It returns the int as a result of compare methods in methods subscribe to it</returns>
    public delegate int SortDelegate(Product product1, Product product2);

    /// <summary>
    /// Program Class that contains the entry point for the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Method that will sort the list of person by name, category, price.
        /// </summary>
        /// <param name="args">It takes the string array from command line interface</param>
        public static void Main(string[] args)
        {
            List<Product> productsList = new List<Product>();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Welcome to Products Manager");
                Console.Write("Enter the size of the list : ");

                if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
                {
                    flag = AddElementToArray(productsList, size);

                    SortDelegate sortByName = SortByName;
                    SortDelegate sortByCategory = SortByCategory;
                    SortDelegate sortByPrice = SortByPrice;

                    Console.WriteLine("Sort By Name : ");
                    SortAndDisplay(sortByName, productsList);
                    Console.WriteLine("Sort By Category : ");
                    SortAndDisplay(sortByCategory, productsList);
                    Console.WriteLine("Sort By Price : ");
                    SortAndDisplay(sortByPrice, productsList);
                }
                else if (size <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Size");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    flag = false;
                }

                productsList.Clear();
                Console.Clear();
            }
        }

        /// <summary>
        /// Method asks for the user to enter the elements into the products list
        /// </summary>
        /// <param name="productsList">It is reference of the list from the main method</param>
        /// <param name="size">It takes the size of the list from the user</param>
        /// <returns>It returns status of the element added into the list</returns>
        public static bool AddElementToArray(List<Product> productsList, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Product productToBeCreated = new Product();
                productToBeCreated.Name = IsValidName(i);
                if (productToBeCreated.Name == null)
                {
                    return false;
                }

                productToBeCreated.Category = IsValidCategory(i);
                if (productToBeCreated.Category == null)
                {
                    return false;
                }

                productToBeCreated.Price = IsValidPrice(i);
                if (productToBeCreated.Price == null)
                {
                    return false;
                }

                productsList.Add(productToBeCreated);
            }

            return true;
        }

        /// <summary>
        /// Sort By Name of the products in the list
        /// </summary>
        /// <param name="product1">Reference of the product1 to compare</param>
        /// <param name="product2">Reference of the product2 to compare</param>
        /// <returns>It will return integer to sort the list by comparing the two strings using compare</returns>
        public static int SortByName(Product product1, Product product2)
        {
              return string.Compare(product1.Name, product2.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Sort By Category of the products in the list
        /// </summary>
        /// <param name="product1">Reference of the product1 to compare</param>
        /// <param name="product2">Reference of the product2 to compare</param>
        /// <returns>It will return integer to sort the list by comparing the two strings using compare</returns>
        public static int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Sort By Price of the Product
        /// </summary>
        /// <param name="product1">Reference of the product1 to compare</param>
        /// <param name="product2">Reference of the product2 to compare</param>
        /// <returns>It will return integer to sort the list by comparing the two decimal using compare</returns>
        public static int SortByPrice(Product product1, Product product2)
        {
                return decimal.Compare((decimal)product1.Price, (decimal)product2.Price);
        }

        /// <summary>
        /// It will use the sort delegate to invoke the method to sort the list and display it using the iterator
        /// </summary>
        /// <param name="sortMethod">It will invoke the sort method that are subscribed to the delegate</param>
        /// <param name="productsList">Reference of the list of the products from the main method</param>
        public static void SortAndDisplay(SortDelegate sortMethod, List<Product> productsList)
        {
            productsList.Sort((product1, product2) => sortMethod(product1, product2));
            foreach (Product product in productsList)
            {
                Console.WriteLine($"{product}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Method is to validate name of the product
        /// </summary>
        /// <param name="indexOfArray">It gets the current index of the list</param>
        /// <returns>It returns valid name of the product</returns>
        public static string IsValidName(int indexOfArray)
        {
            Console.Write($"Enter the Name of the Product at {indexOfArray + 1}: ");
            string name = Console.ReadLine();
            Regex pattern = new Regex("^[a-zA-Z\\s]+$");
            if (pattern.IsMatch(name))
            {
                return name;
            }
            else
            {
                Console.WriteLine("Invalid Name");
                Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return null;
                }

                Console.Clear();
                return IsValidName(indexOfArray);
            }
        }

        /// <summary>
        /// Method is to validate category of the product
        /// </summary>
        /// <param name="indexOfArray">It gets the current index of the list</param>
        /// <returns>It returns valid category of the product</returns>
        public static string IsValidCategory(int indexOfArray)
        {
            Console.Write($"Enter the Category of the Product at {indexOfArray + 1}: ");
            string category = Console.ReadLine();
            List<string> categories = new List<string> { "home", "fashion", "medicines", "food", "electronics", "grocery", "furniture", "toy" };
            if (categories.Contains(category.ToLower()))
            {
                return category;
            }
            else
            {
                Console.WriteLine("Invalid Category - Select from this category home, fashion, medicines, food, electronics, grocery, furniture, toy");
                Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return null;
                }

                Console.Clear();
                return IsValidCategory(indexOfArray);
            }
        }

        /// <summary>
        /// Method is to validate price of the product
        /// </summary>
        /// <param name="indexOfArray">It gets the current index of the list</param>
        /// <returns>It returns valid price of the product</returns>
        public static decimal? IsValidPrice(int indexOfArray)
        {
            Console.Write($"Enter the Price of the Product at {indexOfArray + 1}: ");
            string priceOfProduct = Console.ReadLine();
            if (decimal.TryParse(priceOfProduct, out decimal valueOfProduct) && valueOfProduct > 0)
            {
                return valueOfProduct;
            }
            else
            {
                Console.WriteLine("Invalid Price");
                Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return null;
                }

                Console.Clear();
                return IsValidPrice(indexOfArray);
            }
        }
    }
}