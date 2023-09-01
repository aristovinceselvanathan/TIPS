namespace Assignment8
{
    /// <summary>
    /// Memory Eater Class
    /// </summary>
    public class MemoryEater
    {
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// It will allocate the memory to the list
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                try
                {
                    _memAlloc.Add(new int[10000000]);
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine(e.Message);
                    _memAlloc.Clear();
                }

                // Assume memA110c variable is used only within this loop.
                Thread.Sleep(10);
            }
        }
    }

    /// <summary>
    /// Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="strings">It takes the string array from the command line interface</param>
        public static void Main(string[] strings)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
        }
    }
}