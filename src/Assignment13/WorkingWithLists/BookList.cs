namespace WorkingWithList
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// BookList Class contains the entry point of the program
    /// </summary>
    /// <typeparam name="T">It takes the type of the Data for Parameter</typeparam>
    internal class BookList<T>
    {
        /// <summary>
        /// Method to add the book to the directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        public void AddBook(List<T> directoryOfBooks)
        {
            T book;
            int sizeOfDirectory = directoryOfBooks.Count();
            bool flag = true;

            if (sizeOfDirectory >= 0 && sizeOfDirectory < 5)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the title of a book to add: ");
                    book = TryConvert(Console.ReadLine().Trim());
                    if (!this.ValidTitleNameOfBook(book))
                    {
                        Program.WarningMessageFromConsole("Invalid title of a book");
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
                    else if (!directoryOfBooks.Contains(book))
                    {
                        directoryOfBooks.Add(book);
                        Program.SuccessfulMessageFromConsole("Book added successfully");
                        Console.WriteLine($"Size of the directory : {sizeOfDirectory + 1}");
                        flag = false;
                    }
                    else
                    {
                        Program.WarningMessageFromConsole("Book Title is already present in the directory");
                    }
                }
            }
            else
            {
                Program.WarningMessageFromConsole("Directory is Full!!! \n- Please remove a book to perform the action");
            }
        }

        /// <summary>
        /// Method to remove the book from the Directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains detials of the books</param>
        public void RemoveBook(List<T> directoryOfBooks)
        {
            T book;
            int sizeOfDirectory = directoryOfBooks.Count();
            bool flag = true;

            if (sizeOfDirectory > 0 && sizeOfDirectory <= 5)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the title of a book to remove: ");
                    book = TryConvert(Console.ReadLine());
                    if (!this.ValidTitleNameOfBook(book))
                    {
                        Program.WarningMessageFromConsole("Invalid title of a book");
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
                    else if (directoryOfBooks.Remove(book))
                    {
                        Program.SuccessfulMessageFromConsole("Book is removed Successfully");
                        Console.WriteLine($"Size of the directory : {sizeOfDirectory - 1}");
                        flag = false;
                    }
                    else
                    {
                        Program.WarningMessageFromConsole("Book doesn't exists in the directory");
                    }
                }
            }
            else
            {
                Program.WarningMessageFromConsole("Directory is Empty!!! - Please add a book to perform the action");
            }
        }

        /// <summary>
        /// Method to searches for the title of the books present in the directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        public void SearchTheDirectory(List<T> directoryOfBooks)
        {
            int sizeOfDirectory = directoryOfBooks.Count();
            T book;
            bool flag = true;

            if (sizeOfDirectory > 0)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the title of the book : ");
                    book = TryConvert(Console.ReadLine().Trim());
                    if (directoryOfBooks.Contains(book))
                    {
                        Program.SuccessfulMessageFromConsole($"Book Found!!, Position of the book in the directory : {directoryOfBooks.IndexOf(book) + 1}");
                        flag = false;
                    }
                    else
                    {
                        Program.WarningMessageFromConsole("Title of the book is not present in the directory");
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
            }
        }

        /// <summary>
        /// Method displays all the title of the books present in the directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        public void DisplayAll(List<T> directoryOfBooks)
        {
            int size = directoryOfBooks.Count();

            if (size > 0)
            {
                Console.WriteLine("List of books : ");
                directoryOfBooks.ForEach(a => Console.WriteLine($"{a},"));
            }
            else
            {
                Program.WarningMessageFromConsole("Directory is Empty!!! - Nothing to Display");
            }
        }

        /// <summary>
        /// It checks for the title matches the alphabetic pattern
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <returns>Return true if it matches the condition, else false</returns>
        public bool ValidTitleNameOfBook(T title)
        {
            Regex pattern = new Regex("^[A-Za-z\\s!@#$&()-`.+,/\"]+$");
            if (pattern.IsMatch(TryConvertReverse(title)))
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
