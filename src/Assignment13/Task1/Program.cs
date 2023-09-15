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
            List<BookClass> directoryOfBooks = new ();

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
                            AddBook(directoryOfBooks);
                            break;
                        case Services.Remove:
                            RemoveBook(directoryOfBooks);
                            break;
                        case Services.Search:
                            SearchTheDirectory(directoryOfBooks);
                            break;
                        case Services.DisplayAll:
                            DisplayAll(directoryOfBooks);
                            break;
                        case Services.Exit:
                            flag = false;
                            Console.WriteLine("Exiting....");
                            break;
                        default:
                            WarningMessageFromConsole("Invalid Option - Please enter the in range between 1 to 5");
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
        /// Method to add the book to the directory
        /// </summary>
        /// <param name="directory">Reference to the directory contains title of the books</param>
        public static void AddBook(List<BookClass> directory)
        {
            BookClass book = new BookClass();
            int size = directory.Count();
            bool flag = true;

            if (size >= 0 && size < 5)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the title of a book to add: ");
                    book.TitleOfTheBook = Console.ReadLine();
                    if (!ValidTitleNameOfBook(book.TitleOfTheBook))
                    {
                        WarningMessageFromConsole("Invalid title of a book");
                        Console.WriteLine("Press Escape key to exit, Press the any other key to continue.....");
                        if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (!directory.Contains(book))
                    {
                        directory.Add(book);
                        SuccessfulMessageFromConsole("Book added successfully");
                        Console.WriteLine($"Size of the directory : {size + 1}");
                        flag = false;
                    }
                    else
                    {
                        WarningMessageFromConsole("Book Title is already present in the directory");
                    }
                }
            }
            else
            {
                WarningMessageFromConsole("Directory is Full!!! \n- Please remove a book to perform the action");
            }
        }

        /// <summary>
        /// Method to remove the book from the Directory
        /// </summary>
        /// <param name="directory">Reference to the directory contains names of the books</param>
        public static void RemoveBook(List<BookClass> directory)
        {
            BookClass book = new BookClass();
            int size = directory.Count();
            bool flag = true;

            if (size > 0 && size <= 5)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the title of a book to remove: ");
                    book.TitleOfTheBook = Console.ReadLine();
                    if (!ValidTitleNameOfBook(book.TitleOfTheBook))
                    {
                        WarningMessageFromConsole("Invalid title of a book");
                        Console.WriteLine("Press Escape key to exit, Press the any other key to continue.....");
                        if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (directory.Remove(book))
                    {
                        SuccessfulMessageFromConsole("Book is removed Successfully");
                        Console.WriteLine($"Size of the directory : {size - 1}");
                        flag = false;
                    }
                    else
                    {
                        WarningMessageFromConsole("Book doesn't exists in the directory");
                    }
                }
            }
            else
            {
                WarningMessageFromConsole("Directory is Empty!!! - Please add a book to perform the action");
            }
        }

        /// <summary>
        /// Method to searches for the title of the books present in the directory
        /// </summary>
        /// <param name="directory">Reference to the directory contains names of the books</param>
        public static void SearchTheDirectory(List<BookClass> directory)
        {
            int size = directory.Count();
            BookClass book = new BookClass();
            bool flag = true;

            if (size > 0)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the title of the book : ");
                    book.TitleOfTheBook = Console.ReadLine();
                    if (directory.Contains(book))
                    {
                        SuccessfulMessageFromConsole($"Book Found!!, Position of the book in the directory : {directory.IndexOf(book) + 1}");
                        flag = false;
                    }
                    else
                    {
                        WarningMessageFromConsole("Title of the book is not present in the directory");
                        Console.WriteLine("Press Escape key to exit, Press the any other key to continue.....");
                        if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                WarningMessageFromConsole("Directory is Empty!!! - Nothing to Search..");
            }
        }

        /// <summary>
        /// Method displays all the title of the books present in the directory
        /// </summary>
        /// <param name="directory">Reference to the directory contains names of the books</param>
        public static void DisplayAll(List<BookClass> directory)
        {
            int size = directory.Count();

            if (size > 0)
            {
                Console.WriteLine("List of books : ");
                directory.ForEach(a => Console.WriteLine($"{a},"));
            }
            else
            {
                WarningMessageFromConsole("Directory is Empty!!! - Nothing to Display");
            }
        }

        /// <summary>
        /// It checks for the title matches the alphabetic pattern
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <returns>Return true if it matches the condition,else false</returns>
        public static bool ValidTitleNameOfBook(string title)
        {
            Regex pattern = new Regex("^[A-Za-z\\s!@#$&()-`.+,/\"]+$");
            if (pattern.IsMatch(title))
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