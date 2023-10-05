namespace ErrorHandling
{
    /// <summary>
    /// Program Class it contains the entry point of the program
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            DivideByZero = 1,
            IndexOutOfRange = 2,
            UnHandledException = 3,
            Exit = 4,
        }

        /// <summary>
        /// Main method asks the user for the type of the exception wanted to raise.
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            int userSelectedOption;
            Options option;
            bool flag = true;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
            while (flag)
            {
                Console.WriteLine("Welcome to Error Handling\n");
                Console.Write("Choose which Operation to be Performed\n\n1-Divide 2-Access the Array 3-UnHandled Exception 4-Exit: ");
                if (int.TryParse(Console.ReadLine(), out userSelectedOption))
                {
                    option = (Options)userSelectedOption;
                    switch (option)
                    {
                        case Options.DivideByZero:
                            DivideByZero();
                            break;
                        case Options.IndexOutOfRange:
                            IndexOutOfBound(array);
                            break;
                        case Options.UnHandledException:
                            throw new Exception("\nThis is Unhandled Exception");
                        case Options.Exit:
                            Console.WriteLine("\nExiting...");
                            flag = false;
                            break;
                        default:
                            WarningMessage("\nInvalid Option");
                            break;
                    }
                }
                else
                {
                    try
                    {
                        throw new InvalidUserInputException("\nInvalid User Input - Required Number");
                    }
                    catch (InvalidUserInputException exception)
                    {
                        WarningMessage(exception.Message);
                    }
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// It shows the warning message color to red when exception is thrown
        /// </summary>
        /// <param name="message">Message of the exception to be printed</param>
        public static void WarningMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\nError!!!, {message}");
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
            Console.Write("\nUnhandled Exception caught by the AppDomain, Message is ");
            Console.WriteLine(exception.Message);
            Console.WriteLine("IsTerminating: " + unHandledException.IsTerminating);
            Console.WriteLine("Stack Trace");
            Console.WriteLine(exception.StackTrace);
        }

        /// <summary>
        /// It creates the DivideByZeroException by dividing the number with array index of 0.
        /// </summary>
        public static void DivideByZero()
        {
            int result;
            Console.Write("\nEnter the Operator 1 : ");
            if (int.TryParse(Console.ReadLine(), out int operand1))
            {
                Console.Write("\nEnter the Operator 2 : ");
                if (int.TryParse(Console.ReadLine(), out int operand2))
                {
                    try
                    {
                        result = operand1 / operand2;
                        Console.WriteLine(result);
                    }
                    catch (DivideByZeroException)
                    {
                        WarningMessage("\nNumber is Divided by Zero");
                    }
                    finally
                    {
                        Console.WriteLine("\nFinally Block Executed");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid Operand 2");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Operand 1");
            }
        }

        /// <summary>
        /// It creates the IndexOutOfBoundException when the accessing the array element out of index in the for loop
        /// </summary>
        /// <param name="array">Number array to perform array calculation</param>
        public static void IndexOutOfBound(int[] array)
        {
            int sum = 0;
            Console.Write("\nEnter the index to stop the sum : ");
            if (int.TryParse(Console.ReadLine(), out int limitOfSum))
            {
                try
                {
                    for (int i = 0; i < limitOfSum; i++)
                    {
                        sum += array[i];
                    }

                    Console.WriteLine($"\nSum of the array upto index {limitOfSum} is {sum}");
                }
                catch (IndexOutOfRangeException)
                {
                    WarningMessage("\nArray index is out of bounds");
                }
                finally
                {
                    Console.WriteLine("\nFinally Block Executed");
                }
            }
        }
    }
}