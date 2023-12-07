# IDisposable, Dispose Pattern, and Finalizer in C#

## Overview

This assignment aims to test and enhance your deep understanding of the IDisposable interface, Dispose Pattern, and Finalizers in C#. You will be creating and manipulating both managed and unmanaged resources, implementing the Dispose Pattern, and using Finalizers in C#.

### Learning Objectives

Upon completing this assignment, you should be able to:

1. Understand and apply the IDisposable interface and Dispose Pattern in C#.

2. Create and manage both managed and unmanaged resources.

3. Understand and use Finalizers in C#.

4. Understand and demonstrate efficient resource management.

## Task 1: Understanding the difference between Managed and Unmanaged Resource

1.1: Create a new Console Application

1.2: Create a class called ManagedResource. This class will represent a managed resource in your application. Add a property to this class which is a List<string>.

1.3: Implement two methods in the ManagedResource class: AddData(string item) and ClearData(). AddData should add an item to the Data list, and ClearData should clear the list.

1.4: Now, create another class called UnmanagedResource. This class will represent an unmanaged resource. In this example, we'll use a File as our unmanaged resource. Implement a constructor that takes a file path as an argument and opens a StreamWriter to this file.

1.5: Implement two methods in the UnmanagedResource class: WriteToFile(string content) and CloseFile(). WriteToFile should write to the file using the StreamWriter, and CloseFile should close the StreamWriter.

1.6: In your Main method, create instances of both ManagedResource and UnmanagedResource. Use the methods you've implemented to manipulate the resources. For the UnmanagedResource class, observe what happens if you try to write to the file after closing it. Additionally, explore the scenario where you do not close the file after writing to it.

Expected Outcome: You should now understand the importance of properly managing both managed and unmanaged resources. The List<string> in ManagedResource is a managed resource because its memory is automatically managed by the .NET runtime. On the other hand, the StreamWriter in UnmanagedResource is an unmanaged resource because it requires explicit cleanup after use. Not doing so can lead to resource leaks or errors, and other programs may not be able to access the resource (in this case, the file) until your program has finished execution or the resource has been properly disposed of.

## Task 2: Implementing the IDisposable interface

2.1. Update your classes from Task 1 to implement the IDisposable interface.

2.2. In the Dispose() method, write the logic to correctly dispose of your managed and unmanaged resources. This might involve calling the Dispose() method on managed resources and explicitly releasing any unmanaged resources.

2.3. Modify your main program to call the Dispose() method when done with the resource.

2.4. Test your application to ensure that resources are being correctly disposed of when Dispose() is called.

Expected Outcome: Your application should successfully implement the IDisposable interface and correctly dispose of both managed and unmanaged resources.

## Task 3: Implementing the Dispose Pattern

3.1. Refactor your classes from Task 2 to implement the Dispose Pattern. This involves implementing both the Dispose() method and a finalizer.

3.2. The Dispose() method should dispose of both managed and unmanaged resources and suppress finalization.

3.3. The finalizer should only dispose of unmanaged resources.

3.4. Test your application to ensure that resources are being correctly disposed of and that the Dispose Pattern is correctly implemented.

Expected Outcome: Your application should implement the Dispose Pattern correctly and efficiently handle resources.

## Task 4: Using Finalizers

4.1. Implement a finalizer in your classes from Task 3.

4.2. The finalizer should clean up unmanaged resources in the case that the Dispose() method is not called.

4.3. Modify your main program to test this condition. Create resources, use them, but do not call Dispose().

4.4. Test your application to ensure that the finalizer is correctly cleaning up resources when Dispose() is not called.

Expected Outcome: Your application should have a finalizer that correctly cleans up resources if Dispose() is not called.

# Documentation Report

In C#, the IDisposable interface is used to release unmanaged resources. The Dispose method is used to ensure the deterministic release of resources for instances of a class. The Dispose method can be implemented using the using-dispose pattern.

The Finalize method is used to release unmanaged resources in C#. The garbage collector invokes destructors, which are converted to finalize methods during compilation. The garbage collector frequently checks generation 0 for inactive objects. If an object has implemented the finalize method, the garbage collector moves that object to the finalize queue. The checking of the finalize queue is infrequent, and even if an object is inactive and not in use, it will remain in memory heap. We don’t know when it will release the unmanaged resources.

The Dispose pattern involves implementing the IDisposable interface and declaring the Dispose(bool) method that implements all resource cleanup logic to be shared between the Dispose method and the optional finalizer.

# Code Description

## Task 1:

- I have Created a new Console Application. Created a class called ManagedResource. This class will represent a managed resource in the application. Add a property to this class which is a List <string> .Implemented two methods in the ManagedResource class: AddData(string item) and ClearData(). AddData should add an item to the Data list, and ClearData should clear the list.

- And created another class called UnmanagedResource. This class will represent an unmanaged resource. In this example, we’ll use a File as our unmanaged resource. Implement a constructor that takes a file path as an argument and opens a StreamWriter to this file. Implemented two methods in the UnmanagedResource class: WriteToFile(string content) and CloseFile(). WriteToFile should write to the file using the StreamWriter, and CloseFile should close the StreamWriter.

- In the Main method, create instances of both ManagedResource and UnmanagedResource. Use the methods implemented to manipulate the resources. For the UnmanagedResource class, observed what happens if try to write to the file after closing it. Additionally, explore the scenario where do not close the file after writing to it.

## Task 2:

- Declared a class that implements the IDisposable interface in order to implement the interface. A dispose method that frees up all resources used by the object should be included in the class. The using-dispose pattern can be used to implement the Dispose function.

- All managed and unmanaged resources used by the object should be released by the Dispose method. Unmanaged resources are normally released by invoking a native API function, but managed resources are usually released by calling their Dispose method.

- When processing the resource is complete, I have called the Dispose method in the main application. This guarantees that all resources are released promptly.

- I have confirmed that every resource is being properly disposed of when Dispose is called in order to test the application.

## Task 3:

- I've declared a class that complies with the IDisposable interface in order to implement the Dispose Pattern in C#. A dispose method that frees up all resources used by the object should be included in the class. The using-dispose pattern can be used to implement the Dispose function.

- Implementing the Dispose method as well as a finalizer is part of the Dispose Pattern. Both controlled and unmanaged resources should be eliminated by the Dispose method, which should also prevent finalization. Only unmanaged resources should be disposed away by the finalizer.

- When processing of the resource is complete, I have called the Dispose method in the main application. This guarantees that all resources are released promptly.

- To test the application and confirm that when Dispose is called, all resources are being properly disposed of. I've employed

## Task 4:

- To implement a finalizer, I  have declared a destructor in the class. The destructor is called when the object is being garbage collected. The finalizer should clean up unmanaged resources in the case that the Dispose() method is not called.

- In the main program, I have tested this condition by creating resources, using them, but not calling Dispose(). This will cause the garbage collector to eventually collect the object and call the finalizer.

- To ensure that the finalizer is correctly cleaning up resources when Dispose() is not called,and verify that all unmanaged resources are being released. I have used a memory profiler to check for any memory leaks or other issues.

# TakeAways

IDisposable is an interface in C# that is used to relinquish unmanaged resources. To guarantee the predictable release of resources for instances of a class, utilize the dispose method. The using-dispose pattern can be used to implement the Dispose function.

In C#, unmanaged resources are released using the Finalize method. Destructors are called by the trash collector and transformed into finalize methods during compilation. Generation 0 is often checked by the garbage collector for inactive items. The garbage collector adds an object to the finalize queue if it has implemented the finalize method. Even if an object is inactive and not in use, it will still be present in the memory heap because the finalize queue is only sometimes checked. When it will release the unmanaged resources is unknown. By the using keyword it automatically call the dispose method of the class.

# Conclusion

In C#, unmanaged resources are released by using the IDisposable interface, to summarize. To guarantee the predictable release of resources for instances of a class, utilize the dispose pattern. The pattern entails using a finalizer as well as the Dispose function. While the finalizer should only get rid of unmanaged resources, the Dispose function should get rid of both managed and unmanaged resources and inhibit finalization.

You must specify a class that adheres to the IDisposable interface in order to implement the Dispose Pattern. A dispose method that frees up all resources used by the object should be included in the class. The using-dispose pattern can be used to implement the Dispose function.

When you are done with a resource, your main program should invoke the Dispose method. This guarantees that all resources are released in a timely manner. If Dispose() is not called, then the finalizer will clean up unmanaged resources.