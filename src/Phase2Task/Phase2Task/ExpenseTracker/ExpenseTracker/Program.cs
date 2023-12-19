namespace ExpenseTracker
{
    /// <summary>
    /// Program Class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// To Run the user interface.
        /// </summary>
        /// <param name="args">It is string array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            FileOperation<Income> fileOperation = new FileOperation<Income>();
            userInterface.StartUserInterface();
            Console.Clear();
        }
    }
}