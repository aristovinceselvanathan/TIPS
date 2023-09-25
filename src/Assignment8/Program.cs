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
        /// <param name="strings">It takes the string array from the command line interface</param>
        public static void Main(string[] strings)
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
        }
    }
}