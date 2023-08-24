namespace Assignment1
{
    /// <summary>
    /// Main Class Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method starts by the asking the two inputs from the user and checks for the input mismatch.
        /// Main method asks for the operations that are to be performed. The loop runs as long as user terminate by the keyword.
        /// </summary>
        /// <param name="args"> It is string array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            int input1, input2, option;
            bool isInteger1, isInteger2, isInteger3, flag = true;
            MathUtils calculator = new MathUtils();

            while (flag)
            {
                Console.WriteLine("Enter the two numbers");
                Console.Write("First Number : ");
                isInteger1 = int.TryParse(Console.ReadLine(), out input1);
                Console.Write("Second Number: ");
                isInteger2 = int.TryParse(Console.ReadLine(), out input2);

                if (isInteger1 && isInteger2)
                {
                    Console.Write("Enter the options (1.Add, 2.Subtract, 3.Multiply, 4.Division, 5.Exit): ");
                    isInteger3 = int.TryParse(Console.ReadLine(), out option);

                    if (isInteger3)
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
                                Console.WriteLine(calculator.Multiplinput2(input1, input2));
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

                        Console.WriteLine("Press Any Key to Continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input, Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Inputs, Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
