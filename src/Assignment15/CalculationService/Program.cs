namespace CalculationService
{
    /// <summary>
    /// Program Class it contains the entry point of the program
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            Calculation = 1,
            OrderService = 2,
            Exit = 3,
        }

        /// <summary>
        /// Main Method that asks the user for CalculationService or OrderService to be used by the user.
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            bool flag = true, initial = true;
            OrderService orderService;
            Calculator calculator;

            while (flag)
            {
                Console.WriteLine("Welcome to Testing Manager");
                Console.Write("Enter the Options (1-CalculationService 2-OrderServices 3-Exit) : ");
                if (int.TryParse(Console.ReadLine(), out int userInputChoice) && userInputChoice > 0 && userInputChoice <= 3)
                {
                    Options option = (Options)userInputChoice;
                    switch (option)
                    {
                        case Options.Calculation:
                            calculator = new Calculator();
                            calculator.UserInterfaceForCalculator();
                            break;
                        case Options.OrderService:
                            orderService = new OrderService();
                            orderService.UserInterfaceOfOrderService(initial);
                            break;
                        case Options.Exit:
                            flag = false;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            flag = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

                initial = false;
            }
        }
    }
}