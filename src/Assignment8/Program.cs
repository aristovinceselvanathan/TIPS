namespace Assignment8
{
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