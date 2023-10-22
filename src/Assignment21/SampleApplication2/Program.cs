namespace SampleApplication2
{
    using Assignment21;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program : ISampleInterface
    {
        /// <summary>
        /// Print the welcome message from the application
        /// </summary>
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome Message from the Application 2");
        }
    }
}