namespace PatternMatching.Tests
{
    using PatternMatching;
    public class CircleTests
    {
        [Theory]
        [InlineData(12, 452.39)]
        [InlineData(11, 380.13)]
        [InlineData(67, 14102.61)]
        [InlineData(4, 50.27)]
        [InlineData(0, 0)]
        [InlineData(1, 3.14)]
        public void CalculateAreaOfCircle_IsValidInput_ShouldReturnCorrectArea(double input1, double expectedValue)
        {
            // Arrange
            Circle circle = new Circle { Input1 = input1 };

            // Act
            double area = circle.CalculateArea();

            // Assert
            Assert.Equal(expectedValue, area);
        }
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(2.5, 6.7, 16.75)]
        [InlineData(0, 0, 0)]
        [InlineData(34, 23, 782)]
        [InlineData(56, 65, 3640)]
        public void CalculateAreaOfRectangle_ShouldReturnCorrectArea(double input1, double input2, double expectedValue)
        {
            // Arrange
            Rectangle rectangle = new Rectangle { Input1 = input1, Input2 = input2 };

            // Act
            double area = rectangle.CalculateArea();

            // Assert
            Assert.Equal(expectedValue, area);
        }

        [Theory]
        [InlineData(3, 4, 6)]
        [InlineData(0, 0, 0)]
        [InlineData(45, 54, 1215)]
        [InlineData(90, 90, 4050)]
        [InlineData(34, 43, 731)]
        [InlineData(5.6, 6.7, 18.76)]
        public void CalculateAreaOfTriangle_ShouldReturnCorrectArea(double input1, double input2, double expectedValue)
        {
            // Arrange
            Triangle triangle = new Triangle { Input1 = input1, Input2 = input2 };

            // Act
            double area = triangle.CalculateArea();

            // Assert
            Assert.Equal(expectedValue, area);
        }
        [Fact]
        public void DetectShape_IsValidShapeDetails_ReturnsShapeName()
        { 
            //Arrange
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            Triangle triangle = new Triangle();
            Shape shape = new Shape();

            //Act
            string testShape1 = Program.DisplayShapeDetails(circle);
            string testShape2 = Program.DisplayShapeDetails(rectangle);
            string testShape3 = Program.DisplayShapeDetails(triangle);
            string testShape4 = Program.DisplayShapeDetails(shape);

            //Assert
            Assert.Equal("circle", testShape1);
            Assert.Equal("rectangle", testShape2);
            Assert.Equal("triangle", testShape3);
            Assert.Equal("invalid shape", testShape4);
        }

        [Fact]
        public void InputRectangle_DetailsOfRectangle_DetectTheRectangle()
        {
            // Arrange
            Rectangle rectangle = new Rectangle();
            StringReader input = new StringReader("Red\n5\n10\n");

            // Act
            Console.SetIn(input);
            Program.GetDetailsOfShape(rectangle);

            // Assert
            Assert.Equal("Red", rectangle.Color);
            Assert.Equal(5, rectangle.Input1);
            Assert.Equal(10, rectangle.Input2);
        }

        [Fact]
        public void InputCircle_DetailsOfCircle_DetectTheCircle()
        {
            // Arrange
            Circle circle = new Circle();
            StringReader input = new StringReader("Blue\n3\n");

            // Act
            Console.SetIn(input);
            Program.GetDetailsOfShape(circle);

            // Assert
            Assert.Equal("Blue", circle.Color);
            Assert.Equal(3, circle.Input1);
        }

        [Fact]
        public void InputTriangle_DetailsOfTriangle_DetectTheTriangle()
        {
            // Arrange
            Triangle triangle = new Triangle();
            StringReader input = new StringReader("Green\n4\n6\n");

            // Act
            Console.SetIn(input);
            Program.GetDetailsOfShape(triangle);

            // Assert
            Assert.Equal("Green", triangle.Color);
            Assert.Equal(4, triangle.Input1);
            Assert.Equal(6, triangle.Input2);
        }

        [Fact]
        public void InputShape_DetailsOfShape_DetectTheShape()
        {
            // Arrange
            Shape shape = new Shape();
            StringReader input = new StringReader("Green\n4\n6\n");

            // Act
            Console.SetIn(input);
            Program.GetDetailsOfShape(shape);

            // Assert
            Assert.Equal("", shape.Color);
        }
    }
}
