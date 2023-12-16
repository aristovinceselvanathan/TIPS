using DataAcquisitionSystem;

namespace DataAcquisitionSystemTest
{
    /// <summary>
    /// The compliance module test.
    /// </summary>
    public class ComplianceModuleTest
    {
        [Fact]
        public void CompilanceModuleIntialization_SetParameters_IsParameterSet()
        {
            ComplianceModule complianceModule = new ComplianceModule();
            List<Parameter> parameters = new List<Parameter>();
            Parameter current = new Parameter(100, 50, "Current");
            Parameter temperature = new Parameter(80, 40, "Temperature");

            complianceModule.ChangeParameters(current);
            complianceModule.ChangeParameters(temperature);

            Assert.Equal(complianceModule.Parameters.ElementAt(0).HighValue, 100);
        }

        [Fact]
        public void CompilanceModuleIntialization_SetDifferentParameterValue_IsParameterSet()
        {
            ComplianceModule complianceModule = new ComplianceModule();
            List<Parameter> parameters = new List<Parameter>();
            Parameter current = new Parameter(100, 50, "Humidity");
            Parameter temperature = new Parameter(80, 40, "Temperature");

            complianceModule.ChangeParameters(current);
            complianceModule.ChangeParameters(temperature);

            Assert.Equal(complianceModule.Parameters.ElementAt(1).HighValue, 80);
        }

        [Fact]
        public void CompilanceModuleIntialization_SetDifferentParametersType_IsParameterSet()
        {
            ComplianceModule complianceModule = new ComplianceModule();
            List<Parameter> parameters = new List<Parameter>();
            Parameter current = new Parameter(100, 50, "Humidity");
            Parameter temperature = new Parameter(80, 40, "Temperature");

            complianceModule.ChangeParameters(current);
            complianceModule.ChangeParameters(temperature);

        }
    }
}