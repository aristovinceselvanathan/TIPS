namespace IEnumerable.Tests
{
    using IEnumerable;
    using System.Collections.Generic;

    public class WorkingWithIEnumerableTestClass
    {
        [Fact]
        public void EmptyList_SumOfElements_ReturnsZero()
        {
            // Arrange
            List<int> emptyList = new List<int>();
            int sumActual = 0;

            // Act
            int sum = Program.SumOfElements(emptyList);

            // Assert
            Assert.Equal(sumActual, sum);
        }

        [Fact]
        public void ValidList_SumOfElements_ReturnsSum()
        {
            // Arrange
            List<int> numberList = new List<int> { 1, 2, 3, 4, 5 };
            int sumActual = 15;

            // Act
            int sum = Program.SumOfElements(numberList);

            // Assert
            Assert.Equal(sumActual, sum); 
        }

        [Fact]
        public void ValidInput_AddElements_AddsToNumberList()
        {
            // Arrange
            List<int> numberList = new List<int>();
            int sizeOfNumberList = 3;
            int[] inputs = {1, 2, 3 };

            // Act
            bool result1 = Program.AddElements(numberList, inputs[0]);
            bool result2 = Program.AddElements(numberList, inputs[1]);
            bool result3 = Program.AddElements(numberList, inputs[2]);


            // Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3); 
            Assert.Equal(sizeOfNumberList, numberList.Count);
            Assert.Equal(1, numberList[0]);
            Assert.Equal(2, numberList[1]);
            Assert.Equal(3, numberList[2]);
        }
    }
}
