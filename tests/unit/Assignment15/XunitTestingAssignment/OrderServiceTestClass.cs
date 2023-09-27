using CalculationService;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace XunitTestingAssignment
{
    public class OrderServiceTestClass
    {
        [Fact]
        public void Order_ValidInput_AddsToUserOrderList()
        {
            // Arrange
            var orderStockList = new List<Order>();
            var userOrderList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            StringReader Input = new StringReader("1\n2\n");
            Console.SetIn(Input);

            // Act
            bool result = orderService.Order(orderStockList, userOrderList);

            // Assert
            Assert.True(result); // Assuming Order method returns true on success
            Assert.Single(userOrderList);
            Assert.Equal(2, orderStockList.ElementAt(0).GetQuantity());
            // Add more assertions to check the state of userOrderList

        }

        [Fact]
        public void Order_InvalidQuantity_NotAddToUserOrderList()
        {
            // Arrange
            var orderStockList = new List<Order>();
            var userOrderList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            StringReader Input = new StringReader("1\n5\ny\n");
            Console.SetIn(Input);

            // Act
            bool result = orderService.Order(orderStockList, userOrderList);

            // Assert
            Assert.True(result); // Assuming Order method returns true on success
            Assert.Single(userOrderList);
            Assert.Equal(0, orderStockList.ElementAt(0).GetQuantity());
            // Add more assertions to check the state of userOrderList

        }

        [Fact]
        public void Order_InvalidQuantityData_NotAddToUserOrderList()
        {
            // Arrange
            var orderStockList = new List<Order>();
            var userOrderList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            StringReader Input = new StringReader("1\nwer\ny\n");
            Console.SetIn(Input);

            // Act
            bool result = orderService.Order(orderStockList, userOrderList);

            // Assert
            Assert.False(result); // Assuming Order method returns true on success

        }

        [Fact]
        public void Order_InvalidQuantityNoOption_NotAddToUserOrderList()
        {
            // Arrange
            var orderStockList = new List<Order>();
            var userOrderList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            StringReader Input = new StringReader("1\n5\nn\n");
            Console.SetIn(Input);

            // Act
            bool result = orderService.Order(orderStockList, userOrderList);

            // Assert
            Assert.False(result); // Assuming Order method returns false on fail
            Assert.Empty(userOrderList);
            Assert.Equal(4, orderStockList.ElementAt(0).GetQuantity());
            // Add more assertions to check the state of userOrderList

        }

        [Fact]
        public void Cancel_ValidInput_CancelsOrder()
        {
            // Arrange
            var orderStockList = new List<Order>();
            var userOrderList = new List<Order>();
            var orderService = new OrderService();
            orderStockList.Add(new Order("Bread", 4));
            StringReader Input = new StringReader("1\n4\n1\n");
            Console.SetIn(Input);
            orderService.Order(orderStockList, userOrderList);

            // Act
            bool result = orderService.Cancel(userOrderList, orderStockList);

            // Assert
            Assert.True(result); // Assuming Cancel method returns true on success
            Assert.Equal(0, userOrderList.ElementAt(0).GetQuantity());
            // Add more assertions to check the state of orderStockList

        }

        [Fact]
        public void Cancel_InValidInput_NotCancelsOrder()
        {
            // Arrange
            var orderStockList = new List<Order>();
            var userOrderList = new List<Order>();
            var orderService = new OrderService();
            orderStockList.Add(new Order("Bread", 4));
            StringReader Input = new StringReader("2\n");
            Console.SetIn(Input);
            orderService.Order(orderStockList, userOrderList);

            // Act
            bool result = orderService.Cancel(userOrderList, orderStockList);

            // Assert
            Assert.False(result); // Assuming Cancel method returns false on fail
            Assert.Empty(userOrderList);
            // Add more assertions to check the state of orderStockList

        }

        [Fact]
        public void Update_ValidInput_UpdatesOrderDetails()
        {
            // Arrange
            var orderStockList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            StringReader input = new StringReader("1\n1\nBook\n");
            Console.SetIn(input);

            // Act
            bool result = orderService.Update(orderStockList);

            // Assert
            Assert.True(result); // Assuming Update method does not return true
            Assert.Equal("Book", orderStockList.ElementAt(0).GetName());
            // Add more assertions to check if order details were updated correctly

        }

        [Fact]
        public void Update_InValidQuantityData_NotUpdatesOrderDetails()
        {
            // Arrange
            var orderStockList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            StringReader input = new StringReader("1\n2\n\n");
            Console.SetIn(input);

            // Act
            bool result = orderService.Update(orderStockList);

            // Assert
            Assert.True(result); // Assuming Update method does return true to terminate the program
        }

        [Fact]
        public void Update_InValidInput_NotUpdatesOrderDetails()
        {
            // Arrange
            var orderStockList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            StringReader input = new StringReader("5\n");
            Console.SetIn(input);

            // Act
            bool result = orderService.Update(orderStockList);

            // Assert
            Assert.False(result); // Assuming Update method does return false

        }

        [Fact]
        public void Update_ValidQuantity_UpdatesOrderDetails()
        {
            // Arrange
            var orderStockList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            StringReader input = new StringReader("1\n2\n3\n");
            Console.SetIn(input);

            // Act
            bool result = orderService.Update(orderStockList);

            // Assert
            Assert.True(result); // Assuming Update method does not return true
            Assert.Equal(3, orderStockList.ElementAt(0).GetQuantity());
            Assert.Single(orderStockList);
            // Add more assertions to check if order details were updated correctly

        }
        [Fact]
        public void Display_WithOrderList_DisplaysOrders()
        {
            // Arrange
            var orderStockList = new List<Order>();
            orderStockList.Add(new Order("Bread", 4));
            var orderService = new OrderService();
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            // Act
            orderService.Display(orderStockList);
            var output = outputWriter.ToString().Trim();

            // Assert
            Assert.Contains("ID", output);
            Assert.Contains("Order Name", output);
            Assert.Contains("Quantity", output);
            // Add more assertions to check the displayed content
        }
    }
}