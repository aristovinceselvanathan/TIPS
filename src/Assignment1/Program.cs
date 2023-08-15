namespace Assignment1
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// This is a Main Class Program
    /// </summary>
    public class Program
    {
        private static bool flag1 = true;

        /// <summary>
        /// This is a Main Method
        /// </summary>
        /// <param name="args"> It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            int input1, input2, option;
            bool flag = true;
            while (flag)
            {
                MathUtils calculator = new MathUtils();
            label2:
                Console.WriteLine("Enter the two numbers");
                Console.Write("First Number : ");
                input1 = IntegerInput(NullException(Console.ReadLine()));
                if (!flag1)
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    flag1 = true;
                    goto label2;
                }

                Console.Write("Second Number: ");
                input2 = IntegerInput(NullException(Console.ReadLine()));
                if (!flag1)
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    flag1 = true;
                    goto label2;
                }

            label:
                Console.Write("Enter the options (1.Add, 2.Subtract, 3.Multiply, 4.Division, 5.Exit): ");
                option = IntegerInput(NullException(Console.ReadLine()));
                if (option <= 0 || option >= 6)
                {
                    goto label;
                }

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

                if (flag)
                {
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("Exiting....");
                    Thread.Sleep(1000);
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// This Method checks for the Input Mismatch for string
        /// </summary>
        /// <param name="s">It Takes string as input</param>
        /// <returns>It returns the integer</returns>
        public static int IntegerInput(string s)
        {
            try
            {
                Regex regex = new Regex("[0-9]{1}");
                if (regex.IsMatch(s))
                {
                    return Convert.ToInt32(s);
                }
                else
                {
                    flag1 = false;
                    Console.WriteLine("Invalid number");
                    return 0;
                }
            }
            catch (Exception)
            {
                flag1 = false;
                Console.WriteLine("Invalid number");
                return 0;
            }
        }

        /// <summary>
        /// This is check it null
        /// </summary>
        /// <param name="s">It takes the string</param>
        /// <returns>it returns string</returns>
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
