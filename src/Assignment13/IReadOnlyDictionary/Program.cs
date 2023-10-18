namespace IReadOnlyDictionary
{
    using ConsoleTables;

    /// <summary>
    /// Program Class it will have the entry point of program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// It will generate the dictionary using GenerateDictionary and Print using the PrintDictionary
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            IReadOnlyDictionary<string, int> studentDirectory = GenerateDictionary();
            studentDirectory.TryGetValue("Tom Cruise", out int studentMark);

            // studentDirectory.Add("Tom Cruise", studentMark);Add Method is not present in the IReadOnlyDictionary so the key, values are not able to changed.
            Console.WriteLine("Cannot able to add the Key Value To the Dictionary");
            PrintDictionary(studentDirectory);
        }

        /// <summary>
        /// Generate the Dictionary of the Type IReadOnlyDictionary contains some predefined values
        /// </summary>
        /// <returns>Student Science Marks in the form of IReadOnlyDictionary</returns>
        public static IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            Dictionary<string, int> studentRecord = new()
            {
                { "Tom Cruise", 89 },
                { "Tim Hook", 78 },
                { "Lora Croft", 95 },
                { "Jenifer", 81 },
                { "Robert Downey jr", 99 },
            };
            IReadOnlyDictionary<string, int> studentRecordOriginal = studentRecord;
            return studentRecordOriginal;
        }

        /// <summary>
        /// Print the IReadOnlyDictionary contains science marks of the students
        /// </summary>
        /// <param name="studentRecordOriginal">It takes the IReadOnlyDictionary that contains student science marks</param>
        public static void PrintDictionary(IReadOnlyDictionary<string, int> studentRecordOriginal)
        {
            Console.WriteLine("Science Marks of the Student Directory is : ");
            ConsoleTable consoleTable = new ConsoleTable("Name", "Science Marks");
            foreach (var item in studentRecordOriginal)
            {
                consoleTable.AddRow(item.Key, item.Value);
            }

            consoleTable.Write();
        }
    }
}