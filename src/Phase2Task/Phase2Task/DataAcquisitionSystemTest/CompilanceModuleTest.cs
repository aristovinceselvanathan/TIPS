using DataAcquisitionSystem;

namespace DataAcquisitionSystemTest
{
    /// <summary>
    /// The compilance module test.
    /// </summary>
    public class CompilanceModuleTest
    {
        [Fact]
        public void CompilanceModuleIntialization_SetParameter_IsParameterSet()
        {
            ComplianceModule complianceModule = new ComplianceModule();

            complianceModule.SetParameters(Parameter.ParameterType.Current, 200, 100);

            Assert.Equal(complianceModule.Parameters.ElementAt(0).HighValue, 200);
        }
        [Fact]
        public void CompilanceModuleIntialization_SetParameters_IsParameterSet()
        {
            ComplianceModule complianceModule = new ComplianceModule();
            List<Parameter> parameters = new List<Parameter>();
            Parameter current = new Parameter(100, 50, Parameter.ParameterType.Current);
            Parameter temperature = new Parameter(80, 40, Parameter.ParameterType.Temperature);
            parameters.Add(current);
            parameters.Add(temperature);

            complianceModule.ChangeParameters(parameters);

            Assert.Equal(complianceModule.Parameters.ElementAt(0).HighValue, 100);
        }
    }
}