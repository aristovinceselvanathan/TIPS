namespace DataAcquisitionSystem
{
    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Mains the.
        /// </summary>
        /// <param name="args">The args.</param>
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            userInterface.StartUserInterface();
        }
    }
}