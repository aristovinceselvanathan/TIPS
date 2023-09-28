﻿namespace ErrorHandling
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
                Console.WriteLine("Welcome to Error Handling");
                Console.Write("Choose which error wanted to raise 1.Divide By Zero, 2.Index Out of Range, 3.UnHandled Exception 4.Exit: ");
                if (int.TryParse(Console.ReadLine(), out userSelectedOption))
                {
                    option = (Options)userSelectedOption;
                    switch (option)
                    {
                        case Options.DivideByZero:
                            DivideByZero(array[1]);
                            break;
                        case Options.IndexOutOfRange:
                            IndexOutOfBound(array);
                            break;
                        case Options.UnHandledException:
                            throw new Exception("This is Unhandled Exception");
                        case Options.Exit:
                            Console.WriteLine("Exiting...");
                            flag = false;
                            break;
                        default:
                            WarningMessage("Invalid Option");
                            break;
                    }

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
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
        }

        /// <summary>
        /// It shows the warning message color to red when exception is thrown
        /// </summary>
        /// <param name="message">Message of the exception to be printed</param>
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
        /// It creates the DivideByZeroException by dividing the number with array index of 0.
        /// </summary>
        /// <param name="enteredNumber">Number to be divided by zero</param>
        public static void DivideByZero(int enteredNumber)
        {
            int result;

            try
            {
                result = enteredNumber / 0;
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
        /// It creates the IndexOutOfBoundException when the accessing the array element out of index in the for loop
        /// </summary>
        /// <param name="array">Number array to perform array calculation</param>
        public static void IndexOutOfBound(int[] array)
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
                WarningMessage("Array index is out of bounds");
            }
            finally
            {
                Console.WriteLine("Finally Block Executed");
            }
        }
    }
}