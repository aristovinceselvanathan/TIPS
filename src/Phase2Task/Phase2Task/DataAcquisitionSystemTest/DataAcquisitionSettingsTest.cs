using DataAcquisitionSystem;

namespace DataAcquisitionSystemTest
{
    /// <summary>
    /// The data acquisition settings test.
    /// </summary>
    public class DataAcquisitionSettingsTest
    {
        [Fact]
        public void DataAcquistionSettingsIntialization_ConstructorSetValue_IsValueUpadted()
        {
            DataAcquisitionSettings dataAcquisitionSettings;
            List<Parameter> parameters = new List<Parameter>();

            dataAcquisitionSettings = new DataAcquisitionSettings(1, parameters);

            Assert.Equal(1, dataAcquisitionSettings.Rate);
        }
    }
}