namespace Task1
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Method CatchEvent Subscribe to delegate
        /// </summary>
        /// <param name="message">It takes the message to print it</param>
        public static void CatchEvent(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Method will subscribe the catch method to the OnAction Event
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            Console.WriteLine("Before Subscribe to the Method");
            notifier.Action("Event Calling");
            notifier.OnAction += CatchEvent;
            Console.WriteLine("After Subscribe to the Method");
            notifier.Action("Event Calling");
        }
    }
}