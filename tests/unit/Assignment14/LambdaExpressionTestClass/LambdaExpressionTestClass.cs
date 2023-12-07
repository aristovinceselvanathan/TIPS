namespace LambdaExpression.Tests
{
    using LambdaExpression;
    public class ProgramTests
    {
        [Theory]
        [InlineData(new int[] {1,2,3}, new int[] {2})]
        [InlineData(new int[] {-1,-2,-3}, new int[] {-2})]
        [InlineData(new int[] {44,50,56}, new int[] {44,50,56})]
        [InlineData(new int[] {0,0,0}, new int[] {0,0,0})]
        [InlineData(new int[] {6,7,9,0,2}, new int[] {6, 0, 2})]
        public void FilterList_IsFilteredEvenNumbers_ReturnsListOfEvenNumbers(int[] numberListArray, int[] expectedOutput)
        {
            // Arrange
            List<int> numberList = new List<int> (numberListArray);
            List<int> expectedFilteredNumbers = new List<int> (expectedOutput);

            // Act
            var filteredList = Program.FilterList(numberList);

            // Assert
            Assert.Equal(expectedFilteredNumbers, filteredList);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new double[] { 1, 4, 9 })]
        [InlineData(new int[] { -1, -2, -3 }, new double[] {1, 4, 9})]
        [InlineData(new int[] { 44, 50, 56 }, new double[] { 1936, 2500, 3136})]
        [InlineData(new int[] { 0, 0, 0 }, new double[] { 0, 0, 0 })]
        [InlineData(new int[] { -6, -7, 9, 0, 2 }, new double[] { 36, 49, 81, 0, 4})]
        public void SelectList_IsSquaredAllNumbers_ReturnsListOfSquaredNumber(int[] numberListArray, double[] expectedOutput)
        {
            // Arrange
            List<int> numberList = new List<int> (numberListArray);
            List<double> expectedSquaredNumbers = new List<double> (expectedOutput);

            // Act
            var squaredList = Program.SelectList(numberList);

            // Assert
            Assert.Equal(expectedSquaredNumbers, squaredList);
        }

        [Theory]
        [InlineData("1\n2\n3\n", 3, new int[] { 1, 2, 3 })]
        [InlineData("1\n2\n3\n4\n", 3, new int[] {1,2,3})]
        [InlineData("1\n2\n3\n4\n", 4, new int[] {1,2,3,4})]
        [InlineData("0\n1\n2\n", 3, new int[] {0,1,2})]
        [InlineData("a\n1\nb\n2\nc\n3\n", 3, new int[] {1,2,3})]
        [InlineData("-1\n-2\n-3\n", 3, new int[] {-1,-2,-3})]
        [InlineData("1\n2\n3\n", 0, new int[] { })]
        public void AddElementToArray_IsValidInput_ReturnsListOfAddedElement(string inputData, int size, int[] expectedOutput)
        {
            // Arrange
            List<int> numberList = new List<int>();
            string input = inputData;
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            // Act
            bool terminateProgram = Program.AddNumberToList(numberList, size);

            // Assert
            Assert.False(terminateProgram);
            Assert.Equal(new List<int> (expectedOutput), numberList);
        }
    }
}
