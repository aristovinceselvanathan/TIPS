namespace WorkingWithQueue
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Ticket Queue Class
    /// </summary>
    /// <typeparam name="T">It takes the type of the Data for Parameter</typeparam>
    internal class TicketQueue<T>
    {
        /// <summary>
        /// Method add the person name into the queue of the people
        /// </summary>
        /// <param name="ticketLine">Reference to the queue contains name of the Persons</param>
        public void Enqueue(Queue<T> ticketLine)
        {
            T nameOfPerson;
            int sizeOfTheQueue = ticketLine.Count();
            bool flag = true;

            if (sizeOfTheQueue >= 0 && sizeOfTheQueue < 5)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the name of a Person to add: ");
                    nameOfPerson = TryConvert(Console.ReadLine().Trim());
                    if (!this.ValidNameOfPerson(nameOfPerson))
                    {
                        Program.WarningMessageFromConsole("Invalid name of a Person");
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
                        Program.WarningMessageFromConsole("Person added successfully");
                        Console.WriteLine($"Size of the queue : {sizeOfTheQueue + 1}");
                        flag = false;
                    }
                    else
                    {
                        Program.WarningMessageFromConsole("Person name is already present in the queue");
                    }
                }
            }
            else
            {
                Program.WarningMessageFromConsole("Queue is Full!!! \n- Please remove a Person to perform the action");
            }
        }

        /// <summary>
        /// Remove the Persons from the queue of the people
        /// </summary>
        /// <param name="ticketLine">Reference to the queue contains names of the Persons</param>
        public void Dequeue(Queue<T> ticketLine)
        {
            int sizeOfTheQueue = ticketLine.Count();

            if (sizeOfTheQueue > 0 && sizeOfTheQueue <= 5)
            {
                Program.SuccessfulMessageFromConsole($"Person is removed Successfully Person name : {ticketLine.Dequeue()}");
                Console.WriteLine($"Size of the Queue : {sizeOfTheQueue - 1}");
            }
            else
            {
                Program.WarningMessageFromConsole("Queue is Empty!!! - Please add a Person to perform the action");
            }
        }

        /// <summary>
        /// Method displays all the name of the Persons present in the queue
        /// </summary>
        /// <param name="queue">queue of the name of the Persons</param>
        public void DisplayAll(Queue<T> queue)
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
                Program.WarningMessageFromConsole("Queue is Empty!!! - Nothing to Display");
            }
        }

        /// <summary>
        /// It checks for the name matches the alphabetic pattern
        /// </summary>
        /// <param name="name">Name of the Person</param>
        /// <returns>Return true if it matches the condition, Else false</returns>
        public bool ValidNameOfPerson(T name)
        {
            Regex pattern = new Regex("^[A-Za-z\\s]+$");
            if (pattern.IsMatch(TryConvertReverse(name)))
            {
                return true;
            }

            return false;
        }

        // Helper method to try to convert a string to type T
        private static T TryConvert(string input)
        {
            try
            {
                // You can use TypeConverter or parse methods specific to T's type here
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        // Helper method to try to convert a T to type string
        private static string TryConvertReverse(T input)
        {
            try
            {
                // You can use TypeConverter or parse methods specific to T's type here
                return (string)Convert.ChangeType(input, typeof(string));
            }
            catch
            {
                return default(string);
            }
        }
    }
}
