﻿namespace ProjectAGreetingsApp
{
    using ProjectBMathApp;
    using ProjectCDisplayApp;
    using ProjectDUtilityApp;

    /// <summary>
    /// Main ProgramA Class
    /// </summary>
    internal class ProgramA
    {
        /// <summary>
        /// Main method prints the greeting message of Hello World and It creates the object of B and pass it method of class C.
        /// Main method starts by the asking the two inputs from the user and checks for the input mismatch.
        /// Main method asks for the operations that are to be performed. The loop runs as long as user terminate by the keyword.
        /// </summary>
        /// <param name="args">It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            int input1, input2, option;
            string match1, match2;
            bool flag = true;

            Console.WriteLine("Hello, World!");

            ProgramD programD = new ProgramD();
            ProgramB math = new ProgramB();
            ProgramC programC = new ProgramC();
            ProgramC.Get(math);
            while (flag)
            {
                Console.WriteLine("Enter the Input1:");
                match1 = programD.CheckStringIsNull(Console.ReadLine());
                Console.WriteLine("Enter the Input2:");
                match2 = programD.CheckStringIsNull(Console.ReadLine());

                if (int.TryParse(match1, out input1) && int.TryParse(match2, out input2))
                {
                    Console.WriteLine("Enter the Option : 1.Addition 2.Subtraction 3.Multiplication 4.Division :");
                    if (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    else
                    {
                        Console.Write("Answer is ");
                        flag = ProgramC.Display(input1, input2, option);
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