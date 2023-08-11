namespace Assignment1
{
    /// <summary>
    /// This is a Main Class Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This is a Main Method
        /// </summary>
        /// <param name="args"> This is a sample args</param>
        public static void Main(string[] args)
        {
            MathUtils cal = new MathUtils();
            while (true)
            {
                Console.WriteLine("Enter the two numbers");
                Console.Write("First Number : ");
                int input1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Second Number: ");
                int input2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the options (1.Add, 2.Subtract, 3.Multiply, 4.Division, 5.Exit: ");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine(cal.Add(input1, input2));
                }
                else if (option == 2)
                {
                    Console.WriteLine(cal.Subtract(input1, input2));
                }
                else if (option == 3)
                {
                    Console.WriteLine(cal.Multiply(input1, input2));
                }
                else if (option == 4)
                {
                    Console.WriteLine(cal.Divide(input1, input2));
                }
                else
                {
                    break;
                }
            }
        }
    }

    /// <summary>
    /// This is a Mathematical Calution Class
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// This is addtion fuction
        /// </summary>
        /// <param name="x">Operand 1</param>
        /// <param name="y">Operand 2</param>
        /// <returns>It returns the addition of two operands</returns>
        public int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// This is Subtraction fuction
        /// </summary>
        /// <param name="x">Operand 1</param>
        /// <param name="y">Operand 2</param>
        /// <returns>It returns the subtraction of two operands</returns>
        public int Subtract(int x, int y)
        {
            return x - y;
        }

        /// <summary>
        /// This is Multiplication fuction
        /// </summary>
        /// <param name="x">Operand 1</param>
        /// <param name="y">Operand 2</param>
        /// <returns>It retruns the multiplication of two operands</returns>
        public int Multiply(int x, int y)
        {
            return x * y;
        }

        /// <summary>
        /// This is Division Function
        /// </summary>
        /// <param name="x">Operand 1</param>
        /// <param name="y">Operand 2</param>
        /// <returns>It return the division of two operands</returns>
        public float Divide(int x, int y)
        {
            return (float)((float)x / (float)y);
        }
    }
}