﻿namespace ProjectCDisplayApp
{
    using ProjectDUtilityApp;
    using ProjectEHelperApp;

    /// <summary>
    /// ProgramC Class  used as helper class to access the ProgramB methods in ProgramC.
    /// It keeps the object of the ProgramB Class in the reference of the interface in InterfaceE.
    /// </summary>
    public class ProgramC
    {
        private static InterfaceE temp;

        /// <summary>
        /// Main method that prints the Hello World.
        /// </summary>
        /// <param name="args">>It is string array that returns from the command line interface</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, This is Display App Class");
        }

        /// <summary>
        /// Method is help in get object of the ProgramB from ProgramA. To be used in the ProgramC.
        /// </summary>
        /// <param name="t1">It takes the reference of the InterfaceE</param>
        public void Get(InterfaceE t1)
        {
            temp = t1;
        }

        /// <summary>
        /// Method display that display the result based on the operations that user choose.
        /// </summary>
        /// <param name="input1">It takes the input1</param>
        /// <param name="input2">It takes the input2</param>
        /// <param name="option">It takes the option</param>
        /// <returns>It returns the boolean</returns>
        public bool Display(int input1, int input2, int option)
        {
            ProgramD userInterface = new ProgramD();
            switch (option)
            {
                case 1:
                    userInterface.CorrectAnswerColor($"{temp.Add(input1, input2)}");

                    break;
                case 2:
                    userInterface.CorrectAnswerColor($"{temp.Subtract(input1, input2)}");
                    break;
                case 3:
                    userInterface.CorrectAnswerColor($"{temp.Multiply(input1, input2)}");
                    break;
                case 4:
                    userInterface.CorrectAnswerColor($"{temp.Divide(input1, input2)}");
                    break;
                case 5:
                    Console.WriteLine("Exiting....");
                    return false;
                default:
                    userInterface.InvalidNumberWarning("Invalid Option");
                    break;
            }

            return true;
        }
    }
}
