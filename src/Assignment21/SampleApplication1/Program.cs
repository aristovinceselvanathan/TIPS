namespace SampleApplication1
{
    using Assignment21;
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program : ISampleInterface
    {
        /// <summary>
        /// Print the Welcome Message
        /// </summary>
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome message from application 1");
        }
    }
}