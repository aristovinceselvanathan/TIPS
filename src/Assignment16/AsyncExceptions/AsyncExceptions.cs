namespace AsyncExceptions
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program it contains the entry point of the program
    /// </summary>
    public class AsyncExceptions
    {
        private enum Option
        {
            VoidMethod = 1,
            TaskMethod = 2,
            Exit = 3,
        }

        /// <summary>
        /// Main Method it asks for the user choose the void async or task async method to throw exception and catch it.
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            Regex pattern = new Regex("\\d");

            while (flag)
            {
                Console.Write("Enter the Choice : 1-VoidMethod 2-TaskMethod 3-Exit : ");
                string userEnteredInput = Console.ReadLine();

                if (int.TryParse(userEnteredInput, out int userInputValue))
                {
                    Option option = (Option)userInputValue;
                    switch (option)
                    {
                        case Option.VoidMethod:
                            try
                            {
                                VoidMethod();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\nException Caught for Void Method");
                            }

                            break;
                        case Option.TaskMethod:
                            try
                            {
                                TaskMethod();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\nException Caught for Task Method");
                            }

                            break;
                        case Option.Exit:
                            Console.WriteLine("\nExiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
                else if (pattern.IsMatch(userEnteredInput))
                {
                    Console.WriteLine($"Enter the number in the range of the {int.MinValue} to {int.MaxValue}");
                }
                else
                {
                    Console.WriteLine("\nInvalid Input");
                }

                Console.WriteLine("\nPress Escape to Clear, Press Enter to Continue");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// It raise the exception in this method
        /// </summary>
        public static async void VoidMethod()
        {
            throw new Exception("\nNew Void Exception");
        }

        /// <summary>
        /// It raise the exception in this method
        /// </summary>
        /// <returns>Task</returns>
        public static async Task TaskMethod()
        {
            throw new Exception("\nNew Task Exception");
        }
    }
}