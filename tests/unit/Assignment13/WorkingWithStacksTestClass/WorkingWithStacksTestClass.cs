namespace StringReverser.Tests
{
    using System.Collections.Generic;
    using System.Security;
    using StringReverser;
    public class StringReverserStackTests
    {
        [Theory]
        [InlineData("Hello", true)]
        [InlineData("Hello131231!@@", true)]
        [InlineData("Hello%623", false)]
        public void ValidUserInput_ValidInput_ReturnsTrue(string testInput, bool actualOutput)
        {

            // Act
            bool result = StringReverserStack<char>.ValidUserInput(testInput);

            // Assert
            Assert.Equal(actualOutput, result); // Check that the valid input is accepted
        }


        [Theory]
        [InlineData("Hello123!", "!321olleH")]
        [InlineData("", "Invalid Input")]
        [InlineData("A", "A")]
        [InlineData("Johny", "ynhoJ")]
        [InlineData("Hi How", "woH iH")]
        [InlineData("Hello World", "dlroW olleH")]
        public void StringReverser_ValidInput_ReversesString(String testInput, String actualOutput)
        {
            // Arrange
            var stack = new Stack<char>();

            // Act
            var stringReverser = new StringReverserStack<char>();
            string result = stringReverser.StringReverser(stack, testInput);

            // Assert
            Assert.Equal(actualOutput, result); // Check that the string is reversed
        }
    }
}