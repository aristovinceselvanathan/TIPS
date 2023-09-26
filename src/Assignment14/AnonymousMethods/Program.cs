namespace AnonymousMethod
{
    /// <summary>
    /// Program Class it contains the entry point of the Program
    /// </summary>
    public class Program
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

                if (int.TryParse(Console.ReadLine(), out int sizeOfArray))
                {
                    int[] arrayOfNumber = new int[sizeOfArray];
                    AddElementToArray(arrayOfNumber);
                    Console.WriteLine("\nSorted Array : ");
                    SortByUsingDelegate(arrayOfNumber);
                    DisplayTheArray(arrayOfNumber);
                }
                else if (sizeOfArray <= 0)
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
        /// It sorts the integer array by the delegate that invoke the method
        /// </summary>
        /// <param name="arrayOfNumber">It is reference of the array from the main method</param>
        public static void SortByUsingDelegate(int[] arrayOfNumber)
        {
            Array.Sort(arrayOfNumber, delegate (int x, int y) { return x.CompareTo(y); });
        }

        /// <summary>
        /// Method asks for the user to enter the elements into the array
        /// </summary>
        /// <param name="arrayOfNumber">It is reference of the array from the main method</param>
        public static void AddElementToArray(int[] arrayOfNumber)
        {
            for (int i = 0; i < arrayOfNumber.Length;)
            {
                Console.Write($"Enter the number add it into array at position {i + 1} : ");
                if (int.TryParse(Console.ReadLine(), out arrayOfNumber[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Value added successfully");
                    Console.ForegroundColor = ConsoleColor.White;
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
        /// <param name="arrayOfNumber">It is reference of the array from the main method</param>
        public static void DisplayTheArray(int[] arrayOfNumber)
        {
            for (int i = 0; i < arrayOfNumber.Length; i++)
            {
                Console.Write($"{arrayOfNumber[i]}, ");
            }

            Console.WriteLine();
        }
    }
}