namespace AnonymousMethod.Tests
{
    using AnonymousMethods;
    using Xunit.Abstractions;

    public class ProgramTests
    {

        [Theory]
        [InlineData(new int[] { 5, 4, 1, 3, 2 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 0, 10, 7, 8, 9 }, new int[] { 0, 7, 8, 9, 10 })]
        [InlineData(new int[] { 98, -1, 0, 2, 14 }, new int[] { -1, 0, 2, 14, 98 })]
        [InlineData(new int[] { -0, 1, -2, -2, -1 }, new int[] { -2, -2, -1, 0, 1 })]
        [InlineData(new int[] { -0, +1, -1}, new int[] {-1, 0, 1})]
        public void SortByUsingDelegate_IsNegativeAndPositiveNumbers_ReturnsSortedArray(int[] unsortedArray, int[] expectedSortedArray)
        {
            // Arrange
            AnonymousMethod anonymousMethod = new AnonymousMethod();

            // Act
            anonymousMethod.SortByUsingDelegate(unsortedArray);

            // Assert
            Assert.Equal(expectedSortedArray, unsortedArray);
        }

        [Theory]
        [InlineData("1\n2\n3\n", 3, new int[] {1,2,3})]
        [InlineData("1\n2\n3\n4\n", 3, new int[] {1,2,3})]
        [InlineData("1\n2\n3\n4\n", 4, new int[] {1,2,3,4})]
        [InlineData("0\n1\n2\n", 3, new int[] {0,1,2})]
        [InlineData("a\n1\nb\n2\nc\n3\n", 3, new int[] {1,2,3})]
        [InlineData("-1\n-2\n-3\n", 3, new int[] {-1,-2,-3})]
        [InlineData("1\n2\n3\n", 0, new int[] { })]
        public void AddElementToArray_IsValidInput_ReturnsDictionaryOfAddedElement(string inputData, int size, int[] expectedOutput)
        {
            // Arrange
            int[] arrayOfNumber = new int[size];
            string input = inputData;
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);
            AnonymousMethod anonymousMethod = new AnonymousMethod();

            // Act
            anonymousMethod.AddElementToArray(arrayOfNumber);

            // Assert
            Assert.Equal(expectedOutput, arrayOfNumber);
        }

        [Theory]
        [InlineData(new int[] {1,2,3}, "1, 2, 3,")]
        [InlineData(new int[] {-1,-2,-3}, "-1, -2, -3,")]
        [InlineData(new int[] {0,-2, 3}, "0, -2, 3,")]
        [InlineData(new int[] {-123,-221,-3213}, "-123, -221, -3213,")]
        [InlineData(new int[] {-1,0,1}, "-1, 0, 1,")]
        public void DisplayTheArray_Display_DisplaysArrayElements(int[] arrayOfNumber, string expectedOutput)
        {
            // Arrange
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);
            AnonymousMethod anonymousMethod = new AnonymousMethod();

            // Act
            anonymousMethod.PrintTheArrayInConsole(arrayOfNumber);
            var output = outputWriter.ToString().Trim();

            // Assert
            Assert.Equal(expectedOutput, output);
        }
        [Fact]
        public void EmptyArray_SortByUsingDelegate_ReturnsEmptyArray()
        {
            // Arrange
            int[] emptyArray = new int[0];
            AnonymousMethod anonymousMethod = new AnonymousMethod();

            // Act
            anonymousMethod.SortByUsingDelegate(emptyArray);

            // Assert
            Assert.Empty(emptyArray);
        }
    }
}