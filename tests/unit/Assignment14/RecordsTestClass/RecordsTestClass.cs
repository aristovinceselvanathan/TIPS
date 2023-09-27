namespace Records.Tests
{
    using Records;
    public class ProgramTests
    {
        [Fact]
        public void AddBook_ValidInput_ShouldAddBook()
        {
            // Arrange
            var directoryOfBooks = new List<Program.book>();
            string userInputName = "Book Title";
            string userInputAuthor = "Author Name";
            string userInputISBN = "1234567890";

            // Act
            bool result = Program.AddBook(directoryOfBooks, userInputName, userInputAuthor, userInputISBN);

            // Assert
            Assert.True(result); // Check if the method returns true (book added successfully)
            Assert.Single(directoryOfBooks); // Check if the book list has one item
            // You can further assert the properties of the added book if needed.
            Assert.Equal(userInputName, directoryOfBooks[0].name);
            Assert.Equal(userInputAuthor, directoryOfBooks[0].author);
            Assert.Equal(userInputISBN, directoryOfBooks[0].isbn);
        }
        [Fact]
        public void AddBook_InValidISBN_ShouldNotAddBook()
        {
            // Arrange
            var directoryOfBooks = new List<Program.book>();
            string userInputName = "Book Title";
            string userInputAuthor = "Author Name";
            string userInputISBN = "123456";

            // Act
            bool result = Program.AddBook(directoryOfBooks, userInputName, userInputAuthor, userInputISBN);

            // Assert
            Assert.False(result); // Check if the method returns false (book added successfully)
            Assert.Empty(directoryOfBooks); // Check if the book list 
        }
        [Fact]
        public void AddBook_InValidAuthor_ShouldNotAddBook()
        {
            // Arrange
            var directoryOfBooks = new List<Program.book>();
            string userInputName = "Book Title";
            string userInputAuthor = "4234443";
            string userInputISBN = "1234567890";

            // Act
            bool result = Program.AddBook(directoryOfBooks, userInputName, userInputAuthor, userInputISBN);

            // Assert
            Assert.False(result); // Check if the method returns false (book added successfully)
            Assert.Empty(directoryOfBooks); // Check if the book list 
        }

        [Fact]
        public void AddBook_InvalidName_ShouldNotAddBook()
        {
            // Arrange
            var directoryOfBooks = new List<Program.book>();
            string invalidUserInput = "Invalid#Name"; // This input should be rejected

            // Act
            bool result = Program.AddBook(directoryOfBooks, invalidUserInput, "Author", "1234567890");

            // Assert
            Assert.False(result); // Check if the method returns false (book not added)
            Assert.Empty(directoryOfBooks); // Check if the book list is still empty
        }

        [Fact]
        public void EditNameOfProduct_ValidInput_ShouldEditName()
        {
            // Arrange
            var directoryOfBooks = new List<Program.book>
            {
                new Program.book("Book1", "Author1", "1234567890"),
                new Program.book("Book2", "Author2", "0987654321")
            };
            int position = 1; // Edit the first book
            string nameOfBook = "New Book Title";

            // Act
            bool result = Program.EditNameOfProduct(directoryOfBooks, position, nameOfBook);
            
            // Assert
            Assert.False(result); // Check if the method returns true (name edited successfully)
            Assert.NotEqual(nameOfBook, directoryOfBooks[position - 1].name); // Check if the name was updated
        }

        [Fact]
        public void EditNameOfProduct_InvalidPosition_ShouldNotEditName()
        {
            // Arrange
            var directoryOfBooks = new List<Program.book>
            {
                new Program.book("Book1", "Author1", "1234567890"),
                new Program.book("Book2", "Author2", "0987654321")
            };
            int invalidPosition = 0; // Invalid position
            string nameOfBook = "New Book Title";

            // Act
            bool result = Program.EditNameOfProduct(directoryOfBooks, invalidPosition, nameOfBook);

            // Assert
            Assert.False(result); // Check if the method returns false (name not edited)
                                  // Check if the book list remains unchanged
            Assert.Equal("Book1", directoryOfBooks[0].name);
            Assert.Equal("Book2", directoryOfBooks[1].name);
        }

        [Fact]
        public void EditNameOfProduct_InvalidName_ShouldNotEditName()
        {
            // Arrange
            var directoryOfBooks = new List<Program.book>
            {
                new Program.book("Book1", "Author1", "1234567890"),
                new Program.book("Book2", "Author2", "0987654321")
            };
            int position = 1; // Edit the first book
            string invalidName = "Invalid#Name"; // Invalid name

            // Act
            bool result = Program.EditNameOfProduct(directoryOfBooks, position, invalidName);

            // Assert
            Assert.False(result); // Check if the method returns false (name not edited)
                                  // Check if the book list remains unchanged
            Assert.Equal("Book1", directoryOfBooks[0].name);
            Assert.Equal("Book2", directoryOfBooks[1].name);
        }
    }
}