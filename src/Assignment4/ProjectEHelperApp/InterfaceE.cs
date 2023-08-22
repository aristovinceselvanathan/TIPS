namespace ProjectEHelperApp
{
    /// <summary>
    /// InterfaceE Class
    /// </summary>
    public interface InterfaceE
    {
        /// <summary>
        /// Main method that prints the Hello World
        /// </summary>
        /// <param name="args">It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

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
