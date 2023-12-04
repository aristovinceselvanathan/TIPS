namespace LINQTest
{
    using Assignment20;
    public class LINQTestClass
    {
        [Fact]
        public void ProductList_ReturnsSortedProductList()
        {
            //Arrange
            List<Product> products = GenerateData.GenerateProducts();

            //Act
            List<Product> sortedProducts = Program.Sort(products, "ProductName", true);

            //Assert
            Assert.Equal(products.ElementAt(5), sortedProducts.ElementAt(0));
            Assert.Equal(products.ElementAt(3), sortedProducts.ElementAt(1));
            Assert.Equal(products.ElementAt(9), sortedProducts.ElementAt(2));
        }
        [Fact]
        public void ProductList_ReturnsAverage()
        {
            //Arrange
            List<Product> products = GenerateData.GenerateProducts();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            Program.FilteredProducts(products);
            string output = stringWriter.ToString().Trim();
            //Assert
            Assert.Contains("899.99", stringWriter.ToString());
        }

        [Fact]
        public void TestFilteredProducts()
        {
            List<Product> products = GenerateData.GenerateProducts();
            Program.FilteredProducts(products);

            Assert.NotNull(products);
            Assert.True(products.Count > 0);
        }

        [Fact]
        public void TestGroupByCategory()
        {
            List<Product> products = GenerateData.GenerateProducts();
            Program.GroupByCategory(products);

            Assert.NotNull(products);
            Assert.True(products.Count > 0);
        }


        [Fact]
        public void TestOrdersBefore30Days()
        {
            List<Order> orders = GenerateData.GenerateOrder();
            Program.OrdersBefore30Days(orders);

            Assert.NotNull(orders);
            Assert.True(orders.Count > 0);
        }

        [Fact]
        public void TestBookCategory()
        {
            List<Product> products = GenerateData.GenerateProducts();
            Program.BookCategory(products);

            Assert.NotNull(products);
            Assert.True(products.Count > 0);
        }
    }
}