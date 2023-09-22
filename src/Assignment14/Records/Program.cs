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
                Console.WriteLine("Enter the choice 1.Add a book, 2.Display all the books, 3.Edit the Name ," +
                    "4.Check the Equality, 5.Take the Copy of the Record, 6.Exit");
                if (int.TryParse(Console.ReadLine(), out int userInputOption))
                {
                    Options option = (Options)userInputOption;
                    switch (option)
                    {
                        case Options.Add:
                            Console.WriteLine("Enter the book name : ");
                            string name = IsValidName();
                            if (name == null)
                            {
                                flag = false;
                                break;
                            }

                            Console.WriteLine("Enter the book author name: ");
                            string author = IsValidName();
                            if (author == null)
                            {
                                flag = false;
                                break;
                            }

                            Console.WriteLine("Enter the book ISBN Number: ");
                            string isbn = Console.ReadLine();
                            if (isbn == null)
                            {
                                flag = false;
                                break;
                            }

                            directoryOfBooks.Add(new book(name, author, isbn));
                            break;
                        case Options.DisplayAll:
                            int i = 0;
                            Console.WriteLine("List of the Books : ");
                            foreach (book book in directoryOfBooks)
                            {
                                DisplayBook(book, i++);
                            }

                            break;
                        case Options.Edit:
                            Console.WriteLine("Edit the book name alone");
                            Console.WriteLine("Enter the position of the book : ");
                            if (int.TryParse(Console.ReadLine(), out int position) && position > 0 && position <= directoryOfBooks.Count)
                            {
                                book temporaryElement1 = directoryOfBooks.ElementAt(position - 1);
                                Console.WriteLine("Enter the name : ");
                                string nameOfBook = IsValidName();
                                if (nameOfBook == null)
                                {
                                    flag = false;
                                    break;
                                }

                                // temp.name = nameOfBook; Record type can't able to change the data type
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error!! Cannot able to change the value in record");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;
                        case Options.Equality:
                            Console.WriteLine("Get the Details of the Book at index : ");
                            if (int.TryParse(Console.ReadLine(), out position) && position > 0 && position <= directoryOfBooks.Count)
                            {
                                book temporaryElement = directoryOfBooks.ElementAt(position - 1);
                                Console.WriteLine(temporaryElement);
                                Console.WriteLine("To Check Value Equality");
                                Console.WriteLine("Creating the another book from this data...");
                                Console.WriteLine($"Check the Equality of the two Records : {temporaryElement == new book(temporaryElement.name, temporaryElement.author, temporaryElement.isbn)}");
                            }

                            break;
                        case Options.TakeCopy:
                            Console.WriteLine("Get the Details of the Book at index : ");
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
            }
        }

        /// <summary>
        /// Display Books
        /// </summary>
        /// <param name="b">Book</param>
        /// <param name="index">It tells the position</param>
        public static void DisplayBook(book b, int index)
        {
            var (name, author, isbn) = b;
            Console.WriteLine($"{index}.\nName : {name}");
            Console.WriteLine($"Author : {author}");
            Console.WriteLine($"ISBN : {isbn}");
        }

        /// <summary>
        /// Method is to validate name
        /// </summary>
        /// <returns>It returns valid name of the product</returns>
        public static string IsValidName()
        {
            string name = Console.ReadLine();
            Regex pattern = new Regex("^[a-zA-Z\\s]*$");
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
                return IsValidName();
            }
        }

        /// <summary>
        /// Method is to validate name
        /// </summary>
        /// <returns>It returns valid name of the product</returns>
        public static string IsValidISBN()
        {
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
                return IsValidName();
            }
        }
    }
}