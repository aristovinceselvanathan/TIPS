﻿namespace ProjectAGreetingsApp
{
    using ProjectBMathApp;
    using ProjectCDisplayApp;
    using ProjectDUtilityApp;

    /// <summary>
    /// ProgramA Class
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
            string isNumber1, isNumber2;
            bool flag = true;
            ProgramB mathOperation = new ProgramB();
            ProgramC displayResults = new ProgramC();
            ProgramD userInterface = new ProgramD();

            displayResults.Get(mathOperation);
            while (flag)
            {
                Console.Write("Welcome to Calculator Application\nEnter the Input1 : ");
                isNumber1 = Console.ReadLine();
                if (!int.TryParse(isNumber1, out input1))
                {
                    userInterface.InvalidNumberWarning("Input 1");
                    continue;
                }

                Console.Write("Enter the Input2 : ");
                isNumber2 = Console.ReadLine();
                if (!int.TryParse(isNumber2, out input2))
                {
                    userInterface.InvalidNumberWarning("Input 2");
                    continue;
                }
                else
                {
                    Console.Write("Enter the Option : 1.Addition 2.Subtraction 3.Multiplication 4.Division 5.Exit : ");
                    if (!int.TryParse(Console.ReadLine(), out option) || (option > 5 || option < 1))
                    {
                        userInterface.InvalidNumberWarning("Option");
                        continue;
                    }
                    else
                    {
                        flag = displayResults.Display(input1, input2, option);
                    }
                }

                Console.WriteLine("Press Enter to Continue :");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}