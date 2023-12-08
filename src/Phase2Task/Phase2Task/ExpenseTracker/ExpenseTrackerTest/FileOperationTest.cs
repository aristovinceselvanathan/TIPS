using ExpenseTracker;

namespace ExpenseTrackerTest
{
    public class FileOperationTest
    {
        [Fact]
        public void FileOperation_LoadToTheFile_IsDataAdded()
        {
            FileOperation<Expense> fileOperation = new FileOperation<Expense>();
            List<Expense> expenses = new List<Expense>() {new Expense(DateTime.Now, 200, "Tea")};
            string expectedOutput = "Tea";

            fileOperation.LoadToTheFile("Expense.json", expenses);

            Assert.Contains(expectedOutput, File.ReadAllText("..\\..\\..\\Data\\Expense.json"));
        }
        [Fact]
        public void FileOperation_LoadFromTheFile_IsDataObtained()
        {
            FileOperation<Expense> fileOperation = new FileOperation<Expense>();
            List<Expense> expectedexpenses = new List<Expense>() { new Expense(DateTime.Now, 200, "Tea") };

            fileOperation.LoadToTheFile("Expense.json", expectedexpenses);
            List<Expense> actualOutput = fileOperation.LoadFromTheFile("Expense.json");

            Assert.NotEmpty(actualOutput);
        }
        [Fact]
        public void FileOperation_LogToTheFile_IsDataAdded()
        {
            FileOperation<Expense> fileOperation = new FileOperation<Expense>();
            string expectedOutput = "Hello";

            fileOperation.LogToTheFile("log", "Hello");

            Assert.Contains(expectedOutput, File.ReadAllText("..\\..\\..\\Data\\log.txt"));
        }

    }
}
