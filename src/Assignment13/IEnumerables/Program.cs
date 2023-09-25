namespace IEnumerable
{
    /// <summary>
    /// Program Class that contains the entry point of program
    /// </summary>
    public class Program
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
                    for (int i = 0; i < sizeOfNumberList; i++)
                    {
                        Console.Write($"Enter the Number at index {i} : ");
                        if (int.TryParse(Console.ReadLine(), out int value))
                        {
                            flag = AddElements(numberList, value);
                            if (sizeOfNumberList == numberList.Count)
                            {
                                Console.WriteLine($"Sum of the List : {SumOfElements(numberList.AsEnumerable())}");
                            }
                        }
                        else
                        {
                            Console.Write("Invalid Input, Press Esc key to Exit, Any Other key to Continue");
                            if (Console.ReadKey(false).Key == ConsoleKey.Escape)
                            {
                                Console.WriteLine("Exiting....");
                                flag = false;
                            }

                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input, Press Esc key to Exit, Any Other key to Continue");
                    if (Console.ReadKey(false).Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Exiting....");
                        flag = false;
                    }
                }

                if (!flag)
                {
                    Console.WriteLine("Exiting....");
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// It performs the addition of all the elements present in the list
        /// </summary>
        /// <param name="numberListAsEnumerable">It takes the list of the number as enumerable</param>
        /// <returns>It returns sum of all the elements in IEnumerable</returns>
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
        /// Method adds the number to the list by calling it
        /// </summary>
        /// <param name="numberList">It takes the reference of the numberList from the main method</param>
        /// <param name="value">it takes the value to be added into list</param>
        /// <returns>It returns the bool that tells to status of the add number into the list</returns
        public static bool AddElements(List<int> numberList, int value)
        {
            numberList.Add(value);
            return true;
        }
    }
}