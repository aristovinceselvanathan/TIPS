using BoilerController;
using System.Globalization;

namespace BoilerControllerTest
{
    public class FileOperationTest
    {
        [Fact]
        public void FileOperation_LogToTheFile_IsLoggedFile()
        {
            string expectedOutput = "Error Occurred";

            File.Create("log1.csv").Close();
            FileOperation.LogToTheFile("Error Occurred", false, "log1");

            Assert.Contains(expectedOutput, File.ReadAllText("log1.csv"));
        }

        [Fact]
        public void FileOperation_LoadLogFromTheFile_IsLoggedFile()
        {
            string expectedOutput = "Error Occurred";

            File.Create("log2.csv").Close();
            File.WriteAllText("log2.csv", "Error Occurred");
            string actualOutput = FileOperation.LogFromTheFile("log2");

            Assert.Contains(expectedOutput, actualOutput);
        }

        [Fact]
        public void FileDoesExist_LoadLogFromTheFile_IsLoggedFile()
        {
            string expectedOutput = "Log File data not found";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            FileOperation.LogFromTheFile("log3");

            Assert.Contains(expectedOutput, stringWriter.ToString());
        }
    }
}
