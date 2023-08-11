# Practical Exercise
Create a new C# console application project in your preferred development environment.

Implement a class called "MathUtils" with the following methods:
1. **Add:** Takes two integer parameters and returns their sum.
2. **Subtract:** Takes two integer parameters and returns their difference.
3. **Multiply:** Takes two integer parameters and returns their product.
4. **Divide:** Takes two integer parameters and returns their quotient.

Implement the main program logic in the console application:
1. Prompt the user to enter two integers.
2. Call the methods from the MathUtils class to perform addition, subtraction,
multiplication, and division.
3. Display the results to the user.
4. Build and run your application to ensure it functions as expected.

# Documentation Report
## Introduction
This is the C# console application. This is used to perform the basic arithmatic operaions like addition, subtraction, multiplication, division.
This program prompts the user to enter the two input for operands to perform arithmatic operation. This program continuosly prompts the user to enter the numbers to be evaluated.

## Description of Methods
Addition Method: This method takes the two inputs as integer and returns the integer of addition of two operands.<br>
Subtraction Method: This method takes the two inputs as integer and returns the integer of subtraction of two operands.<br>
Multiplication Method: This method takes the two inputs as integer and returns the integer of multiplication of two operands.<br>
Division Method: This method takes the two inputs as integer and returns the integer of division of two operands.<br>

## Approach
To create this program, I followed these steps:

Created a new C# console application project in Visual Studio with stater template.Added a new class called “MathUtils” with methods for additon, subtraction, multiplication, and division.Implented the main program logic by the continuosly prompt the user to enter the numbers to be evaluated by the program. The main program has the options to choose the addition, subtraction, multiplication, division. It will display the result.
## Concepts applied
The following programming concepts were used in this program:
**Classes:** The MathUtils class was created to encapsulate the arithmetic operators.<br>
**Methods:** The MathUtils class contains methods such as addition, subtraction, multiplication, and division.<br>
**Variables:** The program uses variables to store the user input and to print the results of arithmetic operations.
## Challenges encountered
I encountered some challenges while working on this program:
- Converting the string to integer: I had used the Convert class method ToInt32 to covert the string to integer.
- Handle the Zero Division Error : I had to make implicitly cast the integer to float. So that it will show infinity.
- Standardization errors: I take care about the proper indentation and white spaces in the program.