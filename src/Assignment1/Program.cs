namespace Assignment1
{
    using System.Text.RegularExpressions;

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
            string? match1, match2, match3;
            MathUtils calculator = new MathUtils();
            Console.WriteLine("Enter the two numbers");
            Console.Write("First Number : ");
            match1 = Console.ReadLine();
            Console.Write("Second Number: ");
            match2 = Console.ReadLine();
            if (IsInteger(match1) && IsInteger(match2))
            {
                input1 = Convert.ToInt32(match1);
                input2 = Convert.ToInt32(match2);
                Console.Write("Enter the options (1.Add, 2.Subtract, 3.Multiply, 4.Division, 5.Exit): ");
                match3 = Console.ReadLine();
                if (IsInteger(match3))
                {
                    option = Convert.ToInt32(match3);
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
                        default:
                            Console.WriteLine("Exiting...");
                            break;
                    }

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

        /// <summary>
        /// Method checks for the input is number
        /// </summary>
        /// <param name="s">It takes string as input</param>
        /// <returns>It returns boolean</returns>
        public static bool IsInteger(string? s)
        {
            Regex pattern = new Regex("^(0|[1-9][0-9]*)$");
            if (pattern.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
