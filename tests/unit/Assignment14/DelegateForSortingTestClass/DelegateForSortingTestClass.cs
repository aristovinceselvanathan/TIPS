namespace Task5.Tests
{
    using System.Collections.Generic;
    using DelegatesForSorting;
    public class ProgramTests
    {
        [Fact]
        public void SortByName_IsSortedByProductsName_ReturnsSortedListOfProducts()
        {
            // Arrange
            var productsList = new List<Product>
            {
                new Product { Name = "Apple", Category = "Fruits", Price = 2.99M },
                new Product { Name = "Banana", Category = "Fruits", Price = 1.49M },
                new Product { Name = "Carrot", Category = "Vegetables", Price = 0.99M },
            };
            string expectedOutput1 = "Apple";
            string expectedOutput2 = "Banana";
            string expectedOutput3 = "Carrot";

            // Act
            productsList.Sort(Program.SortByName);

            // Assert
            Assert.Equal(expectedOutput1, productsList[0].Name);
            Assert.Equal(expectedOutput2, productsList[1].Name);
            Assert.Equal(expectedOutput3, productsList[2].Name);
        }

        [Fact]
        public void SortByCategory_IsSortedByProductsCategory_ReturnsSortedListOfProducts()
        {
            // Arrange
            var productsList = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 999.99M },
                new Product { Name = "T-shirt", Category = "Fashion", Price = 19.99M },
                new Product { Name = "Chair", Category = "Furniture", Price = 49.99M },
            };
            string expectedOutput1 = "Laptop";
            string expectedOutput2 = "T-shirt";
            string expectedOutput3 = "Chair";
            // Act
            productsList.Sort(Program.SortByCategory);

            // Assert
            Assert.Equal(expectedOutput1, productsList[0].Name);
            Assert.Equal(expectedOutput2, productsList[1].Name);
            Assert.Equal(expectedOutput3, productsList[2].Name);
        }

        [Fact]
        public void SortByPrice_IsSortedProductsByPrice_ReturnsSortedListOfProducts()
        {
            // Arrange
            var productsList = new List<Product>
            {
                new Product { Name = "Book", Category = "Books", Price = 15.99M },
                new Product { Name = "Headphones", Category = "Electronics", Price = 49.99M },
                new Product { Name = "Bike", Category = "Sports", Price = 299.99M },
            };
            string expectedOutput1 = "Book";
            string expectedOutput2 = "Headphones";
            string expectedOutput3 = "Bike";
            // Act
            productsList.Sort(Program.SortByPrice);

            // Assert
            Assert.Equal(expectedOutput1, productsList[0].Name);
            Assert.Equal(expectedOutput2, productsList[1].Name);
            Assert.Equal(expectedOutput3, productsList[2].Name);
        }
        [Fact]
        public void SortByName_IsSortedProductsByName_ReturnsSortedListOfProducts()
        {
            // Arrange
            var productsList = new List<Product>
            {
                new Product { Name = "Banana", Category = "Fruits", Price = 1.49M },
                new Product { Name = "Apple", Category = "Fruits", Price = 2.99M },
                new Product { Name = "Carrot", Category = "Vegetables", Price = 0.99M },
            };
            string expectedOutput1 = "Apple";
            string expectedOutput2 = "Banana";
            string expectedOutput3 = "Carrot";
            // Act
            productsList.Sort(Program.SortByName);

            // Assert
            Assert.Equal(expectedOutput1, productsList[0].Name);
            Assert.Equal(expectedOutput2, productsList[1].Name);
            Assert.Equal(expectedOutput3, productsList[2].Name);
        }

        [Fact]
        public void SortByName_IsSortedProductsByNameWithMixedCase_ReturnsSortedListOfProducts()
        {
            // Arrange
            var productsList = new List<Product>
            {
                new Product { Name = "apple", Category = "Fruits", Price = 1.49M },
                new Product { Name = "Banana", Category = "Fruits", Price = 2.99M },
                new Product { Name = "Carrot", Category = "Vegetables", Price = 0.99M },
            };
            string expectedOutput1 = "apple";
            string expectedOutput2 = "Banana";
            string expectedOutput3 = "Carrot";
            // Act
            productsList.Sort(Program.SortByName);

            // Assert
            Assert.Equal(expectedOutput1, productsList[0].Name);
            Assert.Equal(expectedOutput2, productsList[1].Name);
            Assert.Equal(expectedOutput3, productsList[2].Name);
        }
    }
}
