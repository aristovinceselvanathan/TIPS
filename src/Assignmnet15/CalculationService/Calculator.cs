namespace CalculationService
{
    /// <summary>
    /// Mathematical Calculator Class
    /// </summary>
    internal class Calculator
    {
        /// <summary>
        /// Main method starts by the asking the two inputs from the user and checks for the input mismatch.
        /// Main method asks for the operations that are to be performed. The loop runs as long as user terminate by the keyword.
        /// </summary>
        public void UserInterfaceForCalculator()
        {
            int input1, input2, option;
            bool isIntegerOfOperand1, isIntegerOfOperand2, isIntegerOfOption, flag = true;
            MathUtility calculator = new MathUtility();

            while (flag)
            {
                Console.WriteLine("Enter the two numbers");
                Console.Write("First Number : ");
                isIntegerOfOperand1 = int.TryParse(Console.ReadLine(), out input1);
                if (!isIntegerOfOperand1)
                {
                    Console.WriteLine("Invalid Input1, Press Escape Key to Exit, Press any other key to continue : ");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        flag = false;
                    }

                    Console.Write("Bye...");
                    Console.Clear();
                    continue;
                }

                Console.Write("Second Number: ");
                isIntegerOfOperand2 = int.TryParse(Console.ReadLine(), out input2);
                if (!isIntegerOfOperand2)
                {
                    Console.WriteLine("Invalid Input2, Press Escape Key to Exit, Press any other key to continue : ");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        flag = false;
                    }

                    Console.Write("Bye...");
                    Console.Clear();
                    continue;
                }

                if (isIntegerOfOperand1 && isIntegerOfOperand2)
                {
                    Console.Write("Enter the options (1.Add, 2.Subtract, 3.Multiply, 4.Division, 5.Exit): ");
                    isIntegerOfOption = int.TryParse(Console.ReadLine(), out option);

                    if (isIntegerOfOption)
                    {
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine(calculator.Add(input1, input2));
                                break;
                            case 2:
                                Console.WriteLine(calculator.Subtract(input1, input2));
                                break;
                            case 3:
                                Console.WriteLine(calculator.Multiply(input1, input2));
                                break;
                            case 4:
                                Console.WriteLine(calculator.Divide(input1, input2));
                                break;
                            case 5:
                                Console.WriteLine("Exiting...");
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("Invalid Option");
                                break;
                        }

                        Console.WriteLine("Press Any Key to Continue : ");
                        Console.ReadKey();
                        Console.Write("Bye...");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, Press any key to continue : ");
                        Console.ReadKey();
                        Console.Write("Bye...");
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Inputs, Press any key to continue : ");
                    Console.ReadKey();
                    Console.Write("Bye...");
                    Console.Clear();
                }
            }
        }
    }
}
