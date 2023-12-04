namespace MultiThreading
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class it contains the entry point of program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method it will ask for the array and a size of the array from the user and validate the inputs.
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            Regex pattern = new Regex("\\d");
            int sumOfArray = 0, index = 0;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Welcome to Array Operation Performer");
                Console.Write("\nEnter the Size : ");
                string userInputSize = Console.ReadLine();

                if (int.TryParse(userInputSize, out int inputSize))
                {
                    int[] numberArray = new int[inputSize];
                    index = AddTheElementToTheArray(numberArray, inputSize, pattern);

                    Thread threadToSortTheArray = new Thread(() => { SortingTheArray(numberArray, index); });
                    Thread threadToReturnSumOfArray = new Thread(() => { sumOfArray = SumOfTheArray(numberArray, index); });

                    threadToReturnSumOfArray.Start();
                    threadToSortTheArray.Start();

                    threadToReturnSumOfArray.Join();
                    threadToSortTheArray.Join();

                    Console.WriteLine($"Sorted Array : ");
                    for (int i = 0; i < index; i++)
                    {
                        Console.Write($"{numberArray[i]}, ");
                    }

                    Console.WriteLine($"\nSum of the Element : {sumOfArray}");
                }
                else if (pattern.IsMatch(userInputSize))
                {
                    InvalidWarning($"Please the enter the number in range from {int.MinValue} to {int.MaxValue}");
                }
                else
                {
                    InvalidWarning("Invalid Input from the user");
                }

                Console.WriteLine("Press the Escape Key to Exit, Press the any other key to Continue : ");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// Method will validate and add the numbers into the array
        /// </summary>
        /// <param name="numberArray">Reference of the integer array from the main method</param>
        /// <param name="inputSize">Size of the array form the user</param>
        /// <param name="pattern">Regex pattern to be validated</param>
        /// <returns>Index value of the user entered </returns>
        public static int AddTheElementToTheArray(int[] numberArray, int inputSize, Regex pattern)
        {
            int index;
            string userEnteredNumber;

            for (index = 0; index < inputSize;)
            {
                Console.Write($"\nAdd the Element at position {index + 1} in the array : ");
                userEnteredNumber = Console.ReadLine();
                if (int.TryParse(userEnteredNumber, out numberArray[index]))
                {
                    SuccessfulMessage("\nSuccessfully Added");
                    index++;
                }
                else if (pattern.IsMatch(userEnteredNumber))
                {
                    Console.WriteLine($"Please the enter the number in range from {int.MinValue} to {int.MaxValue}");
                }
                else
                {
                    InvalidWarning("Invalid Input from the User");
                    Console.WriteLine("Press the Escape Key to Exit, Press the any other key to Continue : ");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        return index;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// It Method will sort the array by Arrays.Sort() Method
        /// </summary>
        /// <param name="numberArray">Reference of the array form main method</param>
        /// <param name="index">Index upto to be sorted in the array</param>
        public static void SortingTheArray(int[] numberArray, int index)
        {
            Array.Sort(numberArray, 0, index);
        }

        /// <summary>
        /// It Method will sum of all element in the array
        /// </summary>
        /// <param name="numberArray">Reference of the array form main method</param>
        /// <param name="index">Index upto to be summed in the array</param>
        /// <returns>Sum of all the elements in the array</returns>
        public static int SumOfTheArray(int[] numberArray, int index)
        {
            int sum = 0;
            for (int i = 0; i < index; i++)
            {
                sum += numberArray[i];
            }

            return sum;
        }

        /// <summary>
        /// It shows the warning message of the invalid input
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the input</param>
        public static void InvalidWarning(string nameOfInput)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// It shows the colorful green color message
        /// </summary>
        /// <param name="message">It takes the message as a input</param>
        public static void SuccessfulMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}