namespace DeadLocksTest
{
    using DeadLocks;
    using System.Threading.Tasks;

    public class DeadLocksTestClass
    {
        [Fact]
        public async Task CallDeadLocksMethod_PrintsTextAsync()
        {
            //Act
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            DeadLocks deadLocks = new DeadLocks();

            //Arrange
            await deadLocks.DeadlockMethod();
            string result = stringWriter.ToString().Trim();

            //Assert
            Assert.Contains("Hello, World!", result);

        }
    }
}