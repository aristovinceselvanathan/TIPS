namespace DynamicAndVar
{
    /// <summary>
    /// Program Class it contains the entry point of the program
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            Var = 1,
            Dynamic = 2,
            Exit = 3,
        }

        /// <summary>
        /// It creates the var or dynamic fields and try to change their type of the fields.
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface.</param>
        public static void Main(string[] args)
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Create the variable of type 1.Var 2.Dynamic 3.Exit: ");
                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    switch ((Options)userInput)
                    {
                        case Options.Var:
                            Console.WriteLine("Enter the string to be inserted to the var : ");
                            var userEnteredData1 = Console.ReadLine(); // It instructs the compiler to interface type of the variable
                            Console.WriteLine("Variable type cannot be changed once created by using var keyword!!!");

                            // data = 1 Error!!! Cannot convert implicitly int to string
                            break;
                        case Options.Dynamic:
                            Console.WriteLine("Enter the string to be inserted to the dynamic : ");
                            dynamic userEnteredData2 = Console.ReadLine(); // It will avoid the compile time checking
                            userEnteredData2 = 2;
                            Console.WriteLine($"Changed Value : {userEnteredData2} \n!! Variable type can be changed once created by using dynamic keyword!!!");
                            break;
                        case Options.Exit:
                            flag = false;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Option");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}