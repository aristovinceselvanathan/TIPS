# Reflection in C# - Hands-on Technical Assignment 

## Overview 

Welcome to this challenging technical assignment on Reflection in C#. The objective of this assignment is to provide you with practical experience in understanding and implementing various aspects of Reflection in C#. This exercise is designed to challenge your knowledge and skill level and should be completed with the intention of acquiring a deeper understanding of the topic. 

## Task 1: Inspect Assembly Metadata 

In this task, you will write a program that inspects the metadata of an assembly. You should display information about the types defined in the assembly, their methods, properties, fields, and events. 

### Steps: 

Use the Assembly.LoadFile method to load the assembly. 

Use the GetTypes method to get all the types in the assembly. 

For each type, use the GetMethods, GetProperties, GetFields, and GetEvents methods to get the methods, properties, fields, and events respectively. 

## Task 2: Dynamic Object Inspector 

In this task, you will create a dynamic object inspector. This tool should take an object as input and display its properties and their current values. It should also allow the user to change these values at runtime. 

### Steps: 

Create a class with a method that accepts an object as a parameter. 

Use the GetType method to get the Type of the object. 

Use the GetProperties method to get all properties of the object. 

Display the name and current value of each property. 

Implement a method that accepts a property name and a new value, and sets the property to the new value using the SetValue method. 

## Task 3: Dynamic Method Invoker 

In this task, you will implement a method invoker that can call methods on an object dynamically, based on the method name provided as a string. 

### Steps: 

Create a class with a method that accepts an object and a string as parameters. 

Use the GetType method to get the Type of the object. 

Use the GetMethod method with the provided string to get the MethodInfo object. 

Call the Invoke method on the MethodInfo object to call the method on the object. 

## Task 4: Plugin System  

In this task, you will implement a plugin system for a simple application. The main application should be able to discover and load plugins (assemblies) at runtime, and call methods on these plugins using Reflection. 

### Steps: 

Define a common interface for plugins. 

Create one or more plugins that implement the interface and compile them to .dll files. 

In the main application, use Assembly.LoadFile to load each plugin assembly. 

Use GetType and GetInterface methods to get types that implement the plugin interface. 

Create instances of the plugin types and cast them to the plugin interface. 

Call methods on the plugins through the plugin interface. 

## Task 5: Mocking Framework 

In this task, you will use Reflection to dynamically generate a mock object for unit testing. 

Steps: 

Identify an interface that you want to mock. This could be an interface from your existing project, or a new one created for this task.  

Use Reflection to create a dynamic type that implements the interface. Use the TypeBuilder class from the System.Reflection.Emit namespace to define the new type. 

For each method in the interface, use MethodBuilder to create a corresponding method in the dynamic type. These methods should return default values suitable for testing. 

Create an instance of your dynamic type and use it in a unit test. You should be able to call the methods of the interface and get the default values that you defined. 

## Task 6: Serialization API 

In this task, you will implement a simple serialization API using Reflection, and then identify its limitations and rewrite it using Reflection.Emit. 

### Steps: 

Implement a simple serialization API using Reflection. This API should be able to take an object and turn it into a serialized format (like a string or a byte array). 

Test the API with various types of objects and observe its behavior. 

Identify the limitations of your API. You might find that some types are not serialized correctly, or that the serialization process is too slow for large nested objects. 

Rewrite your serialization API using Reflection.Emit. Use the System.Reflection.Emit namespace to generate dynamic methods for serialization. 

Compare the performance and correctness of your new API with the original one.  

# Documentation

##  Introduction

Reflection in programming refers to the ability of a program to inspect, analyze, and manipulate its own structure, as well as the structures of data and code it works with. In the context of C# and the .NET Framework, Reflection is a fundamental and powerful feature that allows you to examine and interact with the metadata and structure of types and assemblies at runtime. Here are some key aspects of Reflection:

1. **Metadata Inspection:** Reflection provides a means to examine the metadata of assemblies, types, and members. This includes information about classes, methods, properties, fields, events, and more. You can discover details like type names, method signatures, attribute information, and access modifiers.

2. **Dynamism:** Reflection enables dynamic interactions with types and objects. You can instantiate types, invoke methods, set and retrieve properties, and access fields, all at runtime. This is particularly useful in scenarios where you need to work with code whose structure is not known at compile time.

## Understandings

1. **System.Reflection Namespace:** The `System.Reflection` namespace is crucial for working with Reflection in C#. It contains classes and methods for inspecting types, assemblies, methods, fields, properties, and more. You'll use classes like `Assembly`, `Type`, and `MethodInfo` from this namespace.

2. **System.Reflection.Emit Namespace:** This namespace provides classes and methods for emitting and generating dynamic code. You might need this for tasks like creating dynamic types or methods. Classes like `TypeBuilder` and `MethodBuilder` are essential components of dynamic code generation.

3. **System.Reflection.Assembly Class:** This class represents an assembly and is used to load external assemblies, retrieve assembly metadata, and instantiate types from assemblies.

4. **System.Type Class:** The `Type` class is a central component for working with Reflection. It represents a type (e.g., a class or an interface) and provides methods for inspecting the type's members, properties, methods, and more.

5. **System.Reflection.MethodInfo Class:** This class represents a method and provides information about the method's parameters, return type, and other details. You'll use it for dynamic method invocation.

6. **System.Reflection.PropertyInfo Class:** The `PropertyInfo` class represents a property of a type. It provides information about the property's data type, accessibility, and accessors.

7. **System.Reflection.FieldInfo Class:** This class is used to work with fields (data members) in types. It offers information about the field's data type and accessibility.

8. **System.Reflection.EventInfo Class:** This class represents an event of a type. It's used to inspect events and their properties.

9. **System.Activator Class:** The `Activator` class is useful for creating instances of types dynamically. You can use it to instantiate objects when you know the type's name as a string.

10. **Interfaces:** You may need to define and implement interfaces for your plugins (Task 5) or mocking framework (Task 6). Interfaces define the contract that classes must adhere to, ensuring compatibility.

12. **NewtonSoftJson** Serialization libraries used to serialize the object to print the details present in the object (Task 7).

## Code Description

1. **Assembly Metadata (1):**

    - Load the assembly file using the `Assembly.LoadFile` method.
    - Use `Assembly.GetTypes()` to retrieve all the types in the loaded assembly.
    - For each type, use methods like `Type.GetMethods()`, `Type.GetProperties()`, `Type.GetFields()`, and `Type.GetEvents()` to obtain information about methods, properties, fields, and events, respectively.
    - Display the retrieved metadata to the user.

2. **Dynamic Object Inspector (2):**

    - Prompt the user to enter the path of an assembly file or use a default file.
    - Get the `Type` of the object in the selected assembly using `GetTheObjectType.GetTheTypeOfTheObject()`.
    - If the type is not null, create an instance of the type using `Activator.CreateInstance()`.
    - Use the `ReflectionsMethods.ChangeThePropertyOfTheObject()` method to allow the user to modify the properties of the dynamically created object.

3. **Dynamic Method Invoker (3):**

    - Prompt the user to enter the path of an assembly file or use a default file.
    - Get the `Type` of the object in the selected assembly using `GetTheObjectType.GetTheTypeOfTheObject()`.
    - If the type is not null, create an instance of the type using `Activator.CreateInstance()`.
    - Use the `ReflectionsMethods.InvokeTheMethodFromObject()` method to allow the user to invoke methods on the dynamically created object.

4. **Plugin System (4):**

    - Initialize a `Dictionary` to store plugin instances that implement the `ISampleInterface`.
    - Use `ReflectionsMethods.LoadPlugins()` to discover and load plugins from assemblies.
    - Iterate through the loaded plugins, printing their welcome messages using the `PrintWelcomeMessage()` method.


5. **Mocking Framework (5):**

    - Prompt the user to enter the path of an assembly file containing an interface definition (should start with "I") or use a default file.
    - Get the `Type` of the selected interface using `GetTheObjectType.GetTheTypeOfTheObject()`.
    - If the type is not null, use `ReflectionsMethods.CreateMockingInterface()` to create a dynamic mock object that implements the selected interface.
    - Display details of the created mock object.

6. **Serialization API (6):**

    - Prompt the user to enter the path of an assembly file or use a default file.
    - Get the `Type` of the object in the selected assembly using `GetTheObjectType.GetTheTypeOfTheObject()`.
    - If the type is not null, create an instance of the type using `Activator.CreateInstance()`.
    - Serialize the object to a JSON string using the `JsonConvert.SerializeObject()` method and display the serialized data.

## Conclusion

The Reflection in C# project is a comprehensive exploration of the powerful capabilities and practical applications of Reflection in the context of the .NET Framework. Throughout this project, we have delved into various aspects of Reflection, from inspecting assembly metadata to building dynamic and extensible software systems. Here is the conclusion for this project:

1. **Deepened Understanding of Reflection:** This project has provided a hands-on experience in working with Reflection, a fundamental feature of the .NET Framework. It has allowed us to understand the inner workings of Reflection and its real-world applications.

2. **Dynamic Code Generation:** The project highlighted the dynamic code generation capabilities of Reflection, particularly using `Reflection.Emit` to create new types, methods, and properties at runtime. This is essential in scenarios where code needs to be generated on the fly.

In summary, the Reflection in C# project has provided a comprehensive and hands-on learning experience in utilizing Reflection for various runtime tasks. The practical tasks and code examples have equipped you with the knowledge and skills necessary to apply Reflection in real-world software development scenarios. Whether it's inspecting assembly metadata, creating dynamic code, building extensible software, or testing and serializing data, Reflection is a powerful tool that enhances the flexibility and functionality of C# applications. This project serves as a valuable resource for developers looking to harness the capabilities of Reflection in their software projects.