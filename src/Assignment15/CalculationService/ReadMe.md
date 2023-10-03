# Automated Testing

## Task 1: Setting Up a Test Project Using Xunit 

Set up a new Xunit test project in Visual Studio. Name this project "XunitTestingAssignment". 

Add a new class to the project named "CalculatorTests". This class will hold all your tests for the calculator service. 

In the CalculatorTests class, add a basic test method called "AdditionTest" that tests a hypothetical addition method in a Calculator service. Don't worry about the implementation of the Calculator service yet, we will get to that later. The purpose of this task is to familiarize you with the structure of a test method. 

Expected Outcome: A Xunit test project with a single test method. The test will fail when run since the Calculator service has not been implemented yet. 

## Task 2: Writing the Application to Be Tested 

Create a new Console Application in the same solution as your Xunit project. Name this project "CalculationService". 

In the CalculationService project, create a new class called "Calculator". This class should have methods for addition, subtraction, multiplication, and division, each accepting two integer parameters. 

Also create another class "OrderService". This class should have methods to handle different business scenarios related to orders like placing an order, cancelling an order, updating an order, and getting the order details. 

Expected Outcome: A console application with classes and methods ready to be tested. 

## Task 3: Writing Different Types of Tests 

Write Unit tests for the "Calculator" class. These tests should cover all the methods and various scenarios. For example, for the division method, also test for division by zero. 

Write Integration tests for the "OrderService" class. You might need to use Mocks or Stubs here to mimic the behavior of dependent classes. 

Write Data-Driven tests for the "Calculator" class. Here, the same test should be executed with different sets of data. 

Expected Outcome: A suite of tests covering different types of testing methodologies. All tests should pass, demonstrating the functionality of your application. 

## Task 4: Understanding and Applying Testing Concepts 

Apply the Arrange-Act-Assert (AAA) pattern in your tests. 

Use Test Doubles (Mocks and Stubs) in your tests. 

Use a code coverage tool to understand what parts of your code are not covered by tests and write additional tests to increase coverage. 

Expected Outcome: An improved suite of tests, demonstrating the use of AAA, test doubles, and increased code coverage. 

## Task 5: Using Xunit's Advanced Features 

Implement shared test context in your tests. 

Use Xunit's feature to order your tests. 

Enable parallel test execution in your test project. 

Expected Outcome: A refined suite of tests, demonstrating the use of advanced Xunit features. The tests should execute faster and in the desired order. 

## Task 6: Understanding Assertions in Xunit 

Use different types of assertions provided by Xunit in your tests. For example, Assert.Equal, Assert.NotEqual, Assert.NotNull, Assert.Throws, etc. 

Understand when and how to use these assertions effectively. 

Expected Outcome: More robust and comprehensive tests, demonstrating the use of various assertions. 

# Documentation Report

# Introduction

This documentation report outlines the process and outcomes of setting up an automated testing framework using Xunit, focusing on a hypothetical project named "XunitTestingAssignment." This assignment involves creating a Xunit test project, writing application code to be tested, conducting different types of tests, applying testing concepts, and utilizing Xunit's advanced features. The goal is to establish a robust testing environment and demonstrate proficiency in Xunit testing practices.

## Project Overview

The XunitTestingAssignment project consists of two components: a console application ("CalculationService") and a Xunit test project ("XunitTestingAssignment"). The console application contains two classes: "Calculator" and "OrderService." The "Calculator" class contains methods for addition, subtraction, multiplication, and division, each accepting two integer parameters. The "OrderService" class contains methods to handle different business scenarios related to orders, including placing an order, cancelling an order, updating an order, and getting the order details.

The CalculationService Application has several mathematical calculation like addition, subtraction, multiplication, division and test the every corner case of the methods are covered by the test file by using the fine code coverage. The Code Coverage of the project is about the 50 - 60 present including the main method of the application. By using the theory and passing the inline data to the methods and testing the every methods present in the application. The Test covers the different types of integer and tested for the all test cases are passing. I have created the 20 test case for the CalculationService Application.

The OrderService Application has several methods like placing an order, cancelling an order, updating an order, and getting the order details. The Test covers the different types of functionalities and tested for the all test cases are passing. In the test method created the object for the OrderService and pass the List of the orders into the test method and tested for the all test cases are passing. The Code Coverage of the project is about the 55 - 60 present including the main method of the application. I have created the 11 test case for the OrderService Application.
a
### Calculator Class

The "Calculator" class contains methods for addition, subtraction, multiplication, and division, each accepting two integer parameters. The main method it will ask for the user to enter the two numbers and evaluate the number that user entered. It will process the numbers by the selection of the operation by the user. The numbers validated by the `int.TryParse()` method. If the user entered the string or any other characters it will print the invalid input and ask the user to enter the valid number. The user can enter the number and it will process the number and print the result of the operation.

## OrderService Class

The "OrderService" class contains methods to handle different business scenarios related to orders, including placing an order, cancelling an order, updating an order, and getting the order details. The main method it will ask for the user to enter the order number and evaluate the number that user entered. It will process the numbers by the selection of the operation by the user. The numbers validated by the `int.TryParse()` method and the regex pattern matching. If the user entered the string or any other characters it will print the invalid input and ask the user to enter the valid number. The user can enter the number and it will process the number and print the result of the operation. The table of the orders are printed by the using the `ConsoleTable` package. The user can enter the id of the product and it will process the product and add it to the user ordered list. To cancel the order the it will ask for the user to enter the id of the order and it will remove the product from the list. It will also update to the stock of the user.

## Understandings of the XunitTestingAssignment Project

Throughout the XunitTestingAssignment project, several key understandings were gained related to setting up an automated testing framework, conducting tests, and applying testing concepts. These insights and understandings are summarized below:

1. **Automated Testing Framework Setup**:

   - **Xunit Integration**: The project introduced the setup and integration of Xunit, a popular testing framework in the .NET ecosystem, within Visual Studio.

   - **Project Structure**: Understanding the importance of a well-structured project with separate test and application code components.

   - **Test Class Creation**: Creating test classes within the Xunit test project to organize and manage test methods.

2. **Writing Application Code for Testing**:

   - **Console Application**: Creating a console application ("CalculationService") with multiple classes to be tested, including "Calculator" and "OrderService."

   - **Method Implementation**: Developing methods within the application classes to perform various calculations and handle business scenarios related to orders.

3. **Different Types of Tests**:

   - **Unit Tests**: Writing unit tests for individual methods of the "Calculator" class, ensuring each method functions correctly in isolation.

   - **Integration Tests**: Implementing integration tests for the "OrderService" class, which involved testing the interactions between the class and its dependencies.

   - **Data-Driven Tests**: Understanding the concept of data-driven testing, where the same test is executed with different input data sets to validate the method's behavior under various conditions.

4. **Testing Concepts and Best Practices**:

   - **Arrange-Act-Assert (AAA) Pattern**: Applying the AAA pattern consistently in test methods to ensure clear separation of test setup, execution, and assertion phases.

   - **Test Doubles (Mocks and Stubs)**: Using mocks and stubs effectively in integration tests to simulate the behavior of dependent classes or components.

   - **Code Coverage**: Recognizing the importance of code coverage analysis and employing code coverage tools to identify untested code paths. Writing additional tests to improve code coverage.

5. **Xunit's Advanced Features**:

   - **Shared Test Context**: Implementing shared test context when needed, allowing the sharing of data among test methods within the same test class.

   - **Test Ordering**: Utilizing Xunit's features for ordering tests, ensuring tests are executed in a specified order when required.

   - **Parallel Test Execution**: Enabling parallel test execution to enhance testing efficiency and reduce test execution time.

6. **Assertions in Xunit**:

   - **Assertion Types**: Familiarity with various assertion types provided by Xunit, including `Assert.Equal`, `Assert.NotEqual`, `Assert.NotNull`, and `Assert.Throws`.

   - **Effective Assertion Usage**: Understanding when and how to use assertions effectively to validate expected behaviors, making the test suite more robust and comprehensive.

## Purpose of the XunitTestingAssignment Project

1. Early Detection of Bugs: Automated tests identify issues early in the development cycle, reducing the cost of fixing defects.

2. Consistency: Automated tests ensure that testing is consistent across code changes, eliminating human error.

3. Rapid Feedback: Developers receive immediate feedback on the impact of their code changes, allowing for quick adjustments.

4. Deployment Confidence: Automated tests build confidence in code changes, reducing the risk of deployment failures in production.

5. Documentation: Xunit test results serve as documentation, providing a clear history of code quality and changes over time.

## Conclusion

In conclusion, the XunitTestingAssignment project has successfully achieved its goals of setting up a Xunit-based automated testing framework, writing application code for testing, conducting various types of tests, applying fundamental testing concepts, and utilizing Xunit's advanced features. The project now boasts a robust testing suite that thoroughly evaluates the functionality of the "CalculationService" application, ensuring its reliability and correctness.

This documentation serves as a comprehensive record of the testing process, test outcomes, and adherence to testing best practices. It demonstrates proficiency in Xunit testing methodologies and paves the way for continued testing and quality assurance efforts in the development process.