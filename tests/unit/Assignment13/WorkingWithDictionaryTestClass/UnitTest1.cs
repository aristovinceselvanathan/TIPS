namespace WorkingWithDictionaries.Tests
{
    using System.Collections.Generic;
    using WorkingWithDictionaries;
    public class StudentDictionaryTests
    {
        [Fact]
        public void Add_ValidStudent_AddsToDirectory()
        {
            // Arrange
            var studentDirectory = new Dictionary<string, int>();
            var studentName = "Alice";
            var gradeOfStudent = 90;

            // Act
            bool result = StudentDictionary<string, int>.Add(studentDirectory, studentName, gradeOfStudent);

            // Assert
            Assert.True(result); // Check that the student is added to the directory
            Assert.Single(studentDirectory); // Check that there is only one student in the directory
            Assert.Equal(gradeOfStudent, studentDirectory[studentName]); // Check that the grade is correct
        }

        [Fact]
        public void Add_DirectoryFull_DoesNotAddStudent()
        {
            // Arrange
            var studentDirectory = new Dictionary<string, int>();
            for (int i = 0; i < 5; i++)
            {
                studentDirectory.Add($"Student{i}", 80 + i);
            }
            var studentName = "NewStudent";
            var gradeOfStudent = 95;

            // Act
            bool result = StudentDictionary<string, int>.Add(studentDirectory, studentName, gradeOfStudent);

            // Assert
            Assert.False(result); // Check that student is not added when the directory is full
            Assert.Equal(5, studentDirectory.Count); // Check that the directory size remains the same
        }

        [Fact]
        public void Remove_StudentExists_RemovesFromDirectory()
        {
            // Arrange
            var studentDirectory = new Dictionary<string, int>();
            var studentName = "Alice";
            var gradeOfStudent = 90;
            studentDirectory.Add(studentName, gradeOfStudent);

            // Act
            bool result = StudentDictionary<string, int>.Remove(studentDirectory, studentName);

            // Assert
            Assert.True(result); // Check that the student is removed from the directory
            Assert.Empty(studentDirectory); // Check that the directory is empty after removal
        }

        [Fact]
        public void Remove_StudentNotExists_ReturnsFalse()
        {
            // Arrange
            var studentDirectory = new Dictionary<string, int>();
            var studentName = "Alice";

            // Act
            bool result = StudentDictionary<string, int>.Remove(studentDirectory, studentName);

            // Assert
            Assert.False(result); // Check that removal returns false when student does not exist
        }

        [Fact]
        public void Remove_StudentExists_RemoveOnlyTargetedStudent()
        {
            // Arrange
            var studentDirectory = new Dictionary<string, int>
            {
                { "Alice", 90 },
                { "Bob", 85 },
                { "Charlie", 88 }
            };
            var studentToRemove = "Bob"; // Student to be removed

            // Act
            bool result = StudentDictionary<string, int>.Remove(studentDirectory, studentToRemove);

            // Assert
            Assert.True(result); // Check that the student is removed
            Assert.Equal(2, studentDirectory.Count); // Check that the directory size is reduced
            Assert.DoesNotContain(studentToRemove, studentDirectory.Keys); // Check that the removed student is not present in the directory
        }

        [Fact]
        public void Remove_StudentNotExistsDictionary_ReturnsFalse()
        {
            // Arrange
            var studentDirectory = new Dictionary<string, int>
            {
                { "Alice", 90 },
                { "Charlie", 88 }
            };
            var studentToRemove = "Bob"; // Student not in the directory

            // Act
            bool result = StudentDictionary<string, int>.Remove(studentDirectory, studentToRemove);

            // Assert
            Assert.False(result); // Check that removal returns false when student does not exist
            Assert.Equal(2, studentDirectory.Count); // Check that the directory size remains the same
        }
    }
}
