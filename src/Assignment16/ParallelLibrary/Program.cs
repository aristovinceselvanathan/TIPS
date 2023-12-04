namespace ParallelLibrary
{
    using System.Diagnostics;

    /// <summary>
    /// Program Class contains the entry point of the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Method will define the integer and print in sequentially and parallelly to print the square number
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            double timerOfParallelTask, timerOfSequentialTask;
            int[] numberArray = new int[10000];

            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = i + 1;
            }

            timerOfParallelTask = PrintInParallel(numberArray);
            timerOfSequentialTask = PrintInSequential(numberArray);

            Console.WriteLine($"\nSequentially Executed Time : {timerOfParallelTask}");
            Console.WriteLine($"Parallelly Executed Time : {timerOfSequentialTask}");
            Console.WriteLine($"Time Difference of Performance: {Math.Round(timerOfParallelTask - timerOfSequentialTask, 2)}");
        }

        /// <summary>
        /// It will print the square of the element present in integer array
        /// </summary>
        /// <param name="numberArray">Number array from the main method</param>
        /// <returns>It total time to execute the task parallelly</returns>
        public static double PrintInParallel(int[] numberArray)
        {
            Console.WriteLine("\nExecuting in Parallel...\n");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.ForEach(numberArray, (i) =>
            {
                Console.Write($"{i * i}, ");
            });

            return Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
        }

        /// <summary>
        /// It will print the square of the element present in integer array
        /// </summary>
        /// <param name="numberArray">Number array from the main method</param>
        /// <returns>It total time to execute the task sequentially</returns>
        public static double PrintInSequential(int[] numberArray)
        {
            Console.WriteLine("\nExecuting in Sequential...\n");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (int i in numberArray)
            {
                Console.Write($"{i * i}, ");
            }

            return Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
        }
    }
}