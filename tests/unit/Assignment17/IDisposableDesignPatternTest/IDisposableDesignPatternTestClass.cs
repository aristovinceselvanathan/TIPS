namespace IDisposableDesignPatternTest
{
    using global::IDisposableDesignPattern;
    public class IDisposableDesignPatternTestClass
    {
        private static string _testFilePath = "hello.txt";
        private ManagedResources _managedResources = new ManagedResources();

        [Fact]
        public void WriteToTheFile_ShouldWriteToFile()
        {
            // Arrange
            string testData = "Hello World!!";
            using (UnmanagedResources _unmanagedResources = new UnmanagedResources("bye.txt"))
            { 
                // Act
                _unmanagedResources.WriteToTheFile(testData);
            }

                // Assert
                string fileContent = File.ReadAllText("bye.txt");
                Assert.Contains(testData, fileContent);
        }

        [Fact]
        public void CloseTheFile_ShouldCloseTheFile()
        {
            UnmanagedResources _unmanagedResources;
            //Arrange
            using (_unmanagedResources = new UnmanagedResources(_testFilePath))
            {
                string data = "GoodBye";

                //Act
                _unmanagedResources.WriteToTheFile(data);
            }

            //Assert
            Assert.Null(_unmanagedResources.Writer);
        }
        [Fact]
        public void DisposeTheFile_ShouldThrowException()
        {
            //Arrange
            string text = "Hello";
            using (UnmanagedResources _unmanagedResources = new UnmanagedResources(_testFilePath))
            {

                //Act
                _unmanagedResources.WriteToTheFile(text);
                _unmanagedResources.Dispose();

                //Assert
                Assert.Throws<ObjectDisposedException>(() => _unmanagedResources.WriteToTheFile("Hello"));
            }
        }

        [Fact]
        public void AddElement_ShouldContainElements()
        {
            //Arrange
            string data = "Hello, How are you?";

            //Act
            _managedResources.AddData(data);

            //Asser
            Assert.Contains(data, _managedResources.DataList);

        }

        [Fact]
        public void ClearTheList_ShouldClearTheList()
        {
            //Arrange
            string data = "Aeroplane";

            //Act
            _managedResources.AddData(data);
            _managedResources.ClearData();

            //Assert
            Assert.Empty(_managedResources.DataList);
        }
    }
}