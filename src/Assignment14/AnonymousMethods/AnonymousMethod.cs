namespace AnonymousMethods
{
    /// <summary>
    /// It is AnonymousMethod Class
    /// </summary>
    public class AnonymousMethod
    {
        /// <summary>
        /// It sorts the integer array by the delegate that invoke the method
        /// </summary>
        /// <param name="arrayOfNumber">It is reference of the array from the main method</param>
        public void SortByUsingDelegate(int[] arrayOfNumber)
        {
            Array.Sort(arrayOfNumber, delegate (int x, int y) { return x.CompareTo(y); });
        }
        /// <summary>
        /// Method asks for the user to enter the elements into the array
        /// </summary>
        /// <param name="arrayOfNumber">It is reference of the array from the main method</param>
        public void AddElementToArray(int[] arrayOfNumber)
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
        public void DisplayTheArray(int[] arrayOfNumber)
        {
            for (int i = 0; i < arrayOfNumber.Length; i++)
            {
                Console.Write($"{arrayOfNumber[i]}, ");
            }

            Console.WriteLine();
        }
    }
}
