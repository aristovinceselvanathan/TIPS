namespace ConfigureAwaitTest
{
    using ConfigureAwait;
    public class ConfigureAwaitTestClass
    {
        [Fact]
        public async void CallMethodA_Returns45()
        {
            //Act
            var thread1 = Thread.CurrentThread.ManagedThreadId;
            await Program.MethodA();
            var thread2 = Thread.CurrentThread.ManagedThreadId;

            //Assert
            Assert.NotEqual(thread1, thread2);
        }
    }
}