namespace WorkingWithListsTestClass
{
    using global::WorkingWithList;
    using System.Collections.Generic;

    namespace WorkingWithList.Tests
    {
        public class BookListTests
        {
            [Fact]
            public void AddBook_ValidTitle_AddsBookToList()
            {
                // Arrange
                var directoryOfBooks = new List<string>();
                string bookName = "Book1";

                // Act
                bool result = BookList<string>.AddBook(directoryOfBooks, bookName);

                // Assert
                Assert.True(result); // Check that a book was added
                Assert.Single(directoryOfBooks); // Check that the count is 1
            }

            [Fact]
            public void AddBook_DuplicateTitle_DoesNotAddBookToList()
            {
                // Arrange
                var directoryOfBooks = new List<string> { "Book1" };
                string bookName = "Book1";

                // Act
                bool result = BookList<string>.AddBook(directoryOfBooks, bookName);

                // Assert
                Assert.False(result); // Check that the book was not added
                Assert.Single(directoryOfBooks); // Check that the count is still 1
            }

            [Fact]
            public void RemoveBook_ExistingBook_RemovesBookFromList()
            {
                // Arrange
                var directoryOfBooks = new List<string> { "Book1", "Book2", "Book3" };
                string bookName = "Book2";

                // Act
                bool result = BookList<string>.RemoveBook(directoryOfBooks, bookName);

                // Assert
                Assert.True(result); // Check that the book was removed
                Assert.DoesNotContain(bookName, directoryOfBooks); // Check that Book2 is not in the list
            }

            [Fact]
            public void RemoveBook_NonExistingBook_DoesNotRemoveFromList()
            {
                // Arrange
                var directoryOfBooks = new List<string> { "Book1", "Book2", "Book3" };
                string bookName = "Book4";

                // Act
                bool result = BookList<string>.RemoveBook(directoryOfBooks, bookName);

                // Assert
                Assert.False(result); // Check that the book was not removed
                Assert.Equal(3, directoryOfBooks.Count); // Check that the count is still 3
            }

            [Fact]
            public void SearchTheDirectory_ExistingBook_ReturnsCorrectIndex()
            {
                // Arrange
                var directoryOfBooks = new List<string> { "Book1", "Book2", "Book3" };
                string bookName = "Book2";

                // Act
                int? index = BookList<string>.SearchTheDirectory(directoryOfBooks, bookName);

                // Assert
                Assert.NotNull(index); // Check that an index is returned
                Assert.Equal(1, index); // Check that the index of Book2 is 1
            }

            [Fact]
            public void SearchTheDirectory_NonExistingBook_ReturnsNull()
            {
                // Arrange
                var directoryOfBooks = new List<string> { "Book1", "Book2", "Book3" };
                string bookName = "Book4";

                // Act
                int? index = BookList<string>.SearchTheDirectory(directoryOfBooks, bookName);

                // Assert
                Assert.Null(index); // Check that null is returned for a non-existing book
            }


            [Fact]
            public void AddBook_DirectoryIsFull_ReturnsFalse()
            {
                // Arrange
                var directoryOfBooks = new List<string> { "Book1", "Book2", "Book3", "Book4", "Book5" };
                string bookName = "Book6"; // Adding a book when the directory is already full

                // Act
                bool result = BookList<string>.AddBook(directoryOfBooks, bookName);

                // Assert
                Assert.False(result); // Check that the book was not added
                Assert.Equal(5, directoryOfBooks.Count); // Check that the count is still 5
            }

            [Fact]
            public void RemoveBook_DirectoryIsEmpty_ReturnsFalse()
            {
                // Arrange
                var directoryOfBooks = new List<string>();
                string bookName = "Book1"; // Trying to remove a book from an empty directory

                // Act
                bool result = BookList<string>.RemoveBook(directoryOfBooks, bookName);

                // Assert
                Assert.False(result); // Check that the book was not removed
                Assert.Empty(directoryOfBooks); // Check that the directory is still empty
            }

            [Fact]
            public void SearchTheDirectory_DirectoryIsEmpty_ReturnsNull()
            {
                // Arrange
                var directoryOfBooks = new List<string>();
                string bookName = "Book1"; // Searching for a book in an empty directory

                // Act
                int? index = BookList<string>.SearchTheDirectory(directoryOfBooks, bookName);

                // Assert
                Assert.Null(index); // Check that null is returned for an empty directory
            }

            [Fact]
            public void DisplayAll_DirectoryIsEmpty_ReturnsEmptyList()
            {
                // Arrange
                var directoryOfBooks = new List<string>(); // An empty directory

                // Act (No need to assert, just checking for exceptions)
                BookList<string>.DisplayAll(directoryOfBooks); // Should not throw an exception
            }
        }

    }
}