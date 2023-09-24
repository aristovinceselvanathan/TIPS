namespace AnonymousMethod.Tests
{
    using AnonymousMethod;
    using Xunit.Abstractions;

    public class ProgramTests
    {

        [Fact]
        public void SortByUsingDelegate_SortsArrayInAscendingOrder()
        {
            // Arrange
            int[] unsortedArray = { 5, 3, 1, 4, 2 };
            int[] expectedSortedArray = { 1, 2, 3, 4, 5 };

            // Act
            Program.SortByUsingDelegate(unsortedArray);

            // Assert
            Assert.Equal(expectedSortedArray, unsortedArray);
        }

        [Fact]
        public void AddElementToArray_PopulatesArrayWithValidInput()
        {
            // Arrange
            int[] arrayOfNumber = new int[3];
            string input = "1\n2\n3\n";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            // Act
            Program.AddElementToArray(arrayOfNumber);

            // Assert
            Assert.Equal(new int[] { 1, 2, 3 }, arrayOfNumber);
        }

        [Fact]
        public void AddElementToArray_IgnoresInvalidInput()
        {
            // Arrange
            int[] arrayOfNumber = new int[3];
            string input = "a\n1\nb\n2\nc\n3\n";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            // Act
            Program.AddElementToArray(arrayOfNumber);

            // Assert
            Assert.Equal(new int[] { 1, 2, 3 }, arrayOfNumber);
        }

        [Fact]
        public void DisplayTheArray_DisplaysArrayElements()
        {
            // Arrange
            int[] arrayOfNumber = { 1, 2, 3 };
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            // Act
            Program.DisplayTheArray(arrayOfNumber);
            var output = outputWriter.ToString().Trim();

            // Assert
            Assert.Equal("123", output);
        }
        [Fact]
        public void SortByUsingDelegate_SortsEmptyArray()
        {
            // Arrange
            int[] emptyArray = new int[0];

            // Act
            Program.SortByUsingDelegate(emptyArray);

            // Assert
            Assert.Empty(emptyArray);
        }

        [Fact]
        public void AddElementToArray_PopulatesArrayWithZeroElements()
        {
            // Arrange
            int[] arrayOfNumber = new int[0];
            string input = "1\n2\n3\n";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            // Act
            Program.AddElementToArray(arrayOfNumber);

            // Assert
            Assert.Empty(arrayOfNumber);
        }

        [Fact]
        public void AddElementToArray_PopulatesArrayWithNegativeNumbers()
        {
            // Arrange
            int[] arrayOfNumber = new int[3];
            string input = "-1\n-2\n-3\n";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            // Act
            Program.AddElementToArray(arrayOfNumber);

            // Assert
            Assert.Equal(new int[] { -1, -2, -3 }, arrayOfNumber);
        }
    }
}