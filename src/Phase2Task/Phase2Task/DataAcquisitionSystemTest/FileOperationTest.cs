using DataAcquisitionSystem;

namespace DataAcquisitionSystemTest
{
    /// <summary>
    /// The file operation test.
    /// </summary>
    public class FileOperationTest
    {
        [Fact]
        public void FileOperation_LoadData_IsDataRead()
        {
            FileOperations fileOperations = new FileOperations();
            string expectedValue = "Hello";

            FileOperations.LogDataToFile("Hello", "log1.txt");

            Assert.Contains(expectedValue, File.ReadAllText("log.txt"));
        }

        [Fact]
        public void FileOperation_LoadSettingsData_IsSettingsDataRead()
        {
            FileOperations fileOperations = new FileOperations();
            int expectedRateValue = 1;

            DataAcquisitionSettings dataAcquisitionSettings = FileOperations.LoadSettingsFromJson();

            Assert.Equal(expectedRateValue, dataAcquisitionSettings.Rate);
        }
    }
}
