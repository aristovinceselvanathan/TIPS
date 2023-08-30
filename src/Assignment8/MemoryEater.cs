namespace Assignment8
{
    /// <summary>
    /// Memory Eater Class
    /// </summary>
    public class MemoryEater
    {
        private List<int[]> _memA110c = new List<int[]>();

        /// <summary>
        /// It will allocate the memory to the list
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                _memA110c.Add(new int[1000]);

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