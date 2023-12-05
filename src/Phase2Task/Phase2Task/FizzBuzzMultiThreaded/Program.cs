namespace FizzBuzzMultiThreaded
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// It creates the thread for each methods in the fizzBuzz class
        /// </summary>
        /// <param name="args">It is string array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            Console.Write("Enter the N Value : ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.Write("[");
                FizzBuzz fizzBuzz = new FizzBuzz(number);
                List<Thread> threads = new List<Thread>() {
                new Thread(x => fizzBuzz.Fizz(printFizz)),
                new Thread(x => fizzBuzz.Buzz(printBuzz)),
                new Thread(x => fizzBuzz.Fizzbuzz(printFizzBuzz)),
                new Thread(x => fizzBuzz.Number(printNumber)),
                };

                threads.ForEach(x => x.Start());
                threads.ForEach(x => x.Join());
                Console.Write("]");
            }
            else
            {
                Console.WriteLine("Invalid Input Value");
            }
        }
        /// <summary>
        /// To Print Fizz in the Console
        /// </summary>
        public static void printFizz()
        {
            Console.Write("Fizz, ");
        }
        /// <summary>
        /// To Print Buzz in the Console
        /// </summary>
        public static void printBuzz()
        {
            Console.Write("Buzz, ");
        }
        /// <summary>
        /// To Print FizzBuzz in the Console
        /// </summary>
        public static void printFizzBuzz()
        {
            Console.Write("FizzBuzz, ");
        }
        /// <summary>
        /// To Print Number in the Console
        /// </summary>
        public static void printNumber(int number)
        {
            Console.Write($"{number}, ");
        }
    }
}