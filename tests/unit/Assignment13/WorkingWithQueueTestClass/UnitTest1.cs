namespace WorkingWithQueue.Tests
{
    using System.Collections.Generic;
    using WorkingWithQueue;
    public class ProgramTests
    {
        [Fact]
        public void Enqueue_ValidName_AddsToQueue()
        {
            // Arrange
            var ticketQueueLine = new Queue<string>();
            var inputName = "John";

            // Act
            TicketQueue<String>.Enqueue(ticketQueueLine, inputName);

            // Assert
            Assert.Single(ticketQueueLine); // Check that the name is added to the queue
            Assert.Equal(inputName, ticketQueueLine.Dequeue()); // Check that the name matches the input
        }

        [Fact]
        public void Enqueue_EmptyName_DoesNotAddToQueue()
        {
            // Arrange
            var ticketQueueLine = new Queue<string>();
            var inputName = "";

            // Act
            TicketQueue<String>.Enqueue(ticketQueueLine, inputName);

            // Assert
            Assert.Empty(ticketQueueLine); // Check that the queue remains empty for an empty name
        }

        [Fact]
        public void Enqueue_InvalidName_DoesNotAddToQueue()
        {
            // Arrange
            var ticketQueueLine = new Queue<string>();
            var inputName = "123"; // Invalid name with numeric characters

            // Act
            TicketQueue<String>.Enqueue(ticketQueueLine, inputName);

            // Assert
            Assert.Empty(ticketQueueLine); // Check that the queue remains empty for an invalid name
        }

        [Fact]
        public void Dequeue_EmptyQueue_ReturnsNull()
        {
            // Arrange
            var ticketQueueLine = new Queue<string>();

            // Act
            string result = TicketQueue<string>.Dequeue(ticketQueueLine);

            // Assert
            Assert.Null(result); // Check that null is returned for an empty queue
        }

        [Fact]
        public void Dequeue_ValidQueue_ReturnsName()
        {
            // Arrange
            var ticketQueueLine = new Queue<string>();
            ticketQueueLine.Enqueue("Alice");
            ticketQueueLine.Enqueue("Bob");

            // Act
            string result = TicketQueue<string>.Dequeue(ticketQueueLine);

            // Assert
            Assert.Equal("Alice", result); // Check that the name is dequeued correctly
        }

    }
}