using FileDataProcessor;

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
            string expectedOutput = "File path is doesn't exist!!!";
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
        }
    }
}