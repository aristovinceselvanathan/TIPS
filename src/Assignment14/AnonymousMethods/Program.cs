namespace AnonymousMethods
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
            AnonymousMethod anonymousMethod = new AnonymousMethod();

            while (flag)
            {
                Console.WriteLine("Sort the integer in the ascending order");
                Console.Write("Enter the length of the array : ");

                if (int.TryParse(Console.ReadLine(), out int sizeOfArray))
                {
                    int[] arrayOfNumber = new int[sizeOfArray];
                    anonymousMethod.AddElementToArray(arrayOfNumber);
                    Console.WriteLine("\nSorted Array : ");
                    anonymousMethod.SortByUsingDelegate(arrayOfNumber);
                    anonymousMethod.PrintTheArrayInConsole(arrayOfNumber);
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
    }
}