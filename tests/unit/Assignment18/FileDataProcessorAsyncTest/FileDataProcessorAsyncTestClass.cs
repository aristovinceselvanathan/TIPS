namespace FileDataProcessorAsyncTest
{
    public class FileDataProcessorAsyncTestClass
    {
        private const string TestSourceDir = "test_source";
        private const string TestDestinationDir = "test_destination";

        [Fact]
        public async Task ProcessFileToUpperCaseAsync_WithValidFiles()
        {
            // Arrange
            Directory.CreateDirectory(TestSourceDir);
            Directory.CreateDirectory(TestDestinationDir);

            File.WriteAllText(Path.Combine(TestSourceDir, "file1.txt"), "Test data 1.");

            string sourceFilePath = Path.Combine(TestSourceDir, "file1.txt");
            string destinationFilePath = Path.Combine(TestDestinationDir, "file1.txt");

            // Act
            await FileDataProcessorAsync.FileDataProcessorAsync.ProcessFileToUpperCaseAsync(sourceFilePath, destinationFilePath);

            // Assert
            Assert.True(File.Exists(sourceFilePath));
            Assert.True(File.Exists(destinationFilePath));

            using (StreamReader reader = new StreamReader(destinationFilePath))
            {
                string content = await reader.ReadToEndAsync();
                Assert.Contains("TEST DATA 1.", content);
            }

            // Clean up by deleting the test directories
            Directory.Delete(TestSourceDir, true);
            Directory.Delete(TestDestinationDir, true);
        }
    }
}