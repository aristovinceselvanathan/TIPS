namespace Records
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class it contains the entry point of the program
    /// </summary>
    public class Program
    {
        public record book(string name, string author, string isbn)
        {
            /// <summary>
            /// Override the ToString Method of the record of the book
            /// </summary>
            /// <returns>It returns the string to print the details of the book</returns>
            public override string ToString()
            {
                return $"Name : {this.name}\nAuthor Name : {this.author}\nISBN Number : {this.isbn}";
            }
        }

        private enum Options
        {
            Add = 1,
            DisplayAll = 2,
            Edit = 3,
            Equality = 4,
            TakeCopy = 5,
            Exit = 6,
        }

        /// <summary>
        /// Method asks the user for type of actions to be performed in the record list
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            List<book> directoryOfBooks = new List<book>();
            bool flag = true;
            string nameOfBook, authorOfBook, isbnOfBook;

            while (flag)
            {
                Console.WriteLine("Welcome to Book Management System");
                Console.WriteLine("Enter the choice: \n1.Add a book \n2.Display all the books \n3.Edit the Name" +
                    "\n4.Check the Equality \n5.Take the Copy of the Record \n6.Exit");
                Console.Write("Press Enter in Any Field to Exit, Press Your Option : ");
                if (int.TryParse(Console.ReadLine(), out int userInputOption))
                {
                    Options option = (Options)userInputOption;
                    switch (option)
                    {
                        case Options.Add:
                            Console.Write($"Enter the Name : ");
                            nameOfBook = Console.ReadLine();
                            Console.Write($"Enter the Author Name : ");
                            authorOfBook = Console.ReadLine();
                            Console.Write($"Enter the ISBN: ");
                            isbnOfBook = Console.ReadLine();
                            if (AddBook(directoryOfBooks, nameOfBook, authorOfBook, isbnOfBook))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Added Successfully");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Book is not Properly Added");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;
                        case Options.DisplayAll:
                            int i = 0;
                            Console.Write("List of the Books : ");
                            foreach (book book in directoryOfBooks)
                            {
                                DisplayBook(book, ++i);
                            }

                            break;
                        case Options.Edit:
                            Console.WriteLine("Edit the Book Name Alone");
                            Console.Write("Enter the position of the book : ");
                            if (int.TryParse(Console.ReadLine(), out int index))
                            {
                                Console.Write("Enter the name of the book : ");
                                nameOfBook = Console.ReadLine();
                                EditNameOfProduct(directoryOfBooks, index, nameOfBook);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Number");
                            }

                            break;
                        case Options.Equality:
                            Console.Write("Get the Details of the Book at index : ");
                            if (int.TryParse(Console.ReadLine(), out int position) && position > 0 && position <= directoryOfBooks.Count)
                            {
                                book temporaryElement = directoryOfBooks.ElementAt(position - 1);
                                Console.WriteLine("Details of about the book : ");
                                Console.WriteLine(temporaryElement);
                                Console.WriteLine("To Check Value Equality");
                                Console.WriteLine("Creating the another book from this data...");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Check the Equality of the two Records : {temporaryElement == new book(temporaryElement.name, temporaryElement.author, temporaryElement.isbn)}");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Position");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;
                        case Options.TakeCopy:
                            Console.Write("Get the Details of the Book at index : ");
                            if (int.TryParse(Console.ReadLine(), out position) && position > 0 && position <= directoryOfBooks.Count)
                            {
                                book temporaryElement = directoryOfBooks.ElementAt(position - 1);
                                Console.WriteLine("Original Value before the Duplicate is Created : ");
                                Console.WriteLine(temporaryElement);
                                var temp1 = temporaryElement with { name = "Book of Persia", author = "John Cobol" };
                                Console.WriteLine("Original Value after the Duplicate is Created : ");
                                Console.WriteLine(temporaryElement);
                                Console.WriteLine("Duplicated value : ");
                                Console.WriteLine(temp1);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Position");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;
                        case Options.Exit:
                            Console.WriteLine("Exiting.....");
                            flag = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Option");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    flag = false;
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// It add the book into the list of the books
        /// </summary>
        /// <param name="directoryOfBooks"> It take the reference of the list from the main</param>
        /// <param name="userInputName">It takes the  name of the book</param>
        /// <param name="userInputAuthor">It takes author name of the book</param>
        /// <param name="userInputISBN">It takes the ISBN of the book</param>
        /// <returns>It returns bool status of the addition of book into the list</returns>
        public static bool AddBook(List<book> directoryOfBooks, string userInputName, string userInputAuthor, string userInputISBN)
        {
            string nameOfBook = IsValidName(userInputName);
            if (nameOfBook == null)
            {
                return false;
            }

            string authorOfBook = IsValidName(userInputAuthor);
            if (authorOfBook == null)
            {
                return false;
            }

            string isbnOfBook = IsValidISBN(userInputISBN);
            if (isbnOfBook == null)
            {
                return false;
            }

            directoryOfBooks.Add(new book(nameOfBook, authorOfBook, isbnOfBook));
            return true;
        }

        /// <summary>
        /// It will edit the name of the book alone in the product
        /// </summary>
        /// <param name="directoryOfBooks">It take the reference of the list of book from the main method</param>
        /// <param name="position">It takes the Position of the element</param>
        /// <param name="nameOfBook">It takes the name of the book</param>
        /// <returns>It returns bool status of the removal of book from the list/returns>
        public static bool EditNameOfProduct(List<book> directoryOfBooks, int position, string nameOfBook)
        {
            if (position > 0 && position <= directoryOfBooks.Count)
            {
                book currentBookInList = directoryOfBooks.ElementAt(position - 1);
                Console.WriteLine("Details of about the book : ");
                DisplayBook(currentBookInList, position);
                nameOfBook = IsValidName(nameOfBook);
                if (nameOfBook == null)
                {
                    return false;
                }

                // temporaryElement1.name = Console.ReadLine() Record type can't able to change the data type
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error!! Cannot able to change the value in record");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Position");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return false;
        }

        /// <summary>
        /// Display all the books that are present in the book of list
        /// </summary>
        /// <param name="bookDetails">It takes the book details as the book format</param>
        /// <param name="positionOfBook">It takes the position book in the list to be printed</param>
        public static void DisplayBook(book bookDetails, int positionOfBook)
        {
            var (name, author, isbn) = bookDetails;
            Console.WriteLine($"\n{positionOfBook}. Name : {name}");
            Console.WriteLine($"   Author : {author}");
            Console.WriteLine($"   ISBN : {isbn}");
        }

        /// <summary>
        /// Method is to validate title of the book and author of the book
        /// </summary>
        /// <param name="name">It takes the title or author name of the book to be validated</param>
        /// <returns>It returns valid title / name of author of the book</returns>
        public static string IsValidName(string name)
        {
            Regex pattern = new Regex("^[a-zA-Z\\s]+$");
            if (pattern.IsMatch(name))
            {
                return name;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Name");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return null;
        }

        /// <summary>
        /// Method is to validate ISBN number of the book
        /// </summary>
        /// <param name="isbn">It takes the ISBN number of the book</param>
        /// <returns>It returns valid ISBN number of the product</returns>
        public static string IsValidISBN(string isbn)
        {
            Regex pattern = new Regex("^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\\d-]+$");
            if (pattern.IsMatch(isbn))
            {
                return isbn;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ISBN number");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return null;
        }
    }
}