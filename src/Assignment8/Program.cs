namespace Assignment8
{
    /// <summary>
    /// Program Class contains the entry point of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method it will create the object and call the allocate method in the MemoryEater Class
        /// </summary>
        /// <param name="args">It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
        }
    }
}