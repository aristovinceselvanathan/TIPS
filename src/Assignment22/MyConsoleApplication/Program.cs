namespace MyConsoleApplication
{
    using MyMathLibrary;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// To gnerate the fibonacci series
        /// </summary>
        /// <param name="args">String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcom to Fibonacci Series Generator\n");
            Console.Write("Enter the number of the Fibonacci series to be generated : ");
            if (int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= 47)
            {
                Console.WriteLine("Array is [{0}]", string.Join(",", MyMathLibrary.Program.CalculateFibonacci(result).ToArray()));
            }
            else
            {
                Console.WriteLine("Invalid number - Please enter number between 1 to 47");
            }
        }
    }
}