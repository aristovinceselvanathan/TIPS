namespace MyMathLibrary
{
    using MathNet.Numerics;

    /// <summary>
    /// Program Class Library
    /// </summary>
    public class Program
    {
        /// <summary>
        /// To Calculate the Fibonacci Series from the given number
        /// </summary>
        /// <param name="fibonacciNumber">The number of Fibonacci series to be returned</param>
        /// <returns>List of the Fibonacci series</returns>
        public static List<int> CalculateFibonacci(int fibonacciNumber)
        {
            return Generate.FibonacciSequence().Take(fibonacciNumber).Select(number => (int)number).ToList();
        }
    }
}