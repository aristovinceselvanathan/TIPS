namespace AsyncExceptionTest
{
    using AsyncExceptions;
    public class AsyncExceptionTestClass
    {
        [Fact]
        public void CallTaskMethod_ThrowsException()
        {
            Assert.ThrowsAsync<Exception>(() => AsyncExceptions.TaskMethod());
        }
    }
}