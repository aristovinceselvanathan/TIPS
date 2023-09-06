namespace ErrorHandling
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            DivideByZero = 1,
            IndexOutOfRange = 2,
            UnHandledException = 3,
        }

        /// <summary>
        /// Main method asks for the type of the exception wanted to create.
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            int[] array = new int[10];
            int input;
            Options option;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
            Console.WriteLine("Welcome to Error Handling");
            Console.Write("Choose which error wanted to raise 1.Divide By Zero, 2.Index Out of Range, 3.UnHandled Exception : ");
            if (int.TryParse(Console.ReadLine(), out input))
            {
                option = (Options)input;
                switch (option)
                {
                    case Options.DivideByZero:
                        DivideByZero(array);
                        break;
                    case Options.IndexOutOfRange:
                        IndexOutOfBound(array);
                        break;
                    case Options.UnHandledException:
                        throw new Exception("This is Unhandled Exception");
                    default:
                        WarningMessage("Invalid Option");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                try
                {
                    throw new InvalidUserInputException("Invalid User Input - Required Number");
                }
                catch (InvalidUserInputException exception)
                {
                    WarningMessage(exception.Message);
                }
            }
        }

        /// <summary>
        /// It shows the warning message color to red when exception is thrown
        /// </summary>
        /// <param name="message">It takes the type of the exception message</param>
        public static void WarningMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Error!!!, {message}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Event handler for handling unhandled exceptions in the application.
        /// </summary>
        /// <param name="sender">The object that raised the event (usually the current AppDomain).</param>
        /// <param name="unHandledException">An UnhandledExceptionEventArgs object containing information about the unhandled exception.</param>
        public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs unHandledException)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Exception exception = (Exception)unHandledException.ExceptionObject;
            Console.Write("Unhandled Exception caught by the AppDomain, Message is ");
            Console.WriteLine(exception.Message);
            Console.WriteLine("IsTerminating: " + unHandledException.IsTerminating);
            Console.WriteLine("Stack Trace");
            Console.WriteLine(exception.StackTrace);
        }

        /// <summary>
        /// It creates the DivideByZeroException
        /// </summary>
        /// <param name="array">It takes the array to perform calculation</param>
        public static void DivideByZero(int[] array)
        {
            int result;
            try
            {
                result = 10 / array[0];
            }
            catch (DivideByZeroException)
            {
                WarningMessage("Number is Divided by Zero");
            }
            finally
            {
                Console.WriteLine("Finally Block Executed");
            }
        }

        /// <summary>
        /// It creates the IndexOutOfBoundException
        /// </summary>
        /// <param name="array">It takes the array to perform array calculation</param>
        public static void IndexOutOfBound(int[] array)
        {
            try
            {
                try
                {
                    for (int i = 0; i < array.Length + 1; i++)
                    {
                        array[i] = i;
                    }

                    array[0] = array[1] / array[0];
                }
                catch (DivideByZeroException)
                {
                    WarningMessage("Number is divided by zero");
                }
                catch (IndexOutOfRangeException)
                {
                    throw new Exception("Array index is out of bounds");
                }
                finally
                {
                    Console.WriteLine("Finally Block Executed");
                }
            }
            catch (Exception exception)
            {
                WarningMessage(exception.Message);
            }
            finally
            {
                Console.WriteLine("Finally Block Executed");
            }
        }
    }
}