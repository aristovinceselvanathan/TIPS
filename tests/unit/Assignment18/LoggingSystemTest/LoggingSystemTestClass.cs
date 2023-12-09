using LoggingSystem;

namespace LoggingSystemTest
{
    public class LoggingSystemTestClass
    {
        private const string TestLogFilePath = "test_log.txt";

        [Fact]
        public void LogError_FileExists()
        {
            // Arrange
            File.WriteAllText(TestLogFilePath, "Test log data.");

            // Act
            Logger.LogError("Test error message", 1);

            // Assert
            Assert.True(File.Exists(TestLogFilePath));

            // Clean up by deleting the test log file
            File.Delete(TestLogFilePath);
        }

        [Fact]
        public void LogError_FileDoesNotExist()
        {
            // Act
            Logger.LogError("Test error message", 2);

            // Assert
            Assert.False(File.Exists(TestLogFilePath));
        }

        [Fact]
        public void ReadTheLogFile_FileExists()
        {
            // Arrange
            File.WriteAllText(TestLogFilePath, "Test log data.");

            // Act
            Logger.ReadTheLogFile();

            // Assert
            Assert.True(File.Exists(TestLogFilePath));
            Assert.Equal("Test log data.", File.ReadAllText(TestLogFilePath));

            // Clean up by deleting the test log file
            File.Delete(TestLogFilePath);
        }

        [Fact]
        public void InvalidFilePath_ReadTheLogFile_FileExists()
        {
            // Arrange
            File.WriteAllText(TestLogFilePath, "efwefwefwefw");

            // Act
            Logger.ReadTheLogFile();

            // Assert
            Assert.True(File.Exists(TestLogFilePath));
            Assert.Equal("efwefwefwefw", File.ReadAllText(TestLogFilePath));

            // Clean up by deleting the test log file
            File.Delete(TestLogFilePath);
        }

        [Fact]
        public void ReadTheLogFile_FileDoesNotExist()
        {
            // Act
            Logger.ReadTheLogFile();

            // Assert
            Assert.False(File.Exists(TestLogFilePath));
        }
    }
}