namespace MultiLayeredAsyncAwait
{
    using MultiLayeredAsyncAwait;
    public class MultiLayeredAsyncAwaitTestClass
    {
        [Fact]
        public async void CallMethodA_ReturnsString()
        {
            //Arrange
            var x = Program.MethodA();
            await x;

            //Assert
            Assert.Equal("56", x.Result);
        }

        [Theory]
        [InlineData("21")]
        [InlineData("23")]
        [InlineData("12")]
        [InlineData("45")]
        [InlineData("29")]
        public async void CallMethodB_ReturnsResponse(string input)
        {
            //Arrange
            var x = Program.MethodB(input);
            await x;

            //Assert
            Assert.NotEmpty(x.Result);
        }

        [Fact]
        public async void CallMethodC_ReturnsCount()
        {
            //Arrange
            var x = Program.MethodC();
            await x;

            //Assert
            Assert.Equal(4, x.Result);
        }
    }
}