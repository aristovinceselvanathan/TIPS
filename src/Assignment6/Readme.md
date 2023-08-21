# Object-oriented Programming
In this Exercise, you will demonstrate your practical skills in Object-Oriented Programming (OOP). You will be required to implement code solutions that apply various OOP concepts. Read each task carefully and provide your code solution accordingly.
## Task 1: Shape Hierarchy
1. Create a class called "Shape" with the following properties and methods:<br>
Properties: 
* Colour (string): Represents the colour of the shape.<br>
Methods:
* CalculateArea(): Calculates and returns the area of the shape (abstract method).
* PrintDetails(): Displays the colour and area of the shape.<br>
2. Create two derived classes from the Shape class: "Rectangle" and "Circle". <br>
o Implement the CalculateArea() method in each derived class to calculate the area of the corresponding shape.<br>
o Implement the PrintDetaiIs() method in each derived class to display the colour, shape type, and area.<br>
## Task 2: Employee Hierarchy
1. Create a base class called "Employee" with the following properties and methods:<br>
Properties:
* Name (string): Represents the name of the employee.
* Salary (decimal): Represents the salary of the employee.<br>
Methods:
* CalculateBonus(): Calculates and returns the bonus amount for the employee
(abstract method).
* PrintDetails(): Displays the name, salary, and bonus amount of the employee.
2. Create two derived classes from the Employee class: "Manager" and "Developer".
* Implement the CalculateBonus() method in each derived class to calculate the bonus amount based on their specific rules.
*  Implement the PrintDetaiIs() method in each derived class to display the name, position, salary, and bonus amount.
## Task 3: Banking System
1. Create a class called " BankAccount'i with the following properties and methods:<br>
Properties:
* AccountNumber (string): Represents the account number.
* Balance (decimal): Represents the account balance.
Methods:
* Deposit(amount): Deposits the specified amount into the account.
* Withdraw(amount): Withdraws the specified amount from the account.
2. Create a derived class called "SavingsAccount" from the BankAccount class.
* Implement the Withdraw() method in the SavingsAccount class to restrict withdrawals if the account balance falls below a certain minimum balance.
* Create a derived class called "CheckingAccount" from the BankAccount class.
* Implement the Withdraw() method in the CheckingAccount class to allow withdrawals without any restrictions.

# Documentation Report
## Introduction
This is the C# console application. This is used to perform the object oriented programming. This program creates the different class for each of the task. Each class has the different methods and properties. This uses the abstract class, virtual method, override the method.
## Description of Methods
The methods in the class are described as the parent class and then it is inherited by the child class and override the method. The method is used to calculate the area of the shape, calculate the bonus amount, deposit the amount, withdraw the amount.

## Approach
To create this program, I followed these steps:

Created a new C# console application project in Visual Studio with stater template. Added a new class called “Shape hierarchy” with methods of CalculateArea and PrintDetails. Created a new class called “Rectangle” and “Circle” which inherits the Shape class. Override the CalculateArea and PrintDetails methods in the Rectangle and Circle class. Created a new class called “Employee hierarchy” with methods of CalculateBonus and PrintDetails. Created a new class called “Manager” and “Developer” which inherits the Employee class. Override the CalculateBonus and PrintDetails methods in the Manager and Developer class. Created a new class called “BankAccount” with methods of Deposit and Withdraw. Created a new class called “SavingsAccount” and “CheckingAccount” which inherits the BankAccount class. Override the Withdraw methods in the SavingsAccount and CheckingAccount class.
## Concepts applied
The following programming concepts were used in this program:
**Inheritance** The parent class are inherited by the child class can able to uses the parent methods within the access specifier.<br>
**Methods:** The Class uses the methods to perform the different operations.<br>
**Abstract class** The abstract class is used to create the abstract methods. The abstract methods are used to override the methods in the child class.<br>
**Override** The override is used to override the methods in the child class.<br>
**Virtual** The virtual is used to override the methods in the child class.<br>

### By Aristo Vince
