namespace WorkingWithDictionaries
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class that contains entry point of the program
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
                            Add(studentDirectory);
                            break;
                        case Services.Remove:
                            Remove(studentDirectory);
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
        /// Method add the Student name and grade to the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        public static void Add(Dictionary<string, int> studentDirectory)
        {
            string nameOfStudent;
            int sizeOfDirectory = studentDirectory.Count();
            bool flag = true;
            while (flag)
            {
                Console.Write("Enter the name of a Student to add: ");
                nameOfStudent = Console.ReadLine().Trim();
                if (!ValidNameOfStudent(nameOfStudent))
                {
                    Program.WarningMessageFromConsole("Invalid Name of the Student");
                    Console.WriteLine("Press Any key to continue, Press the escape key to exit.....");
                    if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (!studentDirectory.ContainsKey(nameOfStudent))
                {
                    Console.Write("Enter the Grade of the student (CGPA) : ");
                    if (int.TryParse(Console.ReadLine(), out int userGradeOfStudent) && (userGradeOfStudent >= 0 && userGradeOfStudent <= 10))
                    {
                        StudentDictionary<string, int>.Add(studentDirectory, nameOfStudent, userGradeOfStudent);
                        Program.SuccessfulMessageFromConsole("Student added successfully");
                        Console.WriteLine($"Size of the Directory : {sizeOfDirectory + 1}");
                        flag = false;
                    }
                    else
                    {
                        Program.WarningMessageFromConsole("Invalid Grade");
                        Console.WriteLine("Press the escape key to exit.....");
                        Console.WriteLine("Press Any key to continue, Press the escape key to exit.....");
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
                else
                {
                    Program.WarningMessageFromConsole("Student name is already present in the Directory");
                }
            }
        }

        /// <summary>
        /// Method to remove the student details from the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        public static void Remove(Dictionary<string, int> studentDirectory)
        {
            int sizeOfDirectory = studentDirectory.Count();
            string nameOfStudent;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Enter the Name of the Student to remove: ");
                nameOfStudent = Console.ReadLine().Trim();
                if (ValidNameOfStudent(nameOfStudent))
                {
                    if (StudentDictionary<string, int>.Remove(studentDirectory, nameOfStudent))
                    {
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Press Any key to continue, Press the escape key to exit.....");
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
                else
                {
                    Console.WriteLine("Invalid Name");
                    Console.WriteLine("Press Any key to continue, Press the escape key to exit.....");
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

        /// <summary>
        /// It checks for the name matches the alphabetic pattern
        /// </summary>
        /// <param name="name">Name of the Student</param>
        /// <returns>Return true if it matches the condition, Else false</returns>
        public static bool ValidNameOfStudent(string name)
        {
            Regex pattern = new Regex("^[A-Za-z\\s]+$");
            if (pattern.IsMatch(name))
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