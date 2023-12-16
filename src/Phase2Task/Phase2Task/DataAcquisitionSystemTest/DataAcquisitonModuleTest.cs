using DataAcquisitionSystem;

namespace DataAcquisitionSystemTest
{
    /// <summary>
    /// The data acquisiton module test.
    /// </summary>
    public class DataAcquisitonModuleTest
    {
        [Fact]
        public void DataAcquistionIntialization_GenerateData_IsDataGenerated()
        {
            ComplianceModule complianceModule = new ComplianceModule();   
            Parameter current = new Parameter(100, 50, "Current");
            Parameter temperature = new Parameter(80, 30, "Temperature");
            complianceModule.ChangeParameters(current);
            complianceModule.ChangeParameters(temperature);
            DataAcquisitionModule dataAcquisitionModule = new DataAcquisitionModule(complianceModule);

            dataAcquisitionModule.GenerateData(FileOperations.LoadSettingsFromJson());

            Assert.True(dataAcquisitionModule.Parameters["Current"] != 0);
            Assert.True(dataAcquisitionModule.Parameters["Temperature"] != 0);
        }
    }
}