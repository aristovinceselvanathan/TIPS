# Advanced Language Features

## Introduction

This documentation report provides a comprehensive overview of the assignment covering advanced C# programming concepts, including Events, Delegates, Dynamic, Var, Anonymous Methods, Lambda Expressions/Statements, records, and pattern matching. Each task is described along with the expected outcomes and corresponding test cases.

## Understandings:

**Task 1: Understanding and Implementing Events and Delegates**

- **Delegates:** Delegates are a fundamental concept in C#. In this task, you define a delegate named `Notify` that is used to encapsulate methods that accept a string message and return void. It's a way to create a signature for methods that can be subscribed to events.

- **Events:** Events are a crucial part of C# for implementing the observer pattern. You define an event named `OnAction` in the `Notifier` class, which allows other parts of your code to subscribe to and be notified when a particular action occurs.

**Task 2: Understanding the Use of Dynamic and Var Keywords**

- **Var:** The `var` keyword allows for implicit type declaration. When you use `var`, the compiler determines the variable's type based on the assigned value. However, it's resolved at compile time, and once assigned, the variable's type is fixed.

- **Dynamic:** The `dynamic` keyword is used for late binding, allowing you to defer type checking to runtime. It provides flexibility but might lead to runtime errors if not used carefully.

**Task 3: Implementing Anonymous Methods**

- **Anonymous Methods:** Anonymous methods are a way to define methods without a name. In this task, you use an anonymous method as a comparison function for sorting an array using `Array.Sort`. They are particularly useful in scenarios where you need a simple, one-time-use method.

**Task 4: Understanding and Using Lambda Expressions and Statements**

- **Lambda Expressions:** Lambda expressions are a concise way to define inline functions or delegates. You use them in conjunction with LINQ methods like `Where` and `Select` to filter and modify collections.

**Task 5: Advanced Use of Delegates for Sorting (Advanced)**

- **Delegates:** Delegates are utilized to define a flexible mechanism for sorting a list of `Product` objects. You create a custom delegate, `SortDelegate`, and use it to encapsulate sorting methods.

**Task 6: Implementing and Manipulating Records in C# 9.0 and Above (Advanced)**

- **Records (C# 9.0 and Above):** Records are a newer C# feature that provides a concise way to define classes that are primarily used to store data. They come with built-in value equality, deconstruction, and immutability. You demonstrate record creation, equality, and the `with` keyword for creating modified records.

**Task 7: Implementing Advanced Pattern Matching in C# 7.0 and Above**

- **Inheritance:** In this task, you use class inheritance to create a hierarchy of shapes with a base class `Shape` and subclasses like `Circle`, `Rectangle`, and `Triangle`.
- **Pattern Matching:** Pattern matching is a feature introduced in C# 7.0. You use it to match the type of a shape in the `DisplayShapeDetails` method, enabling different behavior for each shape type.

## Task 1: Understanding and Implementing Events and Delegates

### Description

- Create a console application utilizing events and delegates for user notifications.
- Define a delegate, `Notify`, in the `Notifier` class that accepts a string message and returns void.
- Define an event, `OnAction`, in the same class using the `Notify` delegate.
- Subscribe to the `OnAction` event with a method that writes the message to the console.
- Trigger the `OnAction` event with a string message and observe the console output.

### Test Cases

1. When `OnAction` event is triggered with a message, the message should be displayed in the console.

## Task 2: Understanding the Use of Dynamic and Var Keywords

### Description

- Create a console application demonstrating the differences between `var` and `dynamic`.
- Use `var` to declare a variable and assign it a value. Attempt to change the variable's type after declaration and observe the result.
- Use `dynamic` to declare a variable and assign it a value. Attempt to change the variable's type after declaration and observe the result.

### Test Cases

1. Declare a variable using `var`, assign a value, attempt to change its type - Verify that a compile-time error occurs.
2. Declare a variable using `dynamic`, assign a value, attempt to change its type - Verify that it compiles successfully but may result in a runtime error.

## Task 3: Implementing Anonymous Methods

### Description

- Create a console application that uses an anonymous method to sort an array of integers in ascending order.
- Declare an array of integers.
- Use the `Array.Sort` method and provide an anonymous method for comparison.
- Print the sorted array to the console.

### Test Cases

1. Sort an array of integers using an anonymous method and verify that the array is sorted in ascending order.

## Task 4: Understanding and Using Lambda Expressions and Statements

### Description

- Create a console application that uses lambda expressions and statements to filter and modify a collection of data.
- Declare a list of integers.
- Use a lambda expression with the `Where` LINQ method to filter out even numbers.
- Use a lambda statement with the `Select` LINQ method to square the filtered numbers.
- Print the resulting collection to the console.

### Test Cases

1. Filter a list of integers using a lambda expression and verify that even numbers are excluded.
2. Square the filtered numbers using a lambda statement and verify that the result is correct.

## Task 5: Advanced Use of Delegates for Sorting (Advanced)

### Description

- Create a console application that demonstrates the use of delegates for complex sorting operations.
- Create a `Product` class with properties `Name`, `Category`, and `Price`.
- Declare a list of `Product` objects.
- Create a delegate `SortDelegate` that takes two `Product` objects and returns an integer.
- Implement three methods `SortByName`, `SortByCategory`, and `SortByPrice` that are compatible with `SortDelegate`.
- In the Main method, create instances of `SortDelegate` for each sorting method.
- Implement a method `SortAndDisplay` that sorts the list using the provided delegate and prints the sorted list to the console.
- Call `SortAndDisplay` three times with different sorting delegates.

### Test Cases

1. Sort a list of `Product` objects by name and verify the sorted order.
2. Sort a list of `Product` objects by category and verify the sorted order.
3. Sort a list of `Product` objects by price and verify the sorted order.

## Task 6: Implementing and Manipulating Records in C# 9.0 and Above (Advanced)

### Description

- Define a record `Book` with properties `Title`, `Author`, and `ISBN`.
- Declare a few `Book` records and display their details in the console.
- Demonstrate the value equality of records by comparing two `Book` records with the same property values.
- Attempt to change a property of a `Book` record after its declaration and observe the result.
- Use the `with` keyword to create a new `Book` record based on an existing one but with one or more properties changed.
- Implement a method `DisplayBook` that takes a `Book` record and uses deconstruction to print its properties.

### Test Cases

1. Create `Book` records with the same property values and verify that they are considered equal.
2. Attempt to change a property of a `Book` record after declaration and verify that it remains unchanged.
3. Create a new `Book` record based on an existing one using the `with` keyword and verify the differences.
4. Display the properties of a `Book` record using the `DisplayBook` method and verify correct output.

## Task 7: Implementing Advanced Pattern Matching in C# 7.0 and Above

### Description

- Define a base class `Shape` with properties common to all shapes.
- Define subclasses `Circle`, `Rectangle`, and `Triangle`, each with properties specific to that shape.
- Implement a method `CalculateArea` in each subclass to calculate and return the area of the shape.
- In the Main method, declare a list of `Shape` objects.
- Implement a method `DisplayShapeDetails` that uses type patterns in a switch statement to match the shape's type, print its details, and calculate its area.

### Test Cases

1. Declare a list of `Shape` objects containing instances of `Circle`, `Rectangle`, `Triangle`, and null.
2. Call `DisplayShapeDetails` on each shape and verify that the details and area are correctly displayed.
3. Ensure proper handling when the shape is null or doesn't match any known types.

## Conclusion

This documentation report has provided an overview of the assignment, including task descriptions, expected outcomes, and test cases for each task. Following these instructions and test cases will help ensure the successful completion of the assignment and a deeper understanding of advanced C# programming concepts.