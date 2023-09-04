namespace ProjectEHelperApp
{
    /// <summary>
    /// InterfaceE Class
    /// </summary>
    public interface InterfaceE
    {
        /// <summary>
        /// Addition method declaration
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns integer</returns>
        public int Add(int input1, int input2);

        /// <summary>
        /// Subtraction method declaration
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns int</returns>
        public int Subtract(int input1, int input2);

        /// <summary>
        /// Multiplication method declaration
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns int</returns>
        public int Multiply(int input1, int input2);

        /// <summary>
        /// Division method declaration
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns int</returns>
        public int? Divide(int input1, int input2);
    }
}
