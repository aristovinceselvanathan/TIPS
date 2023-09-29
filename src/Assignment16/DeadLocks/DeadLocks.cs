namespace DeadLocks
{
    /// <summary>
    /// Deadlock Class it contain the deadlock method
    /// </summary>
    public class DeadLocks
    {
        /// <summary>
        /// DeadLock Method it will hold the thread until the value available
        /// </summary>
        /// <returns>Task to be awaited</returns>
        public async Task DeadlockMethod()
        {
            // Note: Do not use . Result or .Wait() in production code.
            var result = this.SomeAsyncOperation();
            await result;
            Console.WriteLine(result.Result);
        }

        /// <summary>
        /// SomeAsyncFunction it will introduce Task.Delay()
        /// </summary>
        /// <returns>Task contains Hello, World</returns>
        public async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(3000);
            return "Hello, World! ";
        }
    }
}