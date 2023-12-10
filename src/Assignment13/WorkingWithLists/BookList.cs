namespace WorkingWithList
{
    /// <summary>
    /// BookList Class
    /// </summary>
    /// <typeparam name="T">It takes the type of the Data for Parameter</typeparam>
    public class BookList<T>
    {
        /// <summary>
        /// Method to add the book details into the directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <param name="bookTitle">It takes the Title of the Book</param>
        /// <returns>It returns status of the addition of book into the Directory of books</returns>
        public static bool AddBook(List<T> directoryOfBooks, T bookTitle)
        {
            int sizeOfDirectory = directoryOfBooks.Count;
            if (sizeOfDirectory >= 0 && sizeOfDirectory < 5)
            {
                if (!directoryOfBooks.Contains(bookTitle))
                {
                    directoryOfBooks.Add(bookTitle);
                    Program.PrintTheGreenColorMessage("Book added successfully");
                    Console.WriteLine($"Size of the directory : {sizeOfDirectory + 1}");
                    return true;
                }
                else
                {
                    Program.PrintRedColorMessage("Book Title is already present in the directory");
                }
            }
            else
            {
                Program.PrintRedColorMessage("Directory is Full!!! - Please remove a book to perform the action\"");
            }

            return false;
        }

        /// <summary>
        /// Method to remove the book from the Directory
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <param name="bookTitle">It takes the title of the book to remove</param>
        /// <returns>It returns status of the removal of book from the dictionary</returns>
        public static bool RemoveBook(List<T> directoryOfBooks, T bookTitle)
        {
            int sizeOfDirectory = directoryOfBooks.Count();

            if (sizeOfDirectory > 0 && sizeOfDirectory <= 5)
            {
                if (directoryOfBooks.Remove(bookTitle))
                {
                    Program.PrintTheGreenColorMessage("Book is removed Successfully");
                    Console.WriteLine($"Size of the directory : {sizeOfDirectory - 1}");
                    return true;
                }
                else
                {
                    Program.PrintRedColorMessage("Book doesn't exists in the directory");
                }
            }
            else
            {
                Program.PrintRedColorMessage("Directory is Empty!!! - Please add a book to perform the action");
            }

            return false;
        }

        /// <summary>
        /// Method to searches for the title of the book present in the directory of books
        /// </summary>
        /// <param name="directoryOfBooks">Reference to the directory contains details of the books</param>
        /// <param name="bookTitle"> It takes the title of the book</param>
        /// <returns>It returns the index of the book present in the Directory</returns>
        public static int? SearchTheDirectory(List<T> directoryOfBooks, T bookTitle)
        {
            int sizeOfDirectory = directoryOfBooks.Count();

            if (sizeOfDirectory > 0)
            {
                if (directoryOfBooks.Contains(bookTitle))
                {
                    return directoryOfBooks.IndexOf(bookTitle);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Program.PrintRedColorMessage("Directory is Empty!!! - Please add a book to perform the action");
            }

            return null;
        }

        /// <summary>
        /// Method displays all the tile of the books present in the directory
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
                Program.PrintRedColorMessage("Directory is Empty!!! - Nothing to Display");
            }
        }

        // Helper method to try to convert a string to type T
        private static T TryConvert(string input)
        {
            try
            {
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
                return (string)Convert.ChangeType(input, typeof(string));
            }
            catch
            {
                return default(string);
            }
        }
    }
}
