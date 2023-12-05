namespace ZeroEvenOdd
{
    /// <summary>
    /// Program class it contains the entry point of the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Creates the thread for each method in the ZeroEvenOdd Class and Started all the Threads
        /// </summary>
        /// <param name="args">It is the string array in the parameters of the main method</param>
        static void Main(string[] args)
        {
            Console.Write("Enter the number : ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                ZeroEvenOdd zeroEvenOdd = new ZeroEvenOdd(n);
                Console.Write("Output : ");
                List<Thread> threads = new List<Thread>()
                {
                new Thread(x => zeroEvenOdd.Zero(printNumber)),
                new Thread(x => zeroEvenOdd.Even(printNumber)),
                new Thread(x => zeroEvenOdd.Odd(printNumber)),
                };
                threads.ForEach(x => x.Start());  
                threads.ForEach(x => x.Join());
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
        }

        /// <summary>
        /// Print the number in the console
        /// </summary>
        /// <param name="number">Number to be printed</param>
        static void printNumber(int number)
        {
            Console.Write($"{number}");
        }
    }
}
