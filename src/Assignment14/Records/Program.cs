namespace Task6
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        public record book(string name, string author, string isbn)
        {
            /// <summary>
            /// Override the ToString Method of the object
            /// </summary>
            /// <returns>string to print the details</returns>
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
        /// Method that takes the details about the book
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            List<book> directoryOfBooks = new List<book>();
            bool flag = true;

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
                            flag = AddBook(directoryOfBooks);
                            if (!flag)
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
                            flag = EditNameOfProduct(directoryOfBooks);
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
                                var temp1 = temporaryElement with { name = "Book of Persia", author = "Nivia" };
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
        /// It add the book into the list
        /// </summary>
        /// <param name="directoryOfBooks"> It take the reference of the list from the main</param>
        /// <returns>It returns bool to whether to terminate the process</returns>
        public static bool AddBook(List<book> directoryOfBooks)
        {
            string name = IsValidName("Book");
            if (name == null)
            {
                return false;
            }

            string author = IsValidName("Author");
            if (author == null)
            {
                return false;
            }

            string isbn = IsValidISBN();
            if (isbn == null)
            {
                return false;
            }

            directoryOfBooks.Add(new book(name, author, isbn));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Added Successfully");
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }

        /// <summary>
        /// It will edit the name of the book alone in the product
        /// </summary>
        /// <param name="directoryOfBooks">It take the reference of the list of book from the main method</param>
        /// <returns>It returns bool to whether to terminate the process</returns>
        public static bool EditNameOfProduct(List<book> directoryOfBooks)
        {
            Console.WriteLine("Edit the Book Name Alone");
            Console.Write("Enter the position of the book : ");
            if (int.TryParse(Console.ReadLine(), out int position) && position > 0 && position <= directoryOfBooks.Count)
            {
                book temporaryElement1 = directoryOfBooks.ElementAt(position - 1);
                Console.WriteLine("Details of about the book : ");
                DisplayBook(temporaryElement1, position);
                Console.Write("Enter the name : ");
                string nameOfBook = IsValidName("Book");
                if (nameOfBook == null)
                {
                    return false;
                }

                // temp.name = nameOfBook; Record type can't able to change the data type
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

            return true;
        }

        /// <summary>
        /// Display Books
        /// </summary>
        /// <param name="b">Book</param>
        /// <param name="index">It tells the position</param>
        public static void DisplayBook(book b, int index)
        {
            var (name, author, isbn) = b;
            Console.WriteLine($"\n{index}. Name : {name}");
            Console.WriteLine($"   Author : {author}");
            Console.WriteLine($"   ISBN : {isbn}");
        }

        /// <summary>
        /// Method is to validate name
        /// </summary>
        /// <returns>It returns valid name of the product</returns>
        /// <param name="type">Type of the input</param>
        public static string IsValidName(string type)
        {
            Console.Write($"Enter the {type} Name : ");
            string name = Console.ReadLine();
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
                Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return null;
                }

                Console.Clear();
                return IsValidName(type);
            }
        }

        /// <summary>
        /// Method is to validate name
        /// </summary>
        /// <returns>It returns valid name of the product</returns>
        public static string IsValidISBN()
        {
            Console.Write("Enter the book ISBN Number: ");
            string name = Console.ReadLine();
            Regex pattern = new Regex("^\\d{9}[\\d|X]$|^(\\d{3}-){2}\\d{3}-[\\d|X]$");
            if (pattern.IsMatch(name))
            {
                return name;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ISBN number");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press Escape key to Exit and Other key to continue....");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return null;
                }

                Console.Clear();
                return IsValidISBN();
            }
        }
    }
}