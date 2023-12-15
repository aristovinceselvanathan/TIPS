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
            Parameter current = new Parameter(100, 50, Parameter.ParameterType.Current);
            Parameter temperature = new Parameter(80, 30, Parameter.ParameterType.Temperature);
            complianceModule.Parameters.Add(current);
            DataAcquisitionModule dataAcquisitionModule = new DataAcquisitionModule(complianceModule);
            FileOperations fileOperations = new FileOperations();

            dataAcquisitionModule.GenerateData(FileOperations.LoadSettingsFromJson());

            Assert.True(dataAcquisitionModule.currentValue.Item1 != 0);
            Assert.True(dataAcquisitionModule.currentValue.Item2 != 0);
        }

        [Fact]
        public void DataAcquistionIntialization_DataChanged_IsMethodInvoked()
        {
            ComplianceModule complianceModule = new ComplianceModule();
            Parameter current = new Parameter(100, 50, Parameter.ParameterType.Current);
            Parameter temperature = new Parameter(80, 30, Parameter.ParameterType.Temperature);
            complianceModule.Parameters.Add(current);
            DataAcquisitionModule dataAcquisitionModule = new DataAcquisitionModule(complianceModule);
            FileOperations fileOperations = new FileOperations();
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            string expectedValue = "Exception caught";

            dataAcquisitionModule.GenerateData(FileOperations.LoadSettingsFromJson());

            Assert.True(dataAcquisitionModule.currentValue.Item1 != 0);
            Assert.True(dataAcquisitionModule.currentValue.Item2 != 0);
            Assert.Contains(expectedValue, sw.ToString());
        }
    }
}