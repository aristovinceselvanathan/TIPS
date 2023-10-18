namespace WorkingWithList
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class it contains the entry point of the program
    /// </summary>
    public class Program
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
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            bool flag = true;
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
                            AddBookInTheDirectory(directoryOfBooks);
                            break;
                        case Services.Remove:
                            RemoveBook(directoryOfBooks);
                            break;
                        case Services.Search:
                            SearchBook(directoryOfBooks);
                            break;
                        case Services.DisplayAll:
                            BookList<string>.DisplayAll(directoryOfBooks);
                            break;
                        case Services.Exit:
                            flag = false;
                            Console.WriteLine("Exiting....");
                            break;
                        default:
                            PrintRedColorMessage("Invalid Option - Please enter the in range between 1 to 5");
                            break;
                    }
                }
                else
                {
                    PrintRedColorMessage("Invalid Input!!! - Required Number");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        /// <summary>
        /// Method it will add the book into the directory of books
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <returns>It returns status of the addition of the book in the list</returns>
        public static bool AddBookInTheDirectory(List<string> directoryOfBooks)
        {
            string titleOfTheBook;
            int sizeOfDirectory = directoryOfBooks.Count();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the title of a book to add: ");
                titleOfTheBook = Console.ReadLine().Trim();
                if (ValidateNameOfTheBook(titleOfTheBook))
                {
                    flag = !BookList<string>.AddBook(directoryOfBooks, titleOfTheBook);
                }
                else
                {
                    Program.PrintRedColorMessage("Invalid title of a book");
                    Console.WriteLine("Press Escape key to exit, Press the any other key to continue.....");
                    if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Method to remove the book from the Directory of books
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <returns>It returns status of the removal of the book from the list</returns>
        public static bool RemoveBook(List<string> directoryOfBooks)
        {
            string titleOfTheBook;
            int sizeOfDirectory = directoryOfBooks.Count();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the title of a book to remove: ");
                titleOfTheBook = Console.ReadLine().Trim();
                if (ValidateNameOfTheBook(titleOfTheBook))
                {
                    flag = !BookList<string>.RemoveBook(directoryOfBooks, titleOfTheBook);
                }
                else
                {
                    Program.PrintRedColorMessage("Invalid title of a book");
                    Console.WriteLine("Press Escape key to exit, Press the any other key to continue.....");
                    if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Method to searches for the title of the books present in the directory of books
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <returns>It returns the whether the book is present in the directory</returns>
        public static bool SearchBook(List<string> directoryOfBooks)
        {
            int sizeOfDirectory = directoryOfBooks.Count();
            string titleOfTheBook;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the title of the book : ");
                titleOfTheBook = Console.ReadLine().Trim();
                if (ValidateNameOfTheBook(titleOfTheBook))
                {
                    if (BookList<string>.SearchTheDirectory(directoryOfBooks, titleOfTheBook) != null)
                    {
                        Program.PrintTheGreenColorMessage($"Book Found!!, Position of the book in the directory : {directoryOfBooks.IndexOf(titleOfTheBook) + 1}");
                        flag = false;
                    }
                    else
                    {
                        Program.PrintRedColorMessage("Title of the book is not present in the directory");
                        Console.WriteLine("Press Escape key to exit, Press the any other key to continue.....");
                        if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                        {
                            flag = false;
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// It shows the colorful warning message of the invalid input
        /// </summary>
        /// <param name="nameOfEvent">It takes the name of the event</param>
        public static void PrintRedColorMessage(string nameOfEvent)
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
        public static void PrintTheGreenColorMessage(string nameOfOperation)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(nameOfOperation);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// It checks for the title matches the alphabetic pattern
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <returns>Return true if it matches the condition, else false</returns>
        public static bool ValidateNameOfTheBook(string title)
        {
            Regex pattern = new Regex("^[A-Za-z\\s!@#$&()-`.+,/\"]+$");
            if (pattern.IsMatch(title))
            {
                return true;
            }

            return false;
        }
    }
}