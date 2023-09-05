namespace Assignment1
{
    /// <summary>
    /// Mathematical Calculator Class
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Addition function
        /// </summary>
        /// <param name="input1">Operand 1</param>
        /// <param name="input2">Operand 2</param>
        /// <returns>It returns the addition of two operands</returns>
        public int Add(int input1, int input2)
        {
            return input1 + input2;
        }

        /// <summary>
        /// Subtraction function
        /// </summary>
        /// <param name="input1">Operand 1</param>
        /// <param name="input2">Operand 2</param>
        /// <returns>It returns the subtraction of two operands</returns>
        public int Subtract(int input1, int input2)
        {
            return input1 - input2;
        }

        /// <summary>
        /// Multiplication function
        /// </summary>
        /// <param name="input1">Operand 1</param>
        /// <param name="input2">Operand 2</param>
        /// <returns>It returns the multiplication of two operands</returns>
        public int Multiply(int input1, int input2)
        {
            return input1 * input2;
        }

        /// <summary>
        /// Division Function
        /// </summary>
        /// <param name="input1">Operand 1</param>
        /// <param name="input2">Operand 2</param>
        /// <returns>It return the quotient of two operands</returns>
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
