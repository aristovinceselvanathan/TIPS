namespace WorkingWithQueue
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Ticket Queue Class
    /// </summary>
    /// <typeparam name="T">It takes the type of the Data for Parameter</typeparam>
    public class TicketQueue<T>
    {
        /// <summary>
        /// Method add the person name into the queue of the people
        /// </summary>
        /// <param name="ticketLine">Reference to the queue contains name of the Persons</param>
        /// <param name="nameOfPerson">Name of the Person to be added into the queue</param>
        /// <returns>It returns status of the enqueue of person in queue</returns>
        public static bool Enqueue(Queue<T> ticketLine, T nameOfPerson)
        {
            if (!ValidNameOfPerson(nameOfPerson))
            {
                Program.WarningMessageFromConsole("Invalid name of a Person");
                Console.WriteLine("Press Any key to continue, Press the escape key to exit.....");
                return false;
            }
            else if (!ticketLine.Contains(nameOfPerson))
            {
                ticketLine.Enqueue(nameOfPerson);
                Program.SuccessfulMessageFromConsole("Person added successfully");
                Console.WriteLine($"Size of the queue : {ticketLine.Count}");
            }
            else
            {
                Program.WarningMessageFromConsole("Person name is already present in the queue");
            }

            return false;
        }

        /// <summary>
        /// Remove the Persons from the queue of the people
        /// </summary>
        /// <param name="ticketLine">Reference to the queue contains names of the Persons</param>
        /// <returns>It returns status of the dequeue of person from queue</returns>
        public static T Dequeue(Queue<T> ticketLine)
        {
            int sizeOfTheQueue = ticketLine.Count();
            T dequeName;

            if (sizeOfTheQueue > 0 && sizeOfTheQueue <= 5)
            {
                dequeName = ticketLine.Dequeue();
                Console.WriteLine($"Size of the Queue : {sizeOfTheQueue - 1}");
                return dequeName;
            }
            else
            {
                Program.WarningMessageFromConsole("Queue is Empty!!! - Please add a Person to perform the action");
            }

            return default(T);
        }

        /// <summary>
        /// Method displays all the name of the Persons present in the queue
        /// </summary>
        /// <param name="queue">Queue that contains the name of the persons</param>
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

        /// <summary>
        /// It checks for the name matches the alphabetic pattern
        /// </summary>
        /// <param name="name">Name of the Person</param>
        /// <returns>Return true if it matches the condition, Else false</returns>
        private static bool ValidNameOfPerson(T name)
        {
            Regex pattern = new Regex("^[A-Za-z\\s]+$");
            if (pattern.IsMatch(TryConvertReverse(name)))
            {
                return true;
            }

            return false;
        }
    }
}
