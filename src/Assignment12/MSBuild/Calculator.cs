namespace MSBuild
{
    using System;

    /// <summary>
    /// Main Class Program
    /// </summary>
    public class Calculator
    {
        private enum Options
        {
            Addition = 1,
            Subtraction = 2,
            Multiplication = 3,
            Division = 4,
            Exit = 5,
        }

        /// <summary>
        /// Main method starts by the asking the two inputs from the user and checks for the input mismatch.
        /// Main method asks for the operations that are to be performed. The loop runs as long as user terminate by the keyword.
        /// </summary>
        /// <param name="args"> It is string array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            int userInput1, userInput2, userInputOption;
            bool isIntegerOfOperand1, isIntegerOfOperand2, flag = true;

            while (flag)
            {
                Console.WriteLine("Enter the two numbers");
                Console.Write("First Number : ");
                isIntegerOfOperand1 = int.TryParse(Console.ReadLine(), out userInput1);
                if (!isIntegerOfOperand1)
                {
                    Console.WriteLine("Invalid Input1, Press any key to continue : ");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.Write("Second Number: ");
                isIntegerOfOperand2 = int.TryParse(Console.ReadLine(), out userInput2);
                if (!isIntegerOfOperand2)
                {
                    Console.WriteLine("Invalid Input2, Press any key to continue : ");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if (isIntegerOfOperand1 && isIntegerOfOperand2)
                {
                    flag = Services(userInput1, userInput2);
                }
                else
                {
                    Console.WriteLine("Invalid Inputs, Press any key to continue : ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// It asks the user for the operations to be performed
        /// </summary>
        /// <returns>It returns boolean whether to continue or exit loop</returns>
        /// <param name="input1">It takes operand1 for the mathematical operation</param>
        /// <param name="input2">It takes operand2 for the mathematical operation</param>
        public static bool Services(int input1, int input2)
        {
            bool isIntegerOfOption;
            Console.Write("Enter the options (1.Add, 2.Subtract, 3.Multiply, 4.Division, 5.Exit): ");
            isIntegerOfOption = int.TryParse(Console.ReadLine(), out int userInputOption);

            if (isIntegerOfOption)
            {
                Options options = (Options)userInputOption;
                switch (options)
                {
                    case Options.Addition:
                        Console.WriteLine(input1 + input2);
                        break;
                    case Options.Subtraction:
                        Console.WriteLine(input1 - input2);
                        break;
                    case Options.Multiplication:
                        Console.WriteLine(input1 * input2);
                        break;
                    case Options.Division:
                        if (input2 == 0)
                        {
                            Console.WriteLine("∞");
                        }
                        else
                        {
                            Console.WriteLine(input1 / input2);
                        }
                        break;
                    case Options.Exit:
                        Console.WriteLine("Exiting...");
                        return false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                Console.WriteLine("Press Any Key to Continue : ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid Input, Press any key to continue : ");
                Console.ReadKey();
                Console.Clear();
            }
            return true;
        }
    }
}