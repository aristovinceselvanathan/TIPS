namespace WorkingWithListsTestClass
{
    using global::WorkingWithList;
    using System.Collections.Generic;

    public class WorkingWithListsTestClass
    {
        [Fact]
        public void ValidTitle_AddBook_AddsBookToList()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string>();
            string bookName = "Book1";

            // Act
            bool result = BookList<string>.AddBook(directoryOfBooks, bookName);

            // Assert
            Assert.True(result);
            Assert.Single(directoryOfBooks);
            Assert.Contains(bookName, directoryOfBooks);
        }

        [Fact]
        public void DuplicateTitle_AddBook_DoesNotAddBookToList()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string> { "Book1" };
            string bookName = "Book1";

            // Act
            bool result = BookList<string>.AddBook(directoryOfBooks, bookName);

            // Assert
            Assert.False(result); 
            Assert.Single(directoryOfBooks);
        }

        [Fact]
        public void ExistingBook_RemoveBook_RemovesBookFromList()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string> { "Book1", "Book2", "Book3" };
            string bookName = "Book2";

            // Act
            bool result = BookList<string>.RemoveBook(directoryOfBooks, bookName);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(bookName, directoryOfBooks);
        }

        [Fact]
        public void NonExistingBook_RemoveBook_DoesNotRemoveFromList()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string> { "Book1", "Book2", "Book3" };
            string bookName = "Book4";

            // Act
            bool result = BookList<string>.RemoveBook(directoryOfBooks, bookName);

            // Assert
            Assert.False(result);
            Assert.Equal(3, directoryOfBooks.Count);
        }

        [Fact]
        public void ExistingBook_SearchTheDirectory_ReturnsCorrectIndex()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string> { "Book1", "Book2", "Book3" };
            string bookName = "Book2";

            // Act
            int? index = BookList<string>.SearchTheDirectory(directoryOfBooks, bookName);

            // Assert
            Assert.NotNull(index);
            Assert.Equal(1, index);
        }

        [Fact]
        public void NonExistingBook_SearchTheDirectory_ReturnsNull()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string> { "Book1", "Book2", "Book3" };
            string bookName = "Book4";

            // Act
            int? index = BookList<string>.SearchTheDirectory(directoryOfBooks, bookName);

            // Assert
            Assert.Null(index);
        }


        [Fact]
        public void BookDirectory_AddBook__ReturnsFalse()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string> { "Book1", "Book2", "Book3", "Book4", "Book5" };
            string bookName = "Book6"; 

            // Act
            bool result = BookList<string>.AddBook(directoryOfBooks, bookName);

            // Assert
            Assert.False(result);
            Assert.Equal(5, directoryOfBooks.Count);
        }

        [Fact]
        public void BookDirectoryIsEmpty_RemoveBook_ReturnsFalse()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string>();
            string bookName = "Book1";

            // Act
            bool result = BookList<string>.RemoveBook(directoryOfBooks, bookName);

            // Assert
            Assert.False(result); 
            Assert.Empty(directoryOfBooks);
        }

        [Fact]
        public void BookDirectoryIsEmpty_SearchTheDirectory_ReturnsNull()
        {
            // Arrange
            List<string> directoryOfBooks = new List<string>();
            string bookName = "Book1";

            // Act
            int? index = BookList<string>.SearchTheDirectory(directoryOfBooks, bookName);

            // Assert
            Assert.Null(index);
        }

    }
}