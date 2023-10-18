namespace WorkingWithDictionaries.Tests
{
    using System.Collections.Generic;
    using WorkingWithDictionaries;

    public class WorkingWithDictionaryTestClass
    {
        [Fact]
        public void ValidStudentData_AddStudent_AddsToDirectory()
        {
            // Arrange
            Dictionary<string, int> studentDirectory = new Dictionary<string, int>();
            string studentName = "Alice";
            int gradeOfStudent = 90;

            // Act
            bool result = StudentDictionary<string, int>.Add(studentDirectory, studentName, gradeOfStudent);

            // Assert
            Assert.True(result);
            Assert.Single(studentDirectory);
            Assert.Equal(gradeOfStudent, studentDirectory[studentName]);
        }

        [Fact]
        public void ValidStudentData_DirectoryFull_DoesNotAddStudent()
        {
            // Arrange
            Dictionary<string, int> studentDirectory = new Dictionary<string, int>();
            for (int i = 0; i < 5; i++)
            {
                studentDirectory.Add($"Student{i}", 80 + i);
            }
            string studentName = "NewStudent";
            int gradeOfStudent = 95;
            int count = 5;

            // Act
            bool result = StudentDictionary<string, int>.Add(studentDirectory, studentName, gradeOfStudent);

            // Assert
            Assert.False(result);
            Assert.Equal(count, studentDirectory.Count);
        }

        [Fact]
        public void ValidStudentData_RemoveStudent_RemovesFromDirectory()
        {
            // Arrange
            Dictionary<string, int> studentDirectory = new Dictionary<string, int>();
            string studentName = "Alice";
            int gradeOfStudent = 90;
            studentDirectory.Add(studentName, gradeOfStudent);

            // Act
            bool result = StudentDictionary<string, int>.Remove(studentDirectory, studentName);

            // Assert
            Assert.True(result);
            Assert.Empty(studentDirectory);
        }

        [Fact]
        public void StudentNotExists_RemoveStudent_ReturnsFalse()
        {
            // Arrange
            Dictionary<string, int> studentDirectory = new Dictionary<string, int>();
            string studentName = "Alice";

            // Act
            bool result = StudentDictionary<string, int>.Remove(studentDirectory, studentName);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void StudentExists_RemoveStudent_RemoveOnlyTargetedStudent()
        {
            // Arrange
            Dictionary<string, int> studentDirectory = new Dictionary<string, int>
            {
                { "Alice", 90 },
                { "Bob", 85 },
                { "Charlie", 88 }
            };
            string studentToRemove = "Bob";
            int count = 2;

            // Act
            bool result = StudentDictionary<string, int>.Remove(studentDirectory, studentToRemove);

            // Assert
            Assert.True(result);
            Assert.Equal(count, studentDirectory.Count);
            Assert.Contains(studentDirectory.ElementAt(0).Key, "Alice");
            Assert.Contains(studentDirectory.ElementAt(1).Key, "Charlie");
            Assert.DoesNotContain(studentToRemove, studentDirectory.Keys);
        }

        [Fact]
        public void StudentNotExistsDictionary_RemoveStudent_ReturnsFalse()
        {
            // Arrange
            Dictionary<string, int> studentDirectory = new Dictionary<string, int>
            {
                { "Alice", 90 },
                { "Charlie", 88 }
            };
            string studentToRemove = "Bob";
            int count = 2;

            // Act
            bool result = StudentDictionary<string, int>.Remove(studentDirectory, studentToRemove);

            // Assert
            Assert.False(result);
            Assert.Equal(count, studentDirectory.Count);
        }
    }
}
