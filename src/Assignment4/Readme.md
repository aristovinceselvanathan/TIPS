# Practice Exercise

## Project, Solutions and Build Orders

## Objective

In this hands-on exercise, you will demonstrate your understanding of projects, solutions, and build order in C# development by creating a sample solution with multiple console applications and managing their dependencies and build order.

## Instructions:

1. Use the existing solution named "CSharp_Assignmnets' in Visual Studio.
2. Add the following console applications to the solution:<br>
• Project A: "GreetingsApp"<br>
• Project B: "MathApp"<br>
• Project C: "DisplayApp"<br>
• Project D: "UtilityApp"<br>
3. Set Project B as a dependency for Project A, Project C as a dependency for Project B, and Project D as a dependency for Project C. Ensure that the dependencies are properly defined in the solution.
4. Implement the following functionalities in the console applications:<br>
• Project A (GreetingsApp): Create a program that displays a greeting message.<br>
• Project B (MathApp): Define a class that contains methods to perform mathematical calculations of your choice.<br>
• Project C (DisplayApp): Create a program that utilizes the functionalities from Project B and displays the results.<br>
• Project D (UtilityApp): Implement utility functions or helper classes that can be used by other projects.<br>
5. Build the solution and ensure that the build order is correct to handle the project dependencies.
6. Test the functionalities of the console applications by running them in the following order:<br>
• GreetingsApp (Project A)<br>
• MathApp (Project B)<br>
• DisplayApp (Project C)<br>
7. Create a new console application, Project E, of your choice and add it to the solution. Define any necessary dependencies for Project E within the solution.
8. Modify the build order to ensure that Project E is built after Project C.
9. Build the solution again and verify that the build order has been updated correctly.
10. Take screenshots or provide a description of the solution structure, project dependencies, and build order before and after the modifications.
11. Write a summary report discussing the importance of proper project organization, solution management, and build order in C# development. Reflect on your experience in creating and managing the solution and explain how these practices contribute to the success of a software project.


## Project Documentation Report

### Overview

This project is a C# development project that involves creating a solution with multiple console applications. The solution is designed to demonstrate the importance of proper project dependencies, solution management, and build order in C# development.

### Description of Methods

Addition Method: This method takes the two inputs as integer and returns the integer of addition of two operands.<br>
Subtraction Method: This method takes the two inputs as integer and returns the integer of subtraction of two operands.<br>
Multiplication Method: This method takes the two inputs as integer and returns the integer of multiplication of two operands.<br>
Division Method: This method takes the two inputs as integer and returns the integer of division of two operands.<br>
Get Method: It takes the object of the ProgramB Class to be kept in the reference of the interface InterfaceE.<br>
Display Method: It takes the reference of the interface InterfaceE and then calls the methods of the ProgramB Class to perform the operations.<br>
Null Exception: It checks for the null exception for the string input.<br>
PatternMatch Method: It takes the string input and checks for the pattern match for the string input.<br>

### Project Structure

The solution consists of five console applications: GreetingsApp (Project A), MathApp (Project B), DisplayApp (Project C), UtilityApp (Project D), and Project E (a helper application). 
The project dependencies are defined as follows:

Project A depends on Project B and Project D<br>
Project B depends on Project C and Project E<br>
Project C depends on Project D and Project E<br>
Project D is the utility project that contains helper classes and functions that can be used by other projects<br>
Project E contains an interface class that is used by Project B.

### Functionalities

Each console application has a specific functionality as follows:

• GreetingsApp (Project A): Displays a greeting message to the user.<br>
• MathApp (Project B): Performs basic arithmetic operations on two numbers.<br>
• DisplayApp (Project C): Displays the results of the functionalities of Projects A and B.<br>
• UtilityApp (Project D): Implements utility functions or helper classes that can be used by other projects.<br>
• Project E: It consists of interface class that is used by Project B. It is used to create the dependency injection for Project B.<br>

### Build Order

The build order is defined as follows:

Project D (UtilityApp)<br>
Project E (HelperApp)<br>
Project C (DisplayApp)<br>
Project B (MathApp)<br>
Project A (GreetingsApp)<br>

### Testing

To test the functionalities of the console applications, run them in the following order:

GreetingsApp (Project A)

### Challenges encountered:

The main challenge encountered in this project was to create the dependency injection for Project B. The dependency injection was created by creating the interface class in Project E and then using the interface class in Project B. The interface class was used to create the reference of the class in Project B. The reference of the class in Project B was then used to call the methods of the class in Project B.

### Modifications

The build order was modified to ensure that Project E is built before Project C. The build order was modified by changing the dependencies of Project E. The dependencies of Project E were changed to Project C and Project B. The build order was then updated to ensure that Project E is built before Project C.

### By Aristo Vince
