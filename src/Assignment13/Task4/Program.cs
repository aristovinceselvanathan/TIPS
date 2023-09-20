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
                            DisplayAll(studentDirectory);
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
        /// Method add the Student name and grade into the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        public static void Add(Dictionary<string, int> studentDirectory)
        {
            string nameOfStudent;
            int gradeOfStudent, size = studentDirectory.Count();
            bool flag = true;

            if (size >= 0 && size < 5)
            {
                while (flag)
                {
                    Console.Write("Enter the name of a Student to add: ");
                    nameOfStudent = Console.ReadLine().Trim();
                    if (!ValidNameOfStudent(nameOfStudent))
                    {
                        WarningMessageFromConsole("Invalid Name of the Student");
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
                        while (flag)
                        {
                            Console.Write("Enter the Grade of the student (CGPA) : ");
                            if (int.TryParse(Console.ReadLine(), out gradeOfStudent) && (gradeOfStudent >= 0 && gradeOfStudent <= 10))
                            {
                                studentDirectory.Add(nameOfStudent, gradeOfStudent);
                                SuccessfulMessageFromConsole("Student added successfully");
                                Console.WriteLine($"Size of the Directory : {size + 1}");
                                flag = false;
                            }
                            else
                            {
                                WarningMessageFromConsole("Invalid Grade");
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
                    }
                    else
                    {
                        WarningMessageFromConsole("Student name is already present in the Directory");
                    }
                }
            }
            else
            {
                WarningMessageFromConsole("Directory is Full!!! \n- Please remove a Student to perform the action");
            }
        }

        /// <summary>
        /// Method to remove the student from the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        public static void Remove(Dictionary<string, int> studentDirectory)
        {
            int size = studentDirectory.Count();
            string nameOfStudent;
            bool flag = true;

            if (size > 0 && size <= 5)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the Name of the Student to remove: ");
                    nameOfStudent = Console.ReadLine().Trim();
                    if (ValidNameOfStudent(nameOfStudent))
                    {
                        if (studentDirectory.Remove(nameOfStudent))
                        {
                            SuccessfulMessageFromConsole("Student is removed Successfully}");
                            Console.WriteLine($"Size of the Directory : {size - 1}");
                            flag = false;
                        }
                        else
                        {
                            WarningMessageFromConsole("Operation is unsuccessful");
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
            else
            {
                WarningMessageFromConsole("Directory is Empty!!! - Please add the student to perform the action");
            }
        }

        /// <summary>
        /// Method displays all the name and grades of the Students present in the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        public static void DisplayAll(Dictionary<string, int> studentDirectory)
        {
            if (studentDirectory.Count() > 0)
            {
                Console.WriteLine("Directory of Students : ");
                foreach (var item in studentDirectory)
                {
                    Console.WriteLine($"{item.Key} : {item.Value},");
                }
            }
            else
            {
                WarningMessageFromConsole("Directory is Empty!!! - Nothing to Display");
            }
        }

        /// <summary>
        /// It checks for the name matches the alphabetic pattern
        /// </summary>
        /// <param name="name">name of the Student</param>
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