# Building a Robust Logging System Using Singleton and Factory Patterns in C#

# Task 1: Implement the Singleton Logging System

### Objective

Construct a thread-safe Singleton class named LoggingSystem.

### Starter Code and Hint

```csharp
public class LoggingSystem
{
    private static LoggingSystem instance;
    private static readonly object padlock = new object();
    private LoggingSystem() {}
    // Implement Singleton logic here using Double-Checked Locking
}```

Hint: Use double-checked locking to make your Singleton implementation thread-safe.

Steps

1. Singleton Implementation: Make LoggingSystem a Singleton. To ensure thread safety, use the double-checked locking pattern. About Double-Checked Locking: Here, you first check if the instance is created; if not, then you acquire a lock and check again. Only one instance gets created even in a multi-threaded environment.

``` csharp
public static LoggingSystem Instance
{
    get
    {
        if (instance == null)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new LoggingSystem();
                }
            }
        }
    return instance;
    }
}
```

2. Log Method: Implement LogMessage(string message, string type) method where type determines the log format ("PlainText" or "JSON").

### Expected Outcome

1. A thread-safe Singleton LoggingSystem class that employs double-checked locking, complete with a LogMessage method.

## Task 2: Implement the Factory Method for Logger Types

### Objective

Create a Factory Method to allow the instantiation of different types of loggers.

### Starter Code

```csharp
public interface ILogger 
{ 
    void Log(string message); 
} 
public abstract class LoggerFactory 
{ 
    public abstract ILogger CreateLogger(string type); 
}
```


### Steps

1. Logger Implementations: Implement two classes (PlainTextLogger, JSONLogger) that implement the ILogger interface.

2. PlainTextLogger: Should log the message as-is.

3. JSONLogger: Should log the message as a JSON object, e.g., {"message": "your log message here"}.

4. Concrete Factory: Implement a concrete class SimpleLoggerFactory that overrides CreateLogger.

### Expected Outcome

1. Two logger types (PlainTextLogger and JSONLogger) with specific logging formats.

2. SimpleLoggerFactory that creates the correct logger type.

## Task 3: Integrate Singleton and Factory Patterns

### Objective

Merge the Singleton and Factory patterns by having the Singleton LoggingSystem utilize the Factory Method.

### Steps

1. Factory Integration: Utilize the Factory Method within LogMessage of LoggingSystem to create the appropriate logger.

2. Demo Application (Driver Code): Create a small application that simulates different modules (e.g., "UI", "BusinessLogic") logging messages.

3. For example, the "UI" module can use "PlainText" logs, while the "BusinessLogic" module can use "JSON" logs.

4. Documentation: Write in-code comments to explain how the Singleton and Factory patterns work together.

### Expected Outcome

1. A LoggingSystem Singleton that uses the Factory Method for object creation.

2. A working demo application.

3. Comments or documentation explaining the interaction between Singleton and Factory patterns.

# Documentation

## Singleton Pattern

The Singleton pattern is a design pattern that restricts the instantiation of a class to one object and provides a way to access its object. This is useful when exactly one object is needed to coordinate actions across the system. The Singleton Design Pattern in C# falls under the creational Pattern Category. It belongs to the creational pattern category, dealing with object creation and manipulation.

To implement the Singleton Design Pattern in C#, . This is required because it will restrict the class from being instantiated from outside the class. It only instantiates from within the class. We must create a private static variable referencing the class’s singleton instance. This method or property first checks whether an instance of the singleton class is created and lock the object.If the singleton instance is created, it returns that instance; otherwise, it will create an instance and then return it.

## Factory Pattern

The Factory pattern is another creational pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created. In other words, subclasses are responsible for creating objects of a particular type.

To implement the Factory Pattern in C#, you need to declare an interface or abstract class for creating objects. You also need to create concrete classes that implement this interface or abstract class and provide their own implementation of the factory method.

## Task 1: LoggingSystem Class

- I have implemented the singleton pattern to lock the object of the current thread. When the multiple instance of the class is created it will point to the single reference of the object.

- I have used the double checking to check the instance is null or not. I have used the get to returns the object.

- By this Logic the thread safe approach is implemented. It will process the smoothly if the multiple threads are accessing the same class. And log the message into the console without colliding with the multiple threads.

# Task 2 : Implement the Factory Method for Logger Types

- In the factory method, I have implemented the two classes of JSON Logger and Plain Text Logger. Both the class implements the ILogger Interface. The Plain Text logger it will print the message as plain message. The JSON Logger will print the message as the JSON format.

- I have created the SimpleLoggerFactory that inherits the LoggerFactory and overrides the create logger in the logger factory. In the create logger it will determine the type of the message to be printed either JSON or Plain Text.

- The Logger Factory is the abstract class. It has a abstract method to create the logger it is override in the child class.

# Task 3 :  Integrate Singleton and Factory Patterns

- In the LogMethod will call the create the type of logger by using the create logger method it will return the object of the specified logging method to log into the console.

- It will provide the integration between the singleton and factory method. By Specific the logging method.

- Singleton and Factory method it make the thread safe logic, avoid the multiple access of the same object when threads are run simultaneously.

# Conclusion

- In conclusion, both the Singleton and Factory patterns are valuable tools in software design, each serving distinct purposes.

- The Singleton pattern ensures that a class has only one instance, promoting resource efficiency and centralized control. It is ideal when you need a single point of access to a specific object, such as a database connection or a configuration manager.

- On the other hand, the Factory pattern excels at creating objects with more flexibility. It abstracts the instantiation process, allowing you to change the concrete classes without affecting client code. This pattern is particularly useful in scenarios where you need to create multiple instances of different types, like in GUI frameworks or plugins systems.

- Choosing between the Singleton and Factory pattern depends on your project's specific requirements. The Singleton pattern should be employed when you need to manage a single, shared instance, while the Factory pattern is a great choice for dynamic object creation and maintaining loose coupling between components. Understanding when and how to apply these patterns can greatly enhance the maintainability and scalability of your software systems.