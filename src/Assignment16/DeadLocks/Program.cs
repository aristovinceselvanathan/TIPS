namespace DeadLocks
{
    /// <summary>
    /// Program Class it contains the entry point of the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// It main to call the deadlock method inDeadLock Class
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        /// <returns> <see cref="Task"/>Representing the asynchronous operation</returns>
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DeadLocks deadLocks = new DeadLocks();
            var x = deadLocks.DeadlockMethod();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Main Method is Running..");
            Console.ForegroundColor = ConsoleColor.White;
            await x;
        }
    }
}