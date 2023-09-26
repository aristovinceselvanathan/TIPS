namespace IEnumerable.Tests
{
    using IEnumerable;
    using System.Collections.Generic;
    public class ProgramTests
    {
        [Fact]
        public void SumOfElements_EmptyList_ReturnsZero()
        {
            // Arrange
            var emptyList = new List<int>();

            // Act
            int sum = Program.SumOfElements(emptyList);

            // Assert
            Assert.Equal(0, sum); // Check that the sum is zero for an empty list
        }

        [Fact]
        public void SumOfElements_ValidList_ReturnsSum()
        {
            // Arrange
            var numberList = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            int sum = Program.SumOfElements(numberList);

            // Assert
            Assert.Equal(15, sum); // Check that the sum is calculated correctly
        }

        [Fact]
        public void AddElements_ValidInput_AddsToNumberList()
        {
            // Arrange
            var numberList = new List<int>();
            int sizeOfNumberList = 3;
            int[] inputs = {1, 2, 3 };

            // Act
            bool result1 = Program.AddElements(numberList, inputs[0]);
            bool result2 = Program.AddElements(numberList, inputs[1]);
            bool result3 = Program.AddElements(numberList, inputs[2]);


            // Assert
            Assert.True(result1); // Check that elements are successfully added
            Assert.True(result2); // Check that elements are successfully added
            Assert.True(result3); // Check that elements are successfully added
            Assert.Equal(sizeOfNumberList, numberList.Count); // Check that the list count matches the expected size
            Assert.Equal(1, numberList[0]); // Check the values in the list
            Assert.Equal(2, numberList[1]);
            Assert.Equal(3, numberList[2]);
        }

        // You can add more test cases for various scenarios, including invalid input and user exit.
    }
}
