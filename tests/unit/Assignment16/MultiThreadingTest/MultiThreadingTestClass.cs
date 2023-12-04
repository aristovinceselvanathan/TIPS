using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text.RegularExpressions;

namespace MultiThreadingTest
{
    using MultiThreading;
    public class MultiThreadingTestClass
    {
        [Theory]
        [InlineData("1\n2\n3\n", 3, new int[] { 1, 2, 3 })]
        [InlineData("-1\n-2\n3\n", 3, new int[] { -1, -2, 3 })]
        [InlineData("1\n2\n3\n", 2, new int[] { 1, 2 })]
        public void IntegerArray_AddMethod_ReturnsArray(string input, int size, int[] expectedArr)
        {
            //Arrange
            int[] arr = new int[size];
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);
            Regex pattern = new Regex("\\d");

            //Act
            Program.AddTheElementToTheArray(arr, size, pattern);

            //Assert
            Assert.Equal(arr, expectedArr);
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 6)]
        [InlineData(new int[] { -1, -2, 3 }, 0)]
        [InlineData(new int[] { 1, 2 }, 3)]
        [InlineData(new int[] { 9, 8, 8, 7 }, 32)]
        public void IntegerArray_SumArray_ReturnsSum(int[] numberArray, int expectedSum)
        {
            //Arrange
            int result;

            //Act
            result = Program.SumOfTheArray(numberArray, numberArray.Length);

            //Assert
            Assert.Equal(expectedSum, result);
        }
        [Theory]
        [InlineData(new int[] { 3, 2, 1 }, new int[]{1, 2, 3})]
        [InlineData(new int[] { -1, 3, -2 }, new int[] {-2, -1, 3 })]
        [InlineData(new int[] { 1, 2 }, new int[] {1, 2})]
        [InlineData(new int[] { 9, 8, 8, 7 }, new int[] { 7, 8, 8, 9})]
        [InlineData(new int[] { 0, -9, 9, -8, 8 }, new int[] { -9, -8, 0, 8, 9})]
        public void IntegerArray_SortArray_ReturnsSortedArray(int[] numberArray, int[] expectedArray)
        {
            //Act
            Program.SortingTheArray(numberArray, numberArray.Length);

            //Assert
            Assert.Equal(numberArray, expectedArray);
        }
    }
}