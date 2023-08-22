namespace ProjectBMathApp
{
    using ProjectEHelperApp;

    /// <summary>
    /// ProgramB Class that implements the InterfaceE
    /// </summary>
    public class ProgramB : InterfaceE
    {
        /// <summary>
        /// Main method that prints the Mathematical Calculator Application
        /// </summary>
        /// <param name="args">It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Mathematical Calculator Application");
        }

        /// <summary>
        /// Addition function
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns the addition of two operands</returns>
        public int Add(int input1, int input2)
        {
            return input1 + input2;
        }

        /// <summary>
        /// Subtraction function
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns the subtraction of two operands</returns>
        public int Subtract(int input1, int input2)
        {
            return input1 - input2;
        }

        /// <summary>
        /// Multiplication function
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns the product of two operands</returns>
        public int Multiply(int input1, int input2)
        {
            return input1 * input2;
        }

        /// <summary>
        /// Division function
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns the quotient of two operands in float</returns>
        public int? Divide(int input1, int input2)
        {
            if (input2 == 0)
            {
                Console.WriteLine("∞");
                return null;
            }

            return input1 / input2;
        }
    }
}
