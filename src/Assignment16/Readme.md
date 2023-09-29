# Async/Await, Task Parallel Library, and Multi-Threading in C#

This assignment is designed to provide an in-depth understanding and practical experience of Async/Await, Task Parallel Library (TPL), and Multi-Threading in C#. By the end of this assignment, you will have a profound insight into these concepts and how they can be used to optimize performance in a C# application.

## Task 1: Understanding and Implementing Async/Await 

### Description: 

### Steps: 

Create a new console application in C#.

Implement a method that simulates downloading content from a URL using the HttpClient class. The method should return a string that contains the content.

Use the async keyword to declare the method and the await keyword to wait for the content to download asynchronously.

In your Main method, call the method you implemented and output the content to the console.

### Expected Outcome: 

On running the application, you should see the content from the URL displayed in the console. The application should remain responsive while the content is being downloaded.

## Task 2: Implementing and Understanding Task Parallel Library 

### Description: 

Create a console application that uses the Task Parallel Library (TPL) to perform parallel operations.

### Steps: 

Create a new console application in C#.

Define an array of integers (for example, from 1 to 10000).

Use the Parallel.ForEach method from the TPL to square each number in the array.

Print the results to the console.

### Expected Outcome: 

The application should print the square of each number in the array to the console. The operation should be performed faster than if it were done sequentially.

## Task 3: Advanced Understanding and Usage of Multi-Threading 

### Description: 

Create a console application that demonstrates the use of multiple threads. The application should use threads to perform multiple operations simultaneously and then combine the results.

### Steps: 

Create a new console application in C#.

Define two or more methods that perform some operations. These operations could be mathematical calculations, sorting an array, or any other task.

Use the Thread class to run these operations in separate threads.

Use the Join method to wait for all threads to complete before combining the results and printing them to the console.

### Expected Outcome: 

The application should perform multiple operations simultaneously using threads, combine the results, and print them to the console

## Task 4: Implementing Multi-Layered Async/Await Operations in a Real-World Scenario 

### Description: 

Create a console application that mimics a real-world scenario, demonstrating the use of multi-layered async/await operations with a root-level operation started with Task.Run(). This application should represent a scenario where a long-running CPU-bound operation, such as complex data analysis, triggers a series of async operations, like accessing web services.

### Steps: 

Create a new console application in C#.

Implement MethodA that simulates a CPU-bound operation, such as analyzing a large dataset or performing a complex calculation. This method should be started with Task.Run() and return a result that will drive the subsequent operations (for example, a specific data point or a set of parameters).

Implement MethodB that simulates an async operation, such as making a web service call using the HttpClient class. This method should call MethodA, await its result, and use this result to construct the URL or request body for the web service call. The method should return the response from the web service.

Implement MethodC that also simulates an async operation. This method should call MethodB, await its result, and process this result, parsing a JSON response and extracting the number of key-value pairs in the same.

Use the async keyword to declare MethodB and MethodC, and the await keyword to wait for the operations to complete.

In your Main method, call MethodC and output the final result to the console.

### Expected Outcome: 

On running the application, you should see the final result (the processed response from the web service) displayed in the console. The application should remain responsive while the CPU-bound task and async operations are running.

This task mimics a real-world scenario where a CPU-bound operation, such as analyzing data or performing a calculation, triggers a series of web service calls. The goal here is to understand how to structure such operations using async/await and Task.Run(), and how to handle the dependencies between these operations. Consider what happens if any of the operations fail or take a long time to complete. How does this affect the subsequent operations and the final result?  

## Task 5: Debugging and Fixing Deadlock Conditions 

### Description: 

In this task, you'll be given a piece of code that results in a deadlock. Your task is to understand why the deadlock is occurring and modify the code to prevent it while still ensuring correct and expected execution of the program.

### Given Code: 

```csharp
        public async Task DeadlockMethod()
        {
            // Note: Do not use . Result or .Wait() in production code.
            var result = this.SomeAsyncOperation().Result;
            Console.WriteLine(result);
        }

        /// <summary>
        /// SomeAsyncFunction
        /// </summary>
        /// <returns>Task</returns>
        public async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(3000);
            return "Hello, World! ";
        }
```

### Steps: 

Understand why the given code causes a deadlock. Hint: Consider what happens when you use .Result or .Wait() on a task.

Modify the DeadlockMethod to prevent the deadlock.

Ensure that the SomeAsyncOperation is still being awaited and its result is written to the console.

### Expected Outcome: 

The modified code should no longer cause a deadlock. When you run the application, it should wait for one second and then print "Hello, World!" to the console.

This task will deepen your understanding of how async/await works in C# and help you recognize and avoid common pitfalls that can lead to deadlocks. It's a crucial skill for writing robust and efficient asynchronous code.

## Task 6: Real-World Application of ConfigureAwait in a Console Application with Thread Tracking 

### Description: 

In this task, you will be creating a console application that makes use of ConfigureAwait(false) to optimize performance during long-running operations. This task will demonstrate how ConfigureAwait(false) can be used to instruct the awaiter to continue on a thread pool instead of the original context. For better understanding, you will also print the managed thread ID before and after the awaitable operation.

### Steps: 

Create a new console application in C#.

Implement an async method MethodA that simulates a long-running operation, such as processing a large amount of data or performing a complex calculation. This method should simulate a delay (representing the time-consuming operation) using Task.Delay.

Use ConfigureAwait(false) in the MethodA to ensure that the continuation does not have to be run on the original context.

Before and after the awaitable operation in MethodA, print the managed thread ID to the console using Thread.CurrentThread.ManagedThreadId.

Implement a second async method MethodB that calls MethodA, awaits its result, and then performs some further processing (for example, additional calculations or data manipulations).

In your Main method, call MethodB and output the final result to the console.

### Expected Outcome: 

When you run the application, it should print the managed thread ID before and after the awaitable operation in MethodA, wait for the delay in MethodA, then perform the further processing in MethodB, and finally print the result to the console. The use of ConfigureAwait(false) in MethodA means that the continuation (the further processing in MethodB) can be run on any thread pool thread, which can lead to performance optimizations in certain scenarios.

This task will give you a visual representation of how ConfigureAwait(false) can change the context in which the continuation is run. By printing the managed thread ID before and after the awaitable operation, you can see that the continuation may be run on a different thread if ConfigureAwait(false) is used. This can help you better understand the implications of ConfigureAwait(false).

## Task 7: Understanding the Difference between Async Void and Async Task with Exceptions 

### Description: 

Create a console application that demonstrates the difference in error handling between async void and async Task methods. This will help you understand why it's generally recommended to avoid async void methods except for event handlers.

### Steps: 

Create a new console application in C#.

Implement an async void method VoidMethod that throws an exception.

Implement an async Task method TaskMethod that also throws an exception.

In your Main method, call VoidMethod and TaskMethod within separate try-catch blocks and attempt to catch and handle the exceptions.

### Expected Outcome: 

When you run the application, you will find that the exception thrown by VoidMethod cannot be caught and crashes the program, while the exception thrown by TaskMethod can be caught and handled. This is because exceptions thrown by async void methods cannot be caught outside of the method and will always propagate up to the synchronization context, while exceptions thrown by async Task methods will be caught by the calling code if awaited.

This task will help you understand the implications of using async void methods and why they should generally be avoided. In most cases, you should prefer async Task methods, as they allow for better error handling and improved program stability. Then When and Why would you prefer async void?

## Documentation

### Description

Asynchronous programming in C# is a powerful feature that allows you to write non-blocking code, making your applications more responsive and efficient, especially when dealing with I/O-bound or long-running operations. It's based on the `async` and `await` keywords introduced in C# 5.0.

1. **Async and Await Keywords:** To mark a method as asynchronous, you use the `async` keyword before the method declaration. Inside this method, you can use the `await` keyword before an asynchronous operation, indicating where the method can pause and yield control back to the caller until the awaited operation completes.

2. **Task-Based Asynchronous Programming (TAP):** The foundation of C#'s asynchronous programming is the `Task` class. It represents an asynchronous operation and is used to manage concurrency. The `async` methods return a `Task` or `Task<T>` to represent the result of the asynchronous operation.

3. **I/O-Bound vs. CPU-Bound:** Asynchronous programming is most beneficial for I/O-bound operations, such as reading/writing files, making network requests, or querying a database, where the application would otherwise be idle while waiting for the operation to complete. It's less useful for CPU-bound operations, where parallelism might be a better choice.

4. **Avoiding UI Freezing:** In desktop or mobile applications, asynchronous programming is crucial to prevent the user interface from freezing when performing time-consuming operations. It keeps the UI responsive while the background work is being done.

5. **Exception Handling:** Exception handling in asynchronous code can be a bit more complex. When an exception occurs in an asynchronous method, it's wrapped in an `AggregateException`. You can use `try-catch` blocks around `await` statements to handle exceptions gracefully.

6. **Cancellation:** C# provides the `CancellationToken` and `CancellationTokenSource` classes for handling cancellation of asynchronous operations. This allows you to cancel ongoing tasks gracefully.

7. **Async Event Handling:** You can use `async` and `await` with event handlers, making it easier to handle events asynchronously.

8. **Async Streams:** C# 8.0 introduced async streams, which allow you to consume asynchronous data sequences in a streaming fashion.

9. **Task.Run:** Sometimes, you may want to offload CPU-bound work to a separate thread using `Task.Run` within an asynchronous method. This is useful to avoid blocking the main UI thread.

10. **Async Best Practices:** It's essential to follow best practices when writing asynchronous code, like avoiding `async void` methods, using `ConfigureAwait(false)` for library code, and understanding synchronization contexts.

### Code Description

- I have used the Async method to await for the method to have the result. In the Task 1 the HttpClient is class is used to get the details from the web server in the asynchronous manner. The Returned string is processed using the HtmlDocument to extract the text except the tags from the website and displaying in the console. The URL is validated to whether the URL entered by the user is correct.

- In the Task 2, The `Parallel.ForEach` will execute the task in the available threads in the thread pool. It execute in the simultaneously to process much faster than the sequential manner of the normal `foreach`. The Project uses the stopwatch to calculate the amount of the time required to run the each task.

- In the Task 3, By using the multi-threading concept the threads are created accourdingly and each thread will perform the sorting and calculation on the array. The `Thread.Start()` will start the execution of the Task. The `Thread.Join()` it will wait for the Task to complete the work.

- In the Task 4, Project uses the multiple method that will await for the task to complete the work and depends on the result from the method, All method will asynchronous wit for the result from the method. The Method A returns the part of the url that can be used in the method b to fetch the url. The Method C will parse the string by using the JObject to print the count of the count of the properties.

- In the Task 5,The DeadLock is rectified by the remove the `.Result` it will hold the current thread till the execution. The Changed into the await for the result it will not hold the main thread.

- In the Task 6, By using the `configureAwait(true)` it will switch to the current synchronization context. `configureAwait(false)` If you pass false, then the continuation is being allowed to run on a thread-pool thread instead of pulling back to the current synchronization context.

- In thr Task 7,The Async Void Method will throw the exception directly into the OS, The Async Task Method will handle the exception by using the try and catch block.

- The test cases for all the method and class are covered by the valid and invalid input to the method. The test case also test the method by passing the url to the methods.

## Takeaways 

**Task 1 (Async/Await):** We learned how to create asynchronous methods using the `async` and `await` keywords. This allows us to perform time-consuming operations without blocking the main thread, ensuring application responsiveness.

**Task 2 (TPL):** We explored the Task Parallel Library (TPL) and its `Parallel.ForEach` method. By parallelizing operations, we can significantly improve performance when dealing with large datasets or repetitive tasks.

**Task 3 (Multi-Threading):** This task delved into multi-threading using the `Thread` class. We saw how to run multiple operations concurrently and combine their results, which is valuable for tasks requiring parallel execution.

**Task 4 (Multi-Layered Async/Await Operations):** We tackled a real-world scenario where a CPU-bound operation triggered a chain of asynchronous operations. This demonstrated how to structure complex workflows using `async/await` and `Task.Run()`.

**Task 5 (Debugging and Fixing Deadlocks):** We encountered and resolved a deadlock situation, emphasizing the importance of avoiding blocking calls like `.Result` or `.Wait()` on asynchronous operations.

**Task 6 (ConfigureAwait(false)):** By using `ConfigureAwait(false)`, we optimized performance during long-running operations and visualized how the continuation thread can change, offering insights into thread management.

**Task 7 (Async Void vs. Async Task):** We understood the differences in error handling between `async void` and `async Task` methods. `async void` is suitable for event handlers and fire-and-forget scenarios but should be used cautiously due to unhandled exceptions.

## Real - Time Use Case:

1. **Web API Calls**: In a web application, you often need to make asynchronous HTTP requests to external APIs. Asynchronous programming allows you to make these calls without blocking the main thread, ensuring your application remains responsive while waiting for the response.

2. **Chat Applications**: Real-time chat applications, like Slack or WhatsApp, heavily rely on asynchronous programming. Messages are sent and received asynchronously in the background, allowing users to send and receive messages without waiting.

3. **Online Gaming**: Online multiplayer games use asynchronous programming for real-time interactions between players. Actions performed by one player are asynchronously transmitted to others, maintaining synchronized gameplay.

4. **Social Media Feeds**: Social media platforms use asynchronous programming to update users' feeds in real-time. When someone posts a new message or update, it's asynchronously pushed to followers' feeds.

5. **File Upload and Download**: When uploading or downloading large files in a web application, asynchronous programming is essential to prevent the operation from blocking the user interface.

6. **Streaming Services**: Platforms like Netflix and YouTube stream video content asynchronously. Content is fetched in chunks and displayed as it becomes available, allowing for smooth playback.

## Conclusion

In conclusion, this assignment has provided a comprehensive exploration of key asynchronous programming concepts in C#, including Async/Await, the Task Parallel Library (TPL), and multi-threading. Through a series of practical tasks and examples, we've gained valuable insights into how these concepts can be applied to optimize the performance and responsiveness of C# applications.
