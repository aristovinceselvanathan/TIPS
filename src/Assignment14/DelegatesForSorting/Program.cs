namespace Task5
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
    /// Program Class
    /// </summary>
    internal class Program
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
                Console.WriteLine("Enter the size of the list : ");
                if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
                {
                    flag = AddElementToArray(productsList, size);

                    SortDelegate sort1 = SortByName;
                    SortDelegate sort2 = SortByCategory;
                    SortDelegate sort3 = SortByPrice;

                    Console.WriteLine("Sort By Name : ");
                    SortAndDisplay(sort1, productsList);
                    Console.WriteLine("Sort By Category : ");
                    SortAndDisplay(sort2, productsList);
                    Console.WriteLine("Sort By Price : ");
                    SortAndDisplay(sort3, productsList);
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

                Console.Clear();
            }
        }

        /// <summary>
        /// Method asks for the user to enter the elements into the products list
        /// </summary>
        /// <param name="productsList">It is reference of the list from the main method</param>
        /// <param name="size">It takes the size of the list from the user</param>
        /// <returns>It returns bool to break the loop</returns>
        public static bool AddElementToArray(List<Product> productsList, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Product temp = new Product();
                temp.Name = IsValidName(i);
                if (temp.Name == null)
                {
                    return false;
                }

                temp.Category = IsValidCategory(i);
                if (temp.Category == null)
                {
                    return false;
                }

                temp.Price = IsValidPrice(i);
                if (temp.Price == null)
                {
                    return false;
                }

                productsList.Add(temp);
            }

            return true;
        }

        /// <summary>
        /// Sort By Name
        /// </summary>
        /// <param name="product1">Product a</param>
        /// <param name="product2">Product b</param>
        /// <returns>int</returns>
        public static int SortByName(Product product1, Product product2)
        {
              return string.Compare(product1.Name, product2.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Sort By Category
        /// </summary>
        /// <param name="product1">Product a</param>
        /// <param name="product2">Product b</param>
        /// <returns>int</returns>
        public static int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Sort By Price
        /// </summary>
        /// <param name="product1">Product a</param>
        /// <param name="product2">Product b</param>
        /// <returns>int</returns>
        public static int SortByPrice(Product product1, Product product2)
        {
                return decimal.Compare((decimal)product1.Price, (decimal)product2.Price);
        }

        /// <summary>
        /// sort and display
        /// </summary>
        /// <param name="sortMethod">delegate</param>
        /// <param name="products">list</param>
        public static void SortAndDisplay(SortDelegate sortMethod, List<Product> products)
        {
            products.Sort((product1, product2) => sortMethod(product1, product2));
            foreach (Product product in products)
            {
                Console.Write($"{product}, ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Method is to validate name
        /// </summary>
        /// <param name="index">It gets the current index of the list</param>
        /// <returns>It returns valid name of the product</returns>
        public static string IsValidName(int index)
        {
            Console.WriteLine($"Enter the Name of Element at {index + 1}: ");
            string name = Console.ReadLine();
            Regex pattern = new Regex("^[a-zA-Z\\s]*$");
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
                return IsValidName(index);
            }
        }

        /// <summary>
        /// Method is to validate category
        /// </summary>
        /// <param name="index">It gets the current index of the list</param>
        /// <returns>It returns valid category of the product</returns>
        public static string IsValidCategory(int index)
        {
            Console.WriteLine($"Enter the Category of Element at {index + 1}: ");
            string category = Console.ReadLine();
            List<string> categories = new List<string> { "home", "fashion", "medicines", "food", "electronics", "grocery", "furniture", "toys" };
            if (categories.Contains(category.ToLower()))
            {
                return category;
            }
            else
            {
                Console.WriteLine("Invalid Category");
                Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return null;
                }

                Console.Clear();
                return IsValidCategory(index);
            }
        }

        /// <summary>
        /// Method is to validate price
        /// </summary>
        /// <param name="index">It gets the current index of the list</param>
        /// <returns>It returns valid price of the product</returns>
        public static decimal? IsValidPrice(int index)
        {
            Console.WriteLine($"Enter the Price of Element at {index + 1}: ");
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
                return IsValidPrice(index);
            }
        }
    }
}