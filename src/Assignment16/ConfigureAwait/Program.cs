namespace ConfigureAwait
{
    /// <summary>
    /// Program Class it contains the entry point of thr program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method it will call the MethodB and await the for the task
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        /// <returns> <see cref="Task"/>Representing the asynchronous operation</returns>
        public static async Task Main(string[] args)
        {
            var taskResult = await MethodB();
            Console.WriteLine($"\nValue is : {taskResult}");
        }

        /// <summary>
        /// It run the CPU-bound Task for 5 seconds and returns 45
        /// </summary>
        /// <returns>Task contains the 45</returns>
        public static async Task<int> MethodA()
        {
            // Simulate a CPU-bound operation
            Task task = Task.Delay(5000);
            Console.Out.WriteLine($"\nThread Id : {Thread.CurrentThread.ManagedThreadId}");
            await task.ConfigureAwait(false);
            Console.Out.WriteLine($"\nThread Id : {Thread.CurrentThread.ManagedThreadId}");
            return 45;
        }

        /// <summary>
        /// It run the CPU-bound Task for 3 seconds and returns 49
        /// </summary>
        /// <returns>Task contains the result</returns>
        public static async Task<int> MethodB()
        {
            var task = MethodA();
            await task;
            return task.Result + 45;
        }
    }
}