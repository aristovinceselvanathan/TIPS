namespace GarbageCollection
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method calls the method that creates the number of objects;
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Create multiple objects");
            CreateNumberOfObjects();
            Console.WriteLine("Press any key to End : ");
            Console.ReadKey();
        }

        /// <summary>
        /// It creates the number of objects
        /// </summary>
        public static void CreateNumberOfObjects()
        {
            for (int i = 0; i < 10000000; i++)
            {
                var account = new Account();
                if (i % 1000000 == 0)
                {
                    Console.WriteLine($"Memory used : {GC.GetTotalMemory(false)} bytes");  // Retrieves the heap size excluding fragmentation.
                }
            }

            Console.WriteLine("Press any key to clear using Garbage Collection");
            Console.ReadKey();

            GC.Collect();                  // It will call garbage collector forcefully

            Console.WriteLine("Wait After the Garbage Collection is triggered, Press any key to continue");
            Console.WriteLine($"Memory used : {GC.GetTotalMemory(false)} bytes");
            Console.ReadKey();
        }
    }
}