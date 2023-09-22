namespace CalculationService
{
    /// <summary>
    /// Program Class
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
        /// Main Method that asks the user for CalculationService or OrderService to be triggered
        /// </summary>
        /// <param name="args">It takes the string array from the command line</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Welcome to Testing Manager");
                Console.WriteLine("Enter the Options : 1.CalculationService 2.OrderServices 3.Exit");
                if (int.TryParse(Console.ReadLine(), out int userInputChoice) && userInputChoice > 0 && userInputChoice <= 3)
                {
                    Options option = (Options)userInputChoice;
                    switch (option)
                    {
                        case Options.Calculation:
                            Calculator calculator = new Calculator();
                            calculator.UserInterfaceForCalculator();
                            break;
                        case Options.OrderService:
                            OrderService orderService = new OrderService();
                            orderService.UserInterfaceOfOrderService();
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
            }
        }
    }
}