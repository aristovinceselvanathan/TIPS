namespace BasicFileUsageTest
{
    using BasicFileUsage;
    using System.Text;

    public class BasicFileUsageTestClass
    {
        [Fact]
        public void FilePaths_AddDataToFile_WritesAndReadsDataCorrectly()
        {
            // Arrange
            string filePath = "testFile.txt";
            string testData = "Test data to write and read.";

            // Act
            Program.AddDataToFile(filePath, testData);

            // Assert
            Assert.True(File.Exists(filePath));
            Assert.Equal(testData, this.HeplerMethod(filePath));
            // Clean up by deleting the test file
            File.Delete(filePath);
        }

        [Fact]
        public void InvalidFilePaths_AddDataToFile_IsWritesAndReadsDataCorrectly()
        {
            // Arrange
            string filePath = "testewfewrFile";
            string testData = "Test data to write and read.";

            // Act
            Program.AddDataToFile(filePath, testData);

            // Assert
            Assert.False(File.Exists(filePath));
            Assert.NotEqual(testData, this.HeplerMethod(filePath));
        }

        [Fact]
        public void Empty_AddDataToFile_IsWritesAndReadsDataCorrectly()
        {
            // Arrange
            string filePath = string.Empty;
            string testData = string.Empty;

            // Act
            Program.AddDataToFile(filePath, testData);

            // Assert
            Assert.False(File.Exists(filePath));
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