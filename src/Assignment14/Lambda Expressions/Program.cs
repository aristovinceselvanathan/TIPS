namespace Task4
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Method that filter the list by elements which are divisible by two and square all the elements in the list
        /// </summary>
        /// <param name="args">It takes the string argument from the command line interface</param>
        public static void Main(string[] args)
        {
            List<int> numberList = new ();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Welcome to filter the list by has only even number and square all the number present in list");
                Console.Write("Enter the size of the list : ");
                if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
                {
                    if (AddNumberToList(numberList, size))
                    {
                        Console.WriteLine("Exiting....");
                        break;
                    }

                    Console.WriteLine("Actual List");
                    DisplayTheList<int>(numberList.AsEnumerable().GetEnumerator());
                    Console.WriteLine();

                    var filteredList = numberList.Where(x => x % 2 == 0);
                    Console.WriteLine("All Elements which are divisible by two are : ");
                    DisplayTheList<int>(filteredList.GetEnumerator());
                    Console.WriteLine();

                    var squaredList = numberList.Select(x => Math.Pow(x, 2));
                    Console.WriteLine("All Elements are squared : ");
                    DisplayTheList<double>(squaredList.GetEnumerator());
                    Console.WriteLine();
                }
                else if (size <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid size");
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
        /// Method asks for the user to enter the elements into the list
        /// </summary>
        /// <param name="numberList">It is reference of the list from the main method</param>
        /// <param name="size">It takes the size of the list from the user</param>
        /// <returns>It returns bool to terminate the program</returns>
        public static bool AddNumberToList(List<int> numberList, int size)
        {
            for (int i = 0; i < size;)
            {
                Console.Write($"Enter the number in list at position {i + 1} : ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    numberList.Add(value);
                    i++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        return true;
                    }

                    Console.Clear();
                }
            }

            return false;
        }

        /// <summary>
        /// Method to display all the elements in the list
        /// </summary>
        /// <param name="numberList">It has the IEnumerator of the list</param>
        /// <typeparam name="T">Type of the IEnumerator</typeparam>
        public static void DisplayTheList<T>(IEnumerator<T> numberList)
        {
            Console.WriteLine("List is : ");
            while (numberList.MoveNext())
            {
                Console.Write($"{numberList.Current}, ");
            }

            Console.WriteLine();
        }
    }
}