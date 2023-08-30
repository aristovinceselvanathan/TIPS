namespace GarbageCollection
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method creates the number of objects;
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Create multiple objects");
            Program userInterface = new Program();
            userInterface.CreateNumberofObjects();
            Console.WriteLine("Press any key to End : ");
            Console.ReadKey();
        }

        /// <summary>
        /// It creates the number of objects
        /// </summary>
        public void CreateNumberofObjects()
        {
            for (int i = 0; i < 1000000000; i++)
            {
                var account = new Account();
                account = null;
                GC.Collect();
            }

            Console.WriteLine("Clear using Garbage Colletion, Press any key to continue");
            Console.ReadKey();
            GC.Collect();
        }
    }
}