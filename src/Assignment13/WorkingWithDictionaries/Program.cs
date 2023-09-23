namespace WorkingWithDictionaries
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private enum Services
        {
            Add = 1,
            Remove = 2,
            DisplayAll = 3,
            Exit = 4,
        }

        /// <summary>
        /// Main method takes the name and grade of the Students and store it in Directory to perform the student management system
        /// </summary>
        /// <param name="args">It takes the string array from the command line</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            Dictionary<string, int> studentDirectory = new ();
            StudentDictionary<string, int> studentRecord = new ();

            while (flag)
            {
                Console.WriteLine("Welcome to Student Management System");
                Console.WriteLine("Choose the options : \n1.Add the Student \n2.Remove the Student \n3.Display all the Student \n4.Exit");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    Services service = (Services)option;
                    switch (service)
                    {
                        case Services.Add:
                            studentRecord.Add(studentDirectory);
                            break;
                        case Services.Remove:
                            studentRecord.Remove(studentDirectory);
                            break;
                        case Services.DisplayAll:
                            studentRecord.DisplayAll(studentDirectory);
                            break;
                        case Services.Exit:
                            flag = false;
                            Console.WriteLine("Exiting....");
                            break;
                        default:
                            WarningMessageFromConsole("Invalid Option");
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