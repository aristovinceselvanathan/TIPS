using DataAcquisitionSystem;

namespace DataAcquisitionSystemTest
{
    public class UtilityTest
    {
        [Theory]
        [InlineData("Temperature\n", "Temperature")]
        [InlineData("Current\n", "Current")]
        [InlineData("1345\n", "1345")]
        public void UtlityIntialization_GetTheStringInput_IsStringReturned(string userInput, string expectedOutput)
        {
            StringReader stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            string actualOutput = Utility.GetStringInput("Test");

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("124\n", 124)]
        [InlineData("Hello\n1\n", 1)]
        [InlineData("Hi\n3\n", 3)]
        public void UtlityIntialization_GetTheIntegerInput_IsIntegerReturned(string UserInput, int expectedOutput)
        {

            StringReader stringReader = new StringReader(UserInput);
            Console.SetIn(stringReader);
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            int actualOutput = Utility.GetIntegerInput("Test");

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
