# Understanding the .NET platform 

## Exploration Questions: 

### 1. Explain what the .NET platform is and its primary purpose.
    .NET is the free, cross – platform, open-source developer platform for building many different types of applications. We can .NET to build web, mobile, desktop applications and many more. .NET Supports the three different languages are C#, F#, and Visual Basic3 

    C# is an Object-oriented, modern, simple, type-safety programming language. F# is a Programming language makes it easy to write succinct, robust, and performant code. 

    Visual Basic is a language with simple syntax to building type-safe, object-oriented apps. 

    Its main purpose is to convert the high-level language into the machine level language, it provides the utilities for efficient software development. It manages the way to store the data types. 

### 2. What are the key components of the .NET platform?
    The two major components of .NET Framework are the Common Language Runtime (CLR) and the .NET Framework Class Library. The CLR is the execution engine that handles running applications. It provides the services like garbage collection, type-safety, exception handling and more. 

    The Frame Class Library (FCL) provides handling of the data types like int, string, float etc. It provides the various class, interfaces. It is broadly classified into three types are Utility Features, Wrappers around OS Functionality and Frameworks. 
    
    The Utility Features includes various collection classes such as list, queue, dictionary etc. and class for more varied manipulation such as Regex Class. Wrappers around OS Functionality includes the file system, class to handle network features, handle I/O for console applications. Frameworks available in FCL to develop certain applications. Windows presentation Foundation (WPF) is used to render UI for Windows Applications. 
    
### 3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET.
    CLR stands for Common Language Runtime. It provides the necessary runtime environment and services for the managed code created by the compiler and runs the code. CLR is responsible for the management of the object layout, referencing the objects and releasing them when not necessary. It is also responsible for the Garbage Collection. CTS stands for Common Type System. It is a subsystem of the CLR, which describes how the types are declared, used, and managed in the runtime. 
    
### 4. What is the role of the Global Assembly Cache (GAC) in .NET?
    The Common Language Runtime (CLR), when installed on a computer, introduces a significant component known as the 'Global Assembly Cache' (GAC). This machine-wide code cache acts as a designated folder, residing within the Windows directory, which serves as a repository for .NET assemblies explicitly intended for shared utilization across all applications running on the system. By registering assemblies in the Global Assembly Cache (GAC), they can be seamlessly shared among multiple applications on the machine, promoting code reuse and avoiding duplication. 
    
    The GAC is an integral part of the .NET runtime and is automatically installed alongside it. It assumes its position within the 'Windows/WinNT' directory and inherits the access control list (ACL) of the directory, thereby adhering to the protective measure’s administrators have put in place. This tool empowers developers and administrators to inspect and manipulate the contents of the GAC, granting them the ability to add, remove, or update assemblies within the cache as needed. 
    
### 5. Explain the different between value types and reference types in C#.
    Value types are stored directly in the stack, which is the memory used for holding local variables and function parameters. Reference types, on the other hand, are stored in the heap, which is where dynamically allocated objects are kept. 
    
    Value types are automatically initialized to their default value when they are created. For example, an int is initialized to 0. Reference types are automatically initialized to null when they are created. When we assign a value type to another value type, the value is copied directly from one variable to the other. But when we do the same thing with reference types, it only copies the reference and not the actual object. 
    
    When we compare two value types using ==, it compares the actual values. But when we compare two reference types, it only compares the reference to the object. So, two reference variables are only considered equal if they refer to the same object in memory. 
    
### 6. Describe the concept of garbage collection on .NET and its Advantages.
    With the garbage collector, developers don’t need to worry about manually allocating or freeing up memory. The garbage collector takes care of memory management automatically, which can help reduce the risk of memory leaks and other issues.  
    
    The garbage collector runs in the background and typically has a low impact on application performance. However, in some cases, garbage collection can cause brief pauses or slowdowns in the application, particularly when large amounts of memory need to be freed up at once. 
    
    The garbage collector in C# uses a generation-based approach to memory management. Objects are initially allocated in a “young” generation and are moved to an “old” generation if they survive multiple garbage collection cycles. This approach helps reduce the amount of time required for garbage collection, as most objects are collected in the young generation. 
    
    The garbage collector also provides support for finalization, which is a process that allows objects to perform cleanup tasks before they are destroyed. Objects with finalizers are moved to a separate finalization queue, which is processed by the garbage collector after all other objects have been collected. 
    
### 7. What is the purpose of the globalization and Localization features in .NET?
    Globalization and localization are essential aspects of software development in the .NET framework. Globalization refers to the process of designing applications that can be adapted to various cultures and regions, allowing them to be used by a diverse range of users worldwide. Localization, on the other hand, involves customizing an application to a specific culture or region by providing localized resources such as language translations, date and time formats, number formats, and other culture-specific elements. 
    
### 8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework.
    The Microsoft Intermediate Language (MSIL), also known as the Common Intermediate Language (CIL) is a set of instructions that are platform independent and are generated by the language-specific compiler from the source code. The MSIL is platform independent and consequently, it can be executed on any of the Common Language Infrastructure supported environments such as the Windows .NET runtime. The MSIL is converted into a particular computer environment specific machine code by the JIT compiler. 
    
    Just-In-Time compiler (JIT) is a part of Common Language Runtime (CLR) in .NET which is responsible for managing the execution of .NET programs regardless of any .NET programming language. A language-specific compiler converts the source code to the intermediate language. This intermediate language is then converted into the machine code by the Just-In-Time (JIT) compiler. This machine code is specific to the computer environment that the JIT compiler runs on.  
    
    The JIT compiler requires less memory usage as only the methods that are required at run-time are compiled into machine code by the JIT Compiler. Page faults are reduced by using the JIT compiler as the methods required together are most probably in the same memory page.  

### By: Aristo Vince S (Solin)
