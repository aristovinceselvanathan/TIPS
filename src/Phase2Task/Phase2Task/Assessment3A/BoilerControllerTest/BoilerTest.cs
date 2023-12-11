using BoilerController;

namespace BoilerControllerTest
{
    public class BoilerTest
    {

        [Fact]
        public void BoilerInstance_ToggleInterLockClosed_IsInterLockToggled()
        {
            Boiler boiler = new Boiler();
            InterLock.InterLockState expectedInterLock = InterLock.InterLockState.Closed;
            boiler.SwitchInterLock();

            Assert.Equal(expectedInterLock, boiler.currentInterLockStatus.InterLockSwitch);
        }

        [Fact]
        public void BoilerInstance_ToggleInterLockOpen_IsInterLockToggled()
        {
            Boiler boiler = new Boiler();
            InterLock.InterLockState expectedInterLock = InterLock.InterLockState.Open;
            boiler.SwitchInterLock();
            boiler.SwitchInterLock();

            Assert.Equal(expectedInterLock, boiler.currentInterLockStatus.InterLockSwitch);
        }
        [Fact]
        public void SwitchedInterLock_ToggleResetLock_IsResetLockToggled()
        {
            Boiler boiler = new Boiler();
            Boiler.Reset expectedResetLock = Boiler.Reset.Closed;

            boiler.SwitchInterLock();
            boiler.ResetLock();

            Assert.Equal(expectedResetLock, boiler.resetLock);
        }

        [Fact]
        public void NotSwitchedInterLock_ToggleResetLock_IsResetLockToggled()
        {
            Boiler boiler = new Boiler();
            Boiler.Reset expectedResetLock = Boiler.Reset.Open;

            boiler.ResetLock();

            Assert.Equal(expectedResetLock, boiler.resetLock);
        }
    }
}