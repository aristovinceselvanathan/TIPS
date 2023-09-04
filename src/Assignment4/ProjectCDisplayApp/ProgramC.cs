namespace ProjectCDisplayApp
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

        private enum Options
        {
            Add = 1,
            Subtract = 2,
            Multiply = 3,
            Division = 4,
            Exit = 5,
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
            Options optionEnum = (Options)option;
            ProgramD userInterface = new ProgramD();
            switch (optionEnum)
            {
                case Options.Add:
                    userInterface.CorrectAnswerColor($"{temp.Add(input1, input2)}");
                    break;
                case Options.Subtract:
                    userInterface.CorrectAnswerColor($"{temp.Subtract(input1, input2)}");
                    break;
                case Options.Multiply:
                    userInterface.CorrectAnswerColor($"{temp.Multiply(input1, input2)}");
                    break;
                case Options.Division:
                    userInterface.CorrectAnswerColor($"{temp.Divide(input1, input2)}");
                    break;
                case Options.Exit:
                    Console.WriteLine("Exiting....");
                    return false;
                default:
                    userInterface.InvalidNumberWarning("Option");
                    break;
            }

            return true;
        }
    }
}
