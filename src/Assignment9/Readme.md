# Memory Management in C#: A Hands-On Assignment

## Task 1: Understanding and Using Value Types and Reference Types in C#

**Objective**: Understand the differences between value types and reference types in C#, and demonstrate
their use in a C#application.<br>

### Task Steps:

1. Create a new C# Console Application named "ValueAndReferenceTypes".
2. In the Main method, define a value type (e.g., an integer or a struct) and a reference type (e.g., a class).
3. Create a method that takes both types as parameters and modifies them.
4. Invoke this method in the Main method, then print out the values of both types afterwards to observe the difference in behavior.<br>
**Expected Outcome**: The value type should remain unchanged after the method call, whereas the reference type should reflect the changes made within the method.

## Task 2: Working with the Stack and the Heap

**Objective**: Gain a practical understanding of how the stack and the heap work in C#.<br>

### Task Steps:

1. Extend the "ValueAndReferenceTypes" project.
2. Create two methods: one that creates a large array of integers (a reference type), and another that performs a calculation with a large number of local variables (value types).
3. Use a profiling tool, such as Visual Studio's Diagnostic Tools, to observe how memory is used
when these methods are called.<br>
**Expected Outcome**: You should observe that the method with the large array uses more heap memory,
whereas the method with the many local variables uses more stack memory.<br><br>
![Alt text](MemoryManagement\01-ValueTypeAnDReferenceType.png)

## Task 3: Using Garbage Collection and Understanding Its Impact on Performance

**Objective**: Understand how garbage collection works in C#, and how it can impact application performance.<br>

### Task Steps:

1. Create a new C# Console Application named "GarbageCollection".
2. Create a method that creates and destroys a large number of objects in a for loop with large
count.
3. Observe the memory usage of your application using a profiling tool.
4. Use GC.Collect to manually trigger garbage collection and observe the impact on memory usage.<br>
**Expected Outcome**: You should see a drop in memory usage after garbage collection occurs. Also, you
should notice the performance impact when garbage collection is triggered.<br><br>
![Alt text](MemoryManagement\02-GarbageCollection.png)

## Task 4: Implementing and Understanding the IDisposable Interface and the 'using' Statement

**Objective**: Understand the purpose of the IDisposable interface, how the 'using' statement can be used
to automatically dispose of objects, and how to release file resources properly.<br>

### Task Steps:

1. Create a new C# Console Application named "IDisposableDemo".
2. Create a class that opens a file for writing and implements the IDisposable interface. In the Dispose method, ensure that the file is properly closed and released.
3. In the Main method, create an instance of this class in a 'using' block. Write some text to the file.
4. After the 'using' block, attempt to open the same file for reading. If the file was properly released, this should be possible without any errors.<br>
**Expected Outcome**: The application should be able to open the file for reading after the 'using' block,
demonstrating that the file was properly released when the IDisposable object was disposed.

# Documentation Report:

## Observations:

Garbage collection is a memory management technique used in the .NET Framework and many other programming languages. In C#, the garbage collector is responsible for managing memory and automatically freeing up memory that is no longer being used by the application.

The garbage collector works by periodically scanning the application’s memory to determine which objects are still being used and which are no longer needed. Objects that are no longer being used are marked for garbage collection, and their memory is freed up automatically by the garbage collector.

### Key Features:

1. Automatic memory management: Since the garbage collector handles memory allocation and cleanup automatically, developers don't have to worry about it. Automatic memory management is handled by the garbage collector, which can help lower the possibility of memory leaks and other problems.

2. The garbage collector often has no effect on application performance because it operates in the background. Garbage collection, nevertheless, can occasionally cause short delays or slowdowns in the application, especially when a lot of memory needs to be released at once.

3. Generation-based collection: The C# garbage collector manages memory in a generation-based manner. If an object survives numerous garbage collection cycles, it is transferred from the "young" generation to the "old" generation. Given that the majority of objects are collected by the younger generation, this strategy aids in reducing the time needed for rubbish collection.

4. Finalization: Before being destroyed, objects can complete cleanup duties through the finalization process, which the garbage collector also supports. Finalizer-equipped objects are transferred to a distinct finalization queue, which the garbage collector processes after collecting all other objects.

To allow for proper handling of multiple items with varying lifetimes during garbage collection, the heap memory is divided into three generations. Depending on the size of the project, the Common Language Runtime (CLR) will allocate a certain amount of memory to each Generation. To determine which items will be placed in Generation 1 or Generation 2, the Optimization Engine will internally invoke the Collection Means Method.

1. Generation 0: The generation 0 of the heap memory contains all the transient objects, such as temporary variables. Except for big objects, all newly allocated objects implicitly belong to generation 0. In general, generation 0 has the highest frequency of waste collection.

2. Generation 1: If some generation 0 objects take up space and are not removed during a trash collection cycle, such things are transferred to generation 1. The objects in this generation act as a kind of buffer between the generation 0 objects that have a short lifespan and the generation 2 things that have a long lifespan.

3. Generation 2: If certain generation 1 objects take up space that isn't freed up in the following trash collection cycle, those things are transferred to generation 2. The generation 2 objects have a lengthy lifespan since they stay in the heap memory throughout the entire process, like static objects.

## IDisposable Interface

IDisposable is an interface defined in the System namespace. It is used to release managed and unmanaged resources. Implementing the IDisposable interface forces us to implement 2 methods and one Boolean variable: 
 
- Public Dispose() : A consumer of an object calls this method when resources need to be freed. This method uses the Dispose (bool disposing) method. We also inform the Garbage Collector (GC) about the resource cleanup of the current object so that the GC does not do it again at the end. 
- Protected virtual Dispose(bool disposing): This method is  where all  variables are set to zero. A derived class can also override this method and release its own resources. This method is used to write the actual resource cleanup code. 
- Bool disposedValue: to ensure that the dispose method is called when a Boolean variable is used. Cleaning products should not be used more than once.

## Conclusion

These tasks provide a basic understanding of value types and reference types in C#, and how they are stored in memory. By completing these tasks, you should have a better understanding of how to use value types and reference types in your C# applications.

These tasks provide a basic understanding of garbage collection and the IDisposable interface in C#. By completing these tasks, you should have a better understanding of how to manage memory and resources in your C# applications.