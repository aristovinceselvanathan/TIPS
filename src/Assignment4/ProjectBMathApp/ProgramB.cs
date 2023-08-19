namespace ProjectBMathApp
{
    using ProjectEHelperApp;

    /// <summary>
    /// This is a ProgramB Class that implements the InterfaceE
    /// </summary>
    public class ProgramB : InterfaceE
    {
        /// <summary>
        /// This is main method that prints the Mathematical Calculator Application
        /// </summary>
        /// <param name="args">It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Mathematical Calculator Application");
        }

        /// <summary>
        /// This is a addition function
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns the addition of two operands</returns>
        public int Add(int input1, int input2)
        {
            return input1 + input2;
        }

        /// <summary>
        /// This is a subtraction function
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns the subtraction of two operands</returns>
        public int Subtract(int input1, int input2)
        {
            return input1 - input2;
        }

        /// <summary>
        /// This is multiplication function
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns the product of two operands</returns>
        public int Multiply(int input1, int input2)
        {
            return input1 * input2;
        }

        /// <summary>
        /// This is division function
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns the division of two operands in float</returns>
        public float Divide(int input1, int input2)
        {
            return (float)input1 / (float)input2;
        }
    }
}
