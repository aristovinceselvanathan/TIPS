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
whereas the method with the many local variables uses more stack memory.
## Task 3: Using Garbage Collection and Understanding Its Impact on Performance
**Objective**: Understand how garbage collection works in C#, and how it can impact application performance.<br>
### Task Steps:
1. Create a new C# Console Application named "GarbageCollection".
2. Create a method that creates and destroys a large number of objects in a for loop with large
count.
3. Observe the memory usage of your application using a profiling tool.
4. Use GC.CoIIect to manually trigger garbage collection and observe the impact on memory usage.<br>
**Expected Outcome**: You should see a drop in memory usage after garbage collection occurs. Also, you
should notice the performance impact when garbage collection is triggered.
## Task 4: Implementing and Understanding the IDisposable Interface and the 'using' Statement
**Objective**: Understand the purpose of the IDisposable interface, how the 'using' statement can be used
to automatically dispose of objects, and how to release file resources properly.<br>
### Task Steps:
1. Create a new C# Console Application named "IDisposabIeDemo".
2. Create a class that opens a file for writing and implements the IDisposable interface. In the Dispose method, ensure that the file is properly closed and released.
3. In the Main method, create an instance of this class in a 'using' block. Write some text to the file.
4. After the 'using' block, attempt to open the same file for reading. If the file was properly released, this should be possible without any errors.<br>
**Expected Outcome**: The application should be able to open the file for reading after the 'using' block,
demonstrating that the file was properly released when the IDisposable object was disposed.
# Documentation Report: 
## Value Types and Reference Types Tasks
## Task 1: Understanding and Using Value Types and Reference Types in C#
**Objective** : The objective of this task is to understand the differences between value types and reference types in C#, and demonstrate their use in a C# application.

### Steps
1. Create a new C# Console Application named "ValueAndReferenceTypes".
2. In the Main method, define a value type (e.g., an integer or a struct) and a reference type (e.g., a class).
3. Create a method that takes both types as parameters and modifies them.
4. Invoke this method in the Main method, then print out the values of both types afterwards to observe the difference in behavior.<br>
**Expected Outcome**
The value type should remain unchanged after the method call, whereas the reference type should reflect the changes made within the method.

## Task 2: Working with the Stack and the Heap
Objective
The objective of this task is to gain a practical understanding of how the stack and the heap work in C#.

Steps
1. Extend the "ValueAndReferenceTypes" project.
2. Create two methods: one that creates a large array of integers (a reference type), and another that performs a calculation with a large number of local variables (value types).
3. Use a profiling tool, such as Visual Studio's Diagnostic Tools, to observe how memory is used when these methods are called.<br>
**Expected Outcome**
You should observe that the method with the large array uses more heap memory, whereas the method with the many local variables uses more stack memory.

I hope this documentation report is helpful! Let me know if you have any other questions.
## Garbage Collection and IDisposable Interface Tasks
This report documents two tasks related to garbage collection and the IDisposable interface in C#.
## Task 1: Understanding Garbage Collection Objective
The objective of this task is to understand how garbage collection works in C#, and how it can impact application performance.

### Steps
1. Create a new C# Console Application named "GarbageCollection".
2. Create a method that creates and destroys a large number of objects in a for loop with large count.
3. Observe the memory usage of your application using a profiling tool.
4. Use GC.Collect to manually trigger garbage collection and observe the impact on memory usage.<br>
**Expected Outcome**
You should see a drop in memory usage after garbage collection occurs. Also, you should notice the performance impact when garbage collection is triggered.
## Task 2: Implementing and Understanding the IDisposable Interface and the 'using' Statement
**Objective** : The objective of this task is to understand the purpose of the IDisposable interface, how the using statement can be used to automatically dispose of objects, and how to release file resources properly.

### Steps
1. Create a new C# Console Application named "IDisposableDemo".
2. Create a class that opens a file for writing and implements the IDisposable interface. In the Dispose method, ensure that the file is properly closed and released.
3. In the Main method, create an instance of this class in a using block. Write some text to the file.
4. After the using block, attempt to open the same file for reading. If the file was properly released, this should be possible without any errors.
**Expected Outcome**
The application should be able to open the file for reading after the using block, demonstrating that the file was properly released when the IDisposable object was disposed.

## Conclusion
These tasks provide a basic understanding of value types and reference types in C#, and how they are stored in memory. By completing these tasks, you should have a better understanding of how to use value types and reference types in your C# applications.

These tasks provide a basic understanding of garbage collection and the IDisposable interface in C#. By completing these tasks, you should have a better understanding of how to manage memory and resources in your C# applications.