namespace Git
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that prints Hello World
        /// </summary>
        /// <param name="args">It takes the argument from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World..");
            Console.WriteLine("Practice Git in Visual Studio");
            Console.WriteLine("Hello Everyone");
            Hello welcome = new Hello();
            welcome.Print("Welcome");
            welcome.Print("Welcome to CSharp Language");
        }
    }
}