namespace ProjectAGreetingsApp
{
    using ProjectBMathApp;
    using ProjectCDisplayApp;
    using ProjectDUtilityApp;

    /// <summary>
    /// This is a Main ProgramA Class
    /// </summary>
    internal class ProgramA
    {
        /// <summary>
        /// This main method prints the greeting message of Hello World and It creates the object of B and pass it method of class C.
        /// The main method starts by the asking the two inputs from the user and checks for the input mismatch.
        /// The main method asks for the operations that are to be performed. The loop runs as long as user terminate by the keyword.
        /// </summary>
        /// <param name="args">It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            int input1, input2, option;
            string match1, match2;
            bool flag = true;
            ProgramD programD = new ProgramD();
            Console.WriteLine("Hello, World!");
            ProgramB math = new ProgramB();
            ProgramC programC = new ProgramC();
            ProgramC.Get(math);
            while (flag)
            {
                Console.WriteLine("Enter the Input1:");
                match1 = programD.NullException(Console.ReadLine());
                Console.WriteLine("Enter the Input2:");
                match2 = programD.NullException(Console.ReadLine());
                if (programD.PatternMatch(match1) && programD.PatternMatch(match2))
                {
                    try
                    {
                        input1 = Convert.ToInt32(match1);
                        input2 = Convert.ToInt32(match2);
                        Console.WriteLine("Enter the Option : 1.Addition 2.Subtraction 3.Multiplication 4.Division :");
                        option = Convert.ToInt32(programD.NullException(Console.ReadLine()));
                        Console.Write("Answer is ");
                        flag = ProjectCDisplayApp.ProgramC.Display(input1, input2, option);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Numbers");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

                Console.WriteLine("Press Enter to Continue :");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}