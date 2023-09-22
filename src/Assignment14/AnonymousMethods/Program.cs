namespace Task3
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Method to sort the array by the anonymous function by using the delegate
        /// </summary>
        /// <param name="args">It takes the string argument from Command Line Interface</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Sort the integer in the ascending order");
                Console.Write("Enter the length of the array : ");
                if (int.TryParse(Console.ReadLine(), out int size))
                {
                    int[] arrayOfNumber = new int[size];
                    AddElementToArray(arrayOfNumber);
                    Console.WriteLine("Sorted Array : ");
                    Array.Sort(arrayOfNumber, delegate(int x, int y) { return x.CompareTo(y); });
                    DisplayTheArray(arrayOfNumber);
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
        /// Method asks for the user to enter the elements into the array
        /// </summary>
        /// <param name="arrayOfNumber">It is reference of the array from the main method</param>
        public static void AddElementToArray(int[] arrayOfNumber)
        {
            for (int i = 0; i < arrayOfNumber.Length;)
            {
                Console.Write($"Enter the number into the array at position {i + 1} : ");
                if (int.TryParse(Console.ReadLine(), out arrayOfNumber[i]))
                {
                    Console.WriteLine("Value added successfully");
                    i++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        /// <summary>
        /// Method to display all the elements in the list
        /// </summary>
        /// <param name="arrayOfNumber">It is reference of the list from the main method</param>
        public static void DisplayTheArray(int[] arrayOfNumber)
        {
            Console.WriteLine("List is : ");
            for (int i = 0; i < arrayOfNumber.Length; i++)
            {
                Console.Write($"{arrayOfNumber[i]}, ");
            }

            Console.WriteLine();
        }
    }
}