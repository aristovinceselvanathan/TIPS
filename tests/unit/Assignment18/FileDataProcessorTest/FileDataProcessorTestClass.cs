using FileDataProcessor;
using System.Text;

namespace FileDataProcessorTest
{
    public class FileDataProcessorTestClass
    {
        private const string TestSourceFilePath = "test_source.txt";
        private const string TestDestinationFilePath = "test_destination.txt";

        [Fact]
        public void ReadFromTheFile_SourceFileDoesNotExist()
        {
            // Arrange
            string expectedOutput = "Source file doesn't exists";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            
            // Act
            DataProcessor.ReadFromTheFile("nonexistent.txt", TestDestinationFilePath);

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void ReadFromTheFile_DestinationFileDoesNotExist()
        {
            // Arrange
            string expectedOutput = "Destination file doesn't exists";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            DataProcessor.ReadFromTheFile(TestSourceFilePath, "nonexistent.txt");

            // Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void SaveTheProcessedData_SourceFileDoesNotExist()
        {
            // Arrange
            string expectedOutput = "The file does not exist!!!";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            DataProcessor.SaveTheProcessedData("nonexistent.txt", TestDestinationFilePath);

            //Assert
            Assert.Contains(expectedOutput, sw.ToString());
        }

        [Fact]
        public void SaveTheProcessedData_DestinationFileDoesNotExist()
        {
            // Arrange
            File.WriteAllText(TestSourceFilePath, "Test data to process.");

            // Act
            DataProcessor.SaveTheProcessedData(TestSourceFilePath, "nonexistent.txt");

            // Assert
            Assert.False(File.Exists("nonexistent.txt"));

            // Clean up by deleting the test source file
            File.Delete(TestSourceFilePath);
        }

        [Fact]
        public void SaveTheProcessedData_SourceAndDestinationFilesExist()
        {
            // Arrange
            File.WriteAllText(TestSourceFilePath, "Test data to process.");

            // Act
            DataProcessor.SaveTheProcessedData(TestSourceFilePath, TestDestinationFilePath);

            // Assert
            Assert.True(File.Exists(TestSourceFilePath));
            Assert.True(File.Exists(TestDestinationFilePath));
            Assert.Contains(HeplerMethod(TestSourceFilePath).ToLower(), HeplerMethod(TestDestinationFilePath).ToLower());
        }
        private string HeplerMethod(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024]; // Choose an appropriate buffer size
                    int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    string fileContent = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    return fileContent;
                }
            }
            else
            {
                Console.WriteLine("File Doesn't Exists");
                return string.Empty;
            }
        }
    }
}