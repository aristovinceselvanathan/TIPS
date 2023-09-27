namespace CalculationService.Tests
{
    using CalculationService;
    using Moq;
    public class MathUtilityTests
    {
        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(0, 0, 0)]
        [InlineData(10, -4, 6)]
        [InlineData(-10, -4, -14)]
        [InlineData(-11, -4, -15)]
        public void Add_ShouldReturnCorrectResult(int input1, int input2, int expectedResult)
        {
            // Arrange
            var mathUtility = new MathUtility();

            // Act
            var result = mathUtility.Add(input1, input2);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 4, 6)]
        [InlineData(0, 0, 0)]
        [InlineData(7, -5, 12)]
        [InlineData(-7, -5, -2)]
        [InlineData(7, 8, -1)]
        public void Subtract_ShouldReturnCorrectResult(int input1, int input2, int expectedResult)
        {
            // Arrange
            var mathUtility = new MathUtility();

            // Act
            var result = mathUtility.Subtract(input1, input2);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(7, 5, 35)]
        [InlineData(0, 10, 0)]
        [InlineData(3, -2, -6)]
        [InlineData(-3, -2, 6)]
        [InlineData(7, 8, 56)]
        public void Multiply_ShouldReturnCorrectResult(int input1, int input2, int expectedResult)
        {
            // Arrange
            var mathUtility = new MathUtility();

            // Act
            var result = mathUtility.Multiply(input1, input2);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(15, 3, 5)]
        [InlineData(0, 10, 0)]
        [InlineData(7, 2, 3)]
        [InlineData(10, 0, null)]
        [InlineData(10, 11, 0)]
        public void Divide_ShouldReturnCorrectResult(int input1, int input2, int? expectedResult)
        {
            // Arrange
            var mathUtility = new MathUtility();

            // Act
            var result = mathUtility.Divide(input1, input2);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
