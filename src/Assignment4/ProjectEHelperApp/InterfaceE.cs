namespace ProjectEHelperApp
{
    /// <summary>
    /// This is InterfaceE Class
    /// </summary>
    public interface InterfaceE
    {
        /// <summary>
        /// This is main method that prints the Hello World
        /// </summary>
        /// <param name="args">It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        /// <summary>
        /// This is addition method declaration
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns integer</returns>
        public int Add(int input1, int input2);

        /// <summary>
        /// This is subtraction method declaration
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns int</returns>
        public int Subtract(int input1, int input2);

        /// <summary>
        /// This is multiplication method declaration
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns int</returns>
        public int Multiply(int input1, int input2);

        /// <summary>
        /// This is division method declaration
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <returns>It returns int</returns>
        public float Divide(int input1, int input2);
    }
}
