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
            Assert.True(File.Exists(filePath), "File should exist after writing data.");
            Assert.Equal(testData, this.HeplerMethod(filePath));
            // Clean up by deleting the test file
            File.Delete(filePath);
        }

        private string HeplerMethod(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024]; // Choose an appropriate buffer size
                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                string fileContent = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return fileContent;
            }
        }

    }
}