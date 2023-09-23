namespace WorkingWithList
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private enum Services
        {
            Add = 1,
            Remove = 2,
            Search = 3,
            DisplayAll = 4,
            Exit = 5,
        }

        /// <summary>
        /// Main method takes the title of the books and store it in list to perform the library management system
        /// </summary>
        /// <param name="args">It takes the string array from the command line</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            BookList<string> bookList = new ();
            List<string> directoryOfBooks = new ();

            while (flag)
            {
                Console.WriteLine("Welcome to Library System");
                Console.WriteLine("Choose the options : \n1.Add a book \n2.Remove a book \n3.Search in the directory \n4.Display all the books \n5.Exit");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    Services service = (Services)option;
                    switch (service)
                    {
                        case Services.Add:
                            bookList.AddBook(directoryOfBooks);
                            break;
                        case Services.Remove:
                            bookList.RemoveBook(directoryOfBooks);
                            break;
                        case Services.Search:
                            bookList.SearchTheDirectory(directoryOfBooks);
                            break;
                        case Services.DisplayAll:
                            bookList.DisplayAll(directoryOfBooks);
                            break;
                        case Services.Exit:
                            flag = false;
                            Console.WriteLine("Exiting....");
                            break;
                        default:
                            WarningMessageFromConsole("Invalid O ption - Please enter the in range between 1 to 5");
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