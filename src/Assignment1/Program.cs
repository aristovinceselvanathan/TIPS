namespace Assignment1
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// This is a Main Class Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method starts by the asking the two inputs from the user and checks for the input mismatch.
        /// The main method asks for the operations that are to be performed. The loop runs as long as user terminate by the keyword.
        /// </summary>
        /// <param name="args"> It is string array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            int input1, input2, option;
            bool flag = true;
            string? match1, match2;
            while (flag)
            {
                MathUtils calculator = new MathUtils();
                Console.WriteLine("Enter the two numbers");
                Console.Write("First Number : ");
                match1 = NullException(Console.ReadLine());
                input1 = IntegerInput(match1);
                Console.Write("Second Number: ");
                match2 = NullException(Console.ReadLine());
                if (!PatternMatch(match1) || !PatternMatch(match2))
                {
                    Console.WriteLine("Invalid Number");
                    Console.WriteLine("Press Enter to continue: ");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    input2 = IntegerInput(match2);
                    Console.Write("Enter the options (1.Add, 2.Subtract, 3.Multiply, 4.Division, 5.Exit): ");
                    option = IntegerInput(NullException(Console.ReadLine()));
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
                            flag = false;
                            break;
                    }

                    if (flag != false)
                    {
                        Console.WriteLine("Press Enter to Continue: ");
                        Console.ReadLine();
                    }

                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// It matches string with the regex pattern.
        /// </summary>
        /// <param name="input">It takes string as an input to be matched with the pattern</param>
        /// <returns>It returns boolean</returns>
        public static bool PatternMatch(string input)
        {
            Regex regex = new Regex("[0-9]{1}");
            if (regex.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method checks for the integer conversion of the string
        /// </summary>
        /// <param name="s">It takes string as input</param>
        /// <returns>It returns the integer</returns>
        public static int IntegerInput(string s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// This function checks it is null
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns string</returns>
        public static string NullException(string? s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return " ";
            }
            else
            {
                return s;
            }
        }
    }
}
