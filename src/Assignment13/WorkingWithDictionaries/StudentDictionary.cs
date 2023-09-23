namespace WorkingWithDictionaries
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Student Dictionary Class that contains the entry point of the program
    /// </summary>
    /// <typeparam name="T1">It takes the type of the Data for Parameter1</typeparam>
    /// <typeparam name="T2">It takes the type of the Data for Parameter2</typeparam>
    internal class StudentDictionary<T1, T2>
    {
        /// <summary>
        /// Method add the Student name and grade to the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        public void Add(Dictionary<T1, T2> studentDirectory)
        {
            T1 nameOfStudent;
            int sizeOfDirectory = studentDirectory.Count();
            bool flag = true;

            if (sizeOfDirectory >= 0 && sizeOfDirectory < 5)
            {
                while (flag)
                {
                    Console.Write("Enter the name of a Student to add: ");
                    nameOfStudent = TryConvert1(Console.ReadLine().Trim());
                    if (!this.ValidNameOfStudent(nameOfStudent))
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
                        while (flag)
                        {
                            Console.Write("Enter the Grade of the student (CGPA) : ");
                            if (int.TryParse(Console.ReadLine(), out int userGradeOfStudent) && (userGradeOfStudent >= 0 && userGradeOfStudent <= 10))
                            {
                                studentDirectory.Add(nameOfStudent, TryConvert2(userGradeOfStudent));
                                Program.WarningMessageFromConsole("Student added successfully");
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
                    }
                    else
                    {
                        Program.WarningMessageFromConsole("Student name is already present in the Directory");
                    }
                }
            }
            else
            {
                Program.WarningMessageFromConsole("Directory is Full!!! \n- Please remove a Student to perform the action");
            }
        }

        /// <summary>
        /// Method to remove the student details from the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        public void Remove(Dictionary<T1, T2> studentDirectory)
        {
            int sizeOfDirectory = studentDirectory.Count();
            string nameOfStudent;
            bool flag = true;

            if (sizeOfDirectory > 0 && sizeOfDirectory <= 5)
            {
                while (flag)
                {
                    Console.WriteLine("Enter the Name of the Student to remove: ");
                    nameOfStudent = Console.ReadLine().Trim();
                    if (this.ValidNameOfStudent(TryConvert1(nameOfStudent)))
                    {
                        if (studentDirectory.Remove(TryConvert1(nameOfStudent)))
                        {
                            Program.WarningMessageFromConsole("Student is removed Successfully}");
                            Console.WriteLine($"Size of the Directory : {sizeOfDirectory - 1}");
                            flag = false;
                        }
                        else
                        {
                            Program.WarningMessageFromConsole("Operation is unsuccessful");
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
                Program.WarningMessageFromConsole("Directory is Empty!!! - Please add the student to perform the action");
            }
        }

        /// <summary>
        /// Method displays all the name and grades of the Students present in the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        public void DisplayAll(Dictionary<T1, T2> studentDirectory)
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
                Program.WarningMessageFromConsole("Directory is Empty!!! - Nothing to Display");
            }
        }

        /// <summary>
        /// It checks for the name matches the alphabetic pattern
        /// </summary>
        /// <param name="name">name of the Student</param>
        /// <returns>Return true if it matches the condition, Else false</returns>
        public bool ValidNameOfStudent(T1 name)
        {
            Regex pattern = new Regex("^[A-Za-z\\s]+$");
            if (pattern.IsMatch(TryConvertReverse(name)))
            {
                return true;
            }

            return false;
        }

        // Helper method to try to convert a string to type T1
        private static T1 TryConvert1(string input)
        {
            try
            {
                // You can use TypeConverter or parse methods specific to T1's type here
                return (T1)Convert.ChangeType(input, typeof(T1));
            }
            catch
            {
                return default(T1);
            }
        }

        // Helper method to try to convert a int to type T2
        private static T2 TryConvert2(int input)
        {
            try
            {
                // You can use TypeConverter or parse methods specific to T2's type here
                return (T2)Convert.ChangeType(input, typeof(T2));
            }
            catch
            {
                return default(T2);
            }
        }

        // Helper method to try to convert a T1 to type string
        private static string TryConvertReverse(T1 input)
        {
            try
            {
                // You can use TypeConverter or parse methods specific to T1's type here
                return (string)Convert.ChangeType(input, typeof(string));
            }
            catch
            {
                return default(string);
            }
        }
    }
}
