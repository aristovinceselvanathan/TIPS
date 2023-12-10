namespace StringReverser.Tests
{
    using System.Collections.Generic;
    using StringReverser;
    public class WorkingWithStacksTestClass
    {
        [Theory]
        [InlineData("Hello", true)]
        [InlineData("Hello131231!@@", true)]
        [InlineData("Hello%623", false)]
        public void ValidInput_ValidUserInput_ReturnsTrue(string testInput, bool actualOutput)
        {
            // Act
            bool result = StringReverserStack<char>.ValidUserInput(testInput);

            // Assert
            Assert.Equal(actualOutput, result); 
        }


        [Theory]
        [InlineData("Hello123!", "!321olleH")]
        [InlineData("", "Invalid Input")]
        [InlineData("A", "A")]
        [InlineData("Johny", "ynhoJ")]
        [InlineData("Hi How", "woH iH")]
        [InlineData("Hello World", "dlroW olleH")]
        public void ValidInput_StringReverser_ReversesString(string testInput, string actualOutput)
        {
            // Arrange
            Stack<char> stack = new Stack<char>();

            // Act
            var stringReverser = new StringReverserStack<char>();
            string result = stringReverser.StringReverser(stack, testInput);

            // Assert
            Assert.Equal(actualOutput, result); 
        }
    }
}