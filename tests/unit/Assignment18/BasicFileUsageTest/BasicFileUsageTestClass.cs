namespace BasicFileUsageTest
{
    using BasicFileUsage;
    using System.Text;

    public class BasicFileUsageTestClass
    {
        [Fact]
        public void AddDataToFile_WritesAndReadsDataCorrectly()
        {
            // Arrange
            string filePath = "testFile.txt";
            string testData = "Test data to write and read.";

            // Act
            Program.AddDataToFile(filePath, testData);

            // Assert
            Assert.True(File.Exists(filePath), "File should exist after writing data.");

            // Read the data from the file and check if it matches the testData
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024]; // Choose an appropriate buffer size
                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                string fileContent = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                Assert.Equal(testData, fileContent);
            }

            // Clean up by deleting the test file
            File.Delete(filePath);
        }
    }
}