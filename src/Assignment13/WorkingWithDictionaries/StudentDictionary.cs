namespace WorkingWithDictionaries
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Student Dictionary Class
    /// </summary>
    /// <typeparam name="T1">It takes the type of the Data for Parameter1</typeparam>
    /// <typeparam name="T2">It takes the type of the Data for Parameter2</typeparam>
    public class StudentDictionary<T1, T2>
    {
        /// <summary>
        /// Method add the Student name and grade to the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        /// <param name="studentName"> It takes the name of the Student</param>
        /// <param name="gradeOfStudent">It takes the grade of the Student</param>
        /// <returns>It returns status of the addition of student to Directory</returns>
        public static bool Add(Dictionary<T1, T2> studentDirectory, T1 studentName, T2 gradeOfStudent)
        {
            int sizeOfDirectory = studentDirectory.Count();

            if (sizeOfDirectory >= 0 && sizeOfDirectory < 5)
            {
                studentDirectory.Add(studentName, gradeOfStudent);
                return true;
            }
            else
            {
                Program.WarningMessageFromConsole("Directory is Full!!! \n- Please remove a Student to perform the action");
            }

            return false;
        }

        /// <summary>
        /// Method to remove the student details from the Directory
        /// </summary>
        /// <param name="studentDirectory">Reference to the Dictionary contains names and grades of the Students</param>
        /// <param name="nameOfStudent"> It takes the name of the name</param>
        /// <returns>It returns status of the removal of student</returns>
        public static bool Remove(Dictionary<T1, T2> studentDirectory, T1 nameOfStudent)
        {
            int sizeOfDirectory = studentDirectory.Count();

            if (sizeOfDirectory > 0 && sizeOfDirectory <= 5)
            {
                if (studentDirectory.Remove(nameOfStudent))
                {
                    Program.SuccessfulMessageFromConsole("Student is removed Successfully");
                    Console.WriteLine($"Size of the Directory : {sizeOfDirectory - 1}");
                    return true;
                }
                else
                {
                    Program.WarningMessageFromConsole("Operation is unsuccessful");
                }
            }
            else
            {
                Program.WarningMessageFromConsole("Dictionary is Full");
            }

            return false;
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
        /// <param name="name">Name of the Student</param>
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
