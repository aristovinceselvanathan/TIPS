namespace CollectionsAndGenerics
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
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
                            Enqueue(ticketQueueLine);
                            break;
                        case Services.Dequeue:
                            Dequeue(ticketQueueLine);
                            break;
                        case Services.DisplayAll:
                            DisplayAll(ticketQueueLine);
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
        /// Method add the person name into the queue
        /// </summary>
        /// <param name="ticketLine">Reference to the queue contains name of the Persons</param>
        public static void Enqueue(Queue<string> ticketLine)
        {
            string nameOfPerson;
            int size = ticketLine.Count();
            bool flag = true;

            if (size >= 0 && size < 5)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the name of a Person to add: ");
                    nameOfPerson = Console.ReadLine().Trim();
                    if (!ValidNameOfPerson(nameOfPerson))
                    {
                        WarningMessageFromConsole("Invalid name of a Person");
                        Console.WriteLine("Press Any key to continue, Press the escape key to exit.....");
                        if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (!ticketLine.Contains(nameOfPerson))
                    {
                        ticketLine.Enqueue(nameOfPerson);
                        SuccessfulMessageFromConsole("Person added successfully");
                        Console.WriteLine($"Size of the queue : {size + 1}");
                        flag = false;
                    }
                    else
                    {
                        WarningMessageFromConsole("Person name is already present in the queue");
                    }
                }
            }
            else
            {
                WarningMessageFromConsole("queue is Full!!! \n- Please remove a Person to perform the action");
            }
        }

        /// <summary>
        /// Remove the Persons from the queue
        /// </summary>
        /// <param name="ticketLine">Reference to the queue contains names of the Persons</param>
        public static void Dequeue(Queue<string> ticketLine)
        {
            int size = ticketLine.Count();

            if (size > 0 && size <= 5)
            {
                SuccessfulMessageFromConsole($"Person is removed Successfully Person name : {ticketLine.Dequeue()}");
                Console.WriteLine($"Size of the Queue : {size - 1}");
            }
            else
            {
                WarningMessageFromConsole("queue is Empty!!! - Please add a Person to perform the action");
            }
        }

        /// <summary>
        /// Method displays all the name of the Persons present in the queue
        /// </summary>
        /// <param name="queue">queue of the name of the Persons</param>
        public static void DisplayAll(Queue<string> queue)
        {
            if (queue.Count() > 0)
            {
                Console.WriteLine("Queue of Persons : ");
                foreach (var item in queue)
                {
                    Console.WriteLine($"{item},");
                }
            }
            else
            {
                WarningMessageFromConsole("queue is Empty!!! - Nothing to Display");
            }
        }

        /// <summary>
        /// It checks for the name matches the alphabetic pattern
        /// </summary>
        /// <param name="name">name of the Person</param>
        /// <returns>Return true if it matches the condition, Else false</returns>
        public static bool ValidNameOfPerson(string name)
        {
            Regex pattern = new Regex("^[A-Za-z\\s]+$");
            if (pattern.IsMatch(name))
            {
                return true;
            }

            return false;
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