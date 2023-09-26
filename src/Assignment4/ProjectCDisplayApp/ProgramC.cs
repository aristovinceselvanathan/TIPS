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
        private static InterfaceE temporaryReference;

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
        /// <param name="temp">It takes the reference of the InterfaceE</param>
        public void GetObjectOfProgramB(InterfaceE temp)
        {
            temporaryReference = temp;
        }

        /// <summary>
        /// Method that display the result based on the user choice of operation.
        /// </summary>
        /// <param name="input1">It takes the input of the Operand1</param>
        /// <param name="input2">It takes the input of the Operand2</param>
        /// <param name="option">It takes the option of the operations to be performed</param>
        /// <returns>It returns the boolean</returns>
        public bool Display(int input1, int input2, int option)
        {
            Options optionEnum = (Options)option;
            ProgramD userInterface = new ProgramD();
            switch (optionEnum)
            {
                case Options.Add:
                    userInterface.CorrectAnswerColor($"{temporaryReference.Add(input1, input2)}");
                    break;
                case Options.Subtract:
                    userInterface.CorrectAnswerColor($"{temporaryReference.Subtract(input1, input2)}");
                    break;
                case Options.Multiply:
                    userInterface.CorrectAnswerColor($"{temporaryReference.Multiply(input1, input2)}");
                    break;
                case Options.Division:
                    userInterface.CorrectAnswerColor($"{temporaryReference.Divide(input1, input2)}");
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
