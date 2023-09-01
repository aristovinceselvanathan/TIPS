namespace ErrorHandling
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that divides the number by zero.
        /// </summary>
        /// <param name="args">it takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            int[] array = new int[10];
            try
            {
                for (int i = 0; i < array.Length + 1; i++)
                {
                    array[i] = i;
                }
            }
            catch (DivideByZeroException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Error!!!, Number is Divided by Zero");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            catch (IndexOutOfRangeException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Error!!!, Array index is out of bounds");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            finally
            {
                Console.WriteLine("Finally Block Executed");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// It is exception class to handle the invalid user
    /// </summary>
    internal class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        public InvalidUserInputException()
        { 

        }

        public InvalidUserInputException(string userName) : base($"Invalid User Input {userName}");
        {

        }
    }
}