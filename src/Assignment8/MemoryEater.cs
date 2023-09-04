namespace Assignment8
{
    /// <summary>
    /// Memory Eater Class
    /// </summary>
    public class MemoryEater
    {
        /// <summary>
        /// It will allocate the memory to the list
        /// </summary>
        public void Allocate()
        {
            int maxArrays = 100000;

            while (true)
            {
                List<int[]> memAlloc = new List<int[]>();
                try
                {
                    for (int i = 0; i < maxArrays; i++)
                    {
                        memAlloc.Add(new int[10000]);
                    }

                    // Before clear the data store it in database and clears the unreferenced data
                    memAlloc.Clear();
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine(e.Message);
                    GC.Collect();
                }

                // Assume memAlloc variable is used only within this loop.
                Thread.Sleep(10);
            }
        }
    }
}