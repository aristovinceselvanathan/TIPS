namespace WorkingWithList
{
    /// <summary>
    /// BookList Class
    /// </summary>
    /// <typeparam name="T">It takes the type of the Data for Parameter</typeparam>
    public class BookList<T>
    {
        /// <summary>
        /// Method to add the book to the directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <param name="bookName">It takes the Book Name</param>
        /// <returns>It returns status of the addition of book into the List</returns>
        public static bool AddBook(List<T> directoryOfBooks, T bookName)
        {
            int sizeOfDirectory = directoryOfBooks.Count;
            if (sizeOfDirectory >= 0 && sizeOfDirectory < 5)
            {
                if (!directoryOfBooks.Contains(bookName))
                {
                    directoryOfBooks.Add(bookName);
                    Program.SuccessfulMessageFromConsole("Book added successfully");
                    Console.WriteLine($"Size of the directory : {sizeOfDirectory + 1}");
                    return true;
                }
                else
                {
                    Program.WarningMessageFromConsole("Book Title is already present in the directory");
                }
            }
            else
            {
                Program.WarningMessageFromConsole("Directory is Full!!! - Please remove a book to perform the action\"");
            }

            return false;
        }

        /// <summary>
        /// Method to remove the book from the Directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <param name="bookName">It takes the book name to remove</param>
        /// <returns>It returns status of the removal of book from the dictionary</returns>
        public static bool RemoveBook(List<T> directoryOfBooks, T bookName)
        {
            int sizeOfDirectory = directoryOfBooks.Count();

            if (sizeOfDirectory > 0 && sizeOfDirectory <= 5)
            {
                if (directoryOfBooks.Remove(bookName))
                {
                    Program.SuccessfulMessageFromConsole("Book is removed Successfully");
                    Console.WriteLine($"Size of the directory : {sizeOfDirectory - 1}");
                    return true;
                }
                else
                {
                    Program.WarningMessageFromConsole("Book doesn't exists in the directory");
                }
            }
            else
            {
                Program.WarningMessageFromConsole("Directory is Empty!!! - Please add a book to perform the action");
            }

            return false;
        }

        /// <summary>
        /// Method to searches for the title of the books present in the directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <param name="book"> It takes the name of the book</param>
        /// <returns>It returns the index of the book present in the Directory</returns>
        public static int? SearchTheDirectory(List<T> directoryOfBooks, T book)
        {
            int sizeOfDirectory = directoryOfBooks.Count();

            if (sizeOfDirectory > 0)
            {
                if (directoryOfBooks.Contains(book))
                {
                    return directoryOfBooks.IndexOf(book);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Program.WarningMessageFromConsole("Directory is Empty!!! - Please add a book to perform the action");
            }

            return null;
        }

        /// <summary>
        /// Method displays all the title of the books present in the directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        public static void DisplayAll(List<T> directoryOfBooks)
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
