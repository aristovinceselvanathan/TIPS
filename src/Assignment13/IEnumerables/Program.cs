namespace IEnumerable
{
    /// <summary>
    /// Program CLass that contains the entry point of program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method that creates the list and store the numbers in the list
        /// </summary>
        /// <param name="args">It takes the string array from the Command Line Interface</param>
        public static void Main(string[] args)
        {
            List<int> numberList = new List<int>();
            int sizeOfNumberList;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Find the sum of all elements in the List");
                Console.Write("Enter the Size of the List : ");
                if (int.TryParse(Console.ReadLine(), out sizeOfNumberList))
                {
                    flag = AddElements(numberList, sizeOfNumberList);
                }
                else
                {
                    Console.WriteLine("Invalid Input, Press Esc key to Exit, Any Other key to Continue");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Exiting....");
                        flag = false;
                    }
                }

                Console.Clear();
                if (!flag)
                {
                    Console.WriteLine("Exiting....");
                }
            }
        }

        /// <summary>
        /// It performs the addition of all the elements present in the list
        /// </summary>
        /// <param name="numberListAsEnumerable">It takes the list of the number as enumerable</param>
        /// <returns>It returns sum of all the elements in enumerable</returns>
        public static int SumOfElements(IEnumerable<int> numberListAsEnumerable)
        {
            int sum = 0;
            foreach (int element in numberListAsEnumerable)
            {
                sum += element;
            }

            return sum;
        }

        /// <summary>
        /// Method adds the number to the list by asking the user
        /// </summary>
        /// <param name="numberList">It takes the reference of the numberList from the main method</param>
        /// <param name="sizeOfNumberList">it takes the size of the numberList</param>
        /// <returns>It returns the bool that tells to terminate the program</returns
        public static bool AddElements(List<int> numberList, int sizeOfNumberList)
        {
            for (int i = 0; i < sizeOfNumberList;)
            {
                Console.Write($"Enter the number at position {i} : ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    numberList.Add(value);
                    i++;
                }
                else
                {
                    Console.Write("Invalid Input, Press Esc key to Exit, Any Other key to Continue");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Exiting....");
                        return false;
                    }
                }
            }

            if (sizeOfNumberList == numberList.Count)
            {
                Console.WriteLine($"Sum of the List : {SumOfElements(numberList.AsEnumerable())}");
            }

            return true;
        }
    }
}