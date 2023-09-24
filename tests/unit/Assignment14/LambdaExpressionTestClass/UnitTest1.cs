namespace LambdaExpression.Tests
{
    using LambdaExpression;
    public class ProgramTests
    {
        [Fact]
        public void FilterList_FiltersEvenNumbers()
        {
            // Arrange
            List<int> numberList = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> expectedFilteredNumbers = new List<int> { 2, 4, 6 };

            // Act
            var filteredList = Program.FilterList(numberList);

            // Assert
            Assert.Equal(expectedFilteredNumbers, filteredList);
        }

        [Fact]
        public void SelectList_SquaresAllNumbers()
        {
            // Arrange
            List<int> numberList = new List<int> { 1, 2, 3, 4 };
            List<double> expectedSquaredNumbers = new List<double> { 1.0, 4.0, 9.0, 16.0 };

            // Act
            var squaredList = Program.SelectList(numberList);

            // Assert
            Assert.Equal(expectedSquaredNumbers, squaredList);
        }

        [Fact]
        public void AddNumberToList_PopulatesListWithValidInput()
        {
            // Arrange
            List<int> numberList = new List<int>();
            string input = "1\n2\n3\n";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            // Act
            bool terminateProgram = Program.AddNumberToList(numberList, 3);

            // Assert
            Assert.False(terminateProgram);
            Assert.Equal(new List<int> { 1, 2, 3 }, numberList);
        }

        [Fact]
        public void AddNumberToList_IgnoresInvalidInput()
        {
            // Arrange
            List<int> numberList = new List<int>();
            string input = "a\n1\nb\n2\nc\n3\n";
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            // Act
            bool terminateProgram = Program.AddNumberToList(numberList, 3);

            // Assert
            Assert.False(terminateProgram);
            Assert.Equal(new List<int> { 1, 2, 3 }, numberList);
        }
    }
}
