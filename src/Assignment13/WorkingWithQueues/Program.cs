namespace WorkingWithQueue
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class that contains the entry point of the program
    /// </summary>
    internal class Program
    {
        private enum Services
        {
            Enqueue = 1,
            Dequeue = 2,
            DisplayAll = 3,
            Exit = 4,
        }

        /// <summary>
        /// Main method takes the name of the Persons and store it in queue to perform the ticket management system
        /// </summary>
        /// <param name="args">It takes the string array from the command line</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            Queue<string> ticketQueueLine = new ();
            TicketQueue<string> ticketQueue = new ();

            while (flag)
            {
                Console.WriteLine("Welcome to Ticket Service System");
                Console.WriteLine("Choose the options : \n1.Enter into Queue \n2.Leave out of the Queue \n3.Display all the people in Queue \n4.Exit");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    Services service = (Services)option;
                    switch (service)
                    {
                        case Services.Enqueue:
                            ticketQueue.Enqueue(ticketQueueLine);
                            break;
                        case Services.Dequeue:
                            ticketQueue.Dequeue(ticketQueueLine);
                            break;
                        case Services.DisplayAll:
                            ticketQueue.DisplayAll(ticketQueueLine);
                            break;
                        case Services.Exit:
                            flag = false;
                            Console.WriteLine("Exiting....");
                            break;
                        default:
                            WarningMessageFromConsole("Invalid Option!! - Enter only in range between 1 to 4");
                            break;
                    }
                }
                else
                {
                    WarningMessageFromConsole("Invalid Input!!! - Required Number");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        /// <summary>
        /// It shows the colorful warning message of the invalid input
        /// </summary>
        /// <param name="nameOfEvent">It takes the name of the event</param>
        public static void WarningMessageFromConsole(string nameOfEvent)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(nameOfEvent);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// It shows the colorful successful message of the successful operation
        /// </summary>
        /// <param name="nameOfOperation">It takes the name of the Operation</param>
        public static void SuccessfulMessageFromConsole(string nameOfOperation)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(nameOfOperation);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}