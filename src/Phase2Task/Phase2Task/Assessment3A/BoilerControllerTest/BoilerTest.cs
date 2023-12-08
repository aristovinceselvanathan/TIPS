using BoilerConsoleApplication;

namespace BoilerControllerTest
{
    public class BoilerTest
    {
        [Fact]
        public void BoilerInitiation_StopBoilerSequence_CheckTheState()
        {
            Boiler boiler = new Boiler();
            string expectedOutput = "Ready";

            boiler.StopBoilerSequence();

            Assert.Contains(expectedOutput, boiler.BoilerState);
        }

        [Fact]
        public void BoilerInitiation_ToggleInterLockSwitch_InterLockToggled()
        {
            Boiler boiler = new Boiler();
            bool expectedOutput = !boiler.InterLock;

            boiler.ToggleInterLockSwitch();

            Assert.Equal(expectedOutput, boiler.InterLock);
        }

        [Fact]
        public void BoilerInitiation_ResetTheLockout_InterLockToggled()
        {
            Boiler boiler = new Boiler();
            bool expectedOutput = false;

            boiler.ResetLockOut();

            Assert.Equal(expectedOutput, boiler.InterLock);
        }
    }
}