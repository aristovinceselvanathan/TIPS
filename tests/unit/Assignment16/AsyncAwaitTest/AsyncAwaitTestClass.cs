namespace AsyncAwaitTest
{
    using AsyncAwait;
    using System.Threading.Tasks;

    public class UnitTest1
    {
        [Theory]
        [InlineData("https://en.wikipedia.org/wiki/Mahatma_Gandhi", "Data Fetched Successfully")]
        [InlineData("https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios", "Data Fetched Successfully")]
        [InlineData("https://en.wikipedia.org/wiki/afrwerw", "Page Not Found!!!")]
        [InlineData("Super Man", "Invalid URL : It should contain the base address")]
        [InlineData("https://awe//ewf//Man", "Invalid URL : It should contain the base address")]
        [InlineData("https://www.skcet.ac.in/", "Data Fetched Successfully")]
        [InlineData("https://www.google.com", "Data Fetched Successfully")]
        public async Task InputURLs_GetFromWeb_ContainsTheData(string url, string expectedOutput)
        {
            ///Arrange
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            await GetFromServer.GetFromWeb(url);
            string result = stringWriter.ToString().Trim();

            //Assert
            Assert.Contains(expectedOutput, result);
        }

        [Theory]
        [InlineData("https://awe//ewf//Man", false)]
        [InlineData("rwerwerwerwerwerwre", false)]
        [InlineData("https://www.google.com", true)]
        [InlineData("https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios", true)]
        [InlineData("https://learn.microsoft.com/en-us/dotnet/csharp/fsfsdf?aewqwAEQ", true)]
        public void InputURLS_ValidateURL_ReturnsBool(string inputurl, bool exceptedResult)
        {
            //Arrange
            bool result;

            //Act
            result = GetFromServer.ValidateURL(inputurl);

            //Assert
            Assert.Equal(exceptedResult, result);
        }
    }
}