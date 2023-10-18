namespace WorkingWithQueue.Tests
{
    using System.Collections.Generic;
    using WorkingWithQueue;

    public class WorkingWithQueueTestClass
    {
        [Fact]
        public void ValidName_Enqueue_AddsToQueue()
        {
            // Arrange
            Queue<string> ticketQueueLine = new Queue<string>();
            string inputName = "John";

            // Act
            TicketQueue<String>.Enqueue(ticketQueueLine, inputName);

            // Assert
            Assert.Single(ticketQueueLine);
            Assert.Equal(inputName, ticketQueueLine.Dequeue()); 
        }

        [Fact]
        public void EmptyName_Enqueue_DoesNotAddToQueue()
        {
            // Arrange
            Queue<string> ticketQueueLine = new Queue<string>();
            string inputName = string.Empty;

            // Act
            TicketQueue<String>.Enqueue(ticketQueueLine, inputName);

            // Assert
            Assert.Empty(ticketQueueLine); 
        }
        
        [Fact]
        public void DuplicateName_Enqueue_DoesNotAddToQueue()
        {
            // Arrange
            Queue<string> ticketQueueLine = new Queue<string>();

            // Act
            TicketQueue<String>.Enqueue(ticketQueueLine, "John");
            TicketQueue<String>.Enqueue(ticketQueueLine, "John");

            // Assert
            Assert.Single(ticketQueueLine); 
        }

        [Fact]
        public void InvalidName_Enqueue_DoesNotAddToQueue()
        {
            // Arrange
            Queue<string> ticketQueueLine = new Queue<string>();
            string inputName = "123"; 

            // Act
            TicketQueue<String>.Enqueue(ticketQueueLine, inputName);

            // Assert
            Assert.Empty(ticketQueueLine); 
        }

        [Fact]
        public void EmptyQueue_Dequeue_ReturnsNull()
        {
            // Arrange
            Queue<string> ticketQueueLine = new Queue<string>();

            // Act
            string result = TicketQueue<string>.Dequeue(ticketQueueLine);

            // Assert
            Assert.Null(result); 
        }

        [Fact]
        public void ValidQueue_Dequeue_ReturnsName()
        {
            // Arrange
            Queue<string> ticketQueueLine = new Queue<string>();
            ticketQueueLine.Enqueue("Alice");
            ticketQueueLine.Enqueue("Bob");

            // Act
            string result = TicketQueue<string>.Dequeue(ticketQueueLine);

            // Assert
            Assert.Equal("Alice", result); 
        }

    }
}