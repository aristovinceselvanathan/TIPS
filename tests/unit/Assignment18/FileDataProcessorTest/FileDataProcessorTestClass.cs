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
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            
            // Act
            DataProcessor.ReadFromTheFile("nonexistent.txt", TestDestinationFilePath);

            // Assert
            Assert.Contains("Source file doesn't exists", sw.ToString());
        }

        [Fact]
        public void ReadFromTheFile_DestinationFileDoesNotExist()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            DataProcessor.ReadFromTheFile(TestSourceFilePath, "nonexistent.txt");

            // Assert
            Assert.Contains("Destination file doesn't exists", sw.ToString());
        }

        [Fact]
        public void SaveTheProcessedData_SourceFileDoesNotExist()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            DataProcessor.SaveTheProcessedData("nonexistent.txt", TestDestinationFilePath);

            //Assert
            Assert.Contains("File path is doesn't exist!!!", sw.ToString());
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