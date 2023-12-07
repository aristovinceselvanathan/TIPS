using Moq;
using Logger;

namespace LoggerTest
{
    public class LoggerTestClass
    {
        [Fact]
        public void LoggingSystemInstance_LogMethod_IsInvokesLogger()
        {
            // Arrange
            var loggingSystem1 = LoggingSystem.Instance;
            var loggingSystem2 = LoggingSystem.Instance;

            // Act
            loggingSystem1.LogMethod("Test message", "JSON");
            loggingSystem2.LogMethod("Hello", "PlainText");

            // Assert
            Assert.Equal(loggingSystem1, loggingSystem2);
        }

        [Fact]
        public void LoggingSystemInstance_LogMethod_IsLoggingDone()
        {
            // Arrange
            var loggingSystem1 = LoggingSystem.Instance;
            var loggingSystem2 = LoggingSystem.Instance;
            StringWriter result = new StringWriter();
            Console.SetOut(result);

            // Act
            loggingSystem1.LogMethod("Test message", "JSON");
            loggingSystem2.LogMethod("Hello", "PlainText");
            string resultOfProgram = result.ToString().Trim();

            // Assert
            Assert.Contains("Hello", resultOfProgram);
            Assert.Contains("Test message", resultOfProgram);
        }

        [Fact]
        public void JsonObject_JSONLogger_IsLoggingDone()
        {
            // Arrange
            JSONLogger log = new JSONLogger();
            StringWriter result = new StringWriter();
            Console.SetOut(result);

            // Act
            log.Log("Test message");
            string resultOfProgram = result.ToString().Trim();

            // Assert
            Assert.Contains("Test message", resultOfProgram);
        }

        [Fact]
        public void PlainTextLoggerObject_PlainTextLogger_IsLoggingDone()
        {
            // Arrange
            PlainTextLogger log = new PlainTextLogger();
            StringWriter result = new StringWriter();
            Console.SetOut(result);

            // Act
            log.Log("Test message");
            string resultOfProgram = result.ToString().Trim();

            // Assert
            Assert.Contains("Test message", resultOfProgram);
        }
    }
}