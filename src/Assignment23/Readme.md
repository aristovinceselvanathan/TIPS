# Assignment: Building and Using Custom Analyzers in C#

## Objective

To gain a deep understanding of C# analyzers and how they can be used to improve code quality and maintainability.

### Task 1: Understanding the Basics

1.1. Research and understand what analyzers in C# are, their purpose, and how they work. Write a summary of your findings.

1.2. Install a pre-existing analyzer (like StyleCop or FxCop) in a sample C# project. Document any issues found by the analyzer and how they were resolved.

### Task 2: Building a Simple Analyzer

2.1. Create a new analyzer project using the .NET Compiler Platform SDK.

2.2. Write an analyzer that detects if any method in the code has more than 10 lines of code. If it does, the analyzer should raise a warning.

2.3. Test the analyzer on a sample C# project and document the results. Include screenshots of the warnings in the IDE.

### Task 3: Building a More Complex Analyzer

3.1. Create an analyzer that detects if any class in the code violates the Single Responsibility Principle (SRP). This will require a deeper understanding of the SRP and how to detect violations of it in code.

3.2. Test the analyzer on a sample C# project and document the results. Include screenshots of the warnings in the IDE.

### Task 4: Building a Code Fix Provider

4.1. For the analyzer created in Task 3, create a code fix provider that suggests a possible refactoring to resolve the SRP violation.

4.2. Test the code fix provider on a sample C# project and document the results. Include screenshots of the code fix suggestions in the IDE.

### Task 5: Integrating Analyzers into the Development Process

5.1. Research and document how to integrate custom analyzers into the development process, including how to include them in the build process and how to distribute them to other developers.

5.2. Implement the integration of the analyzers created in Tasks 2 and 3 into a sample development process. Document the steps taken and any issues encountered.

Deliverables:

· The analyzers and code fix provider created in Tasks 2, 3, and 4.

· The documentation from Tasks 1, 2, 3, 4, 5

· The sample C# projects were used to test the analyzers and code fix provider.

This assignment should provide a deep, hands-on understanding of C# analyzers and their role in improving code quality and maintainability.

# Project Documentation

## Introduction

In C#, an **analyzer** is a tool that performs static code analysis on source code and reports any issues to the user. It can be used to enforce coding standards, identify potential bugs, and improve code quality. The .NET Compiler Platform SDK provides the tools you need to create custom analyzers, code fixes, code refactoring, and diagnostic suppressors that target C# or Visual Basic code.

## Understandings

In C#, **Roslyn** is a platform that provides APIs for performing **static code analysis** on source code. It allows developers to create custom **analyzers**, **code fixes**, **code refactoring**, and **diagnostic suppressors** that target C# or Visual Basic code.

An **analyzer** is a tool that performs static code analysis on source code and reports any issues to the user. It can be used to enforce coding standards, identify potential bugs, and improve code quality. The rules you implement can be anything from code structure to coding style to naming conventions and more. The .NET Compiler Platform provides the framework for running analysis as developers are writing code, and all the Visual Studio UI features for fixing code: showing squiggles in the editor, populating the Visual Studio Error List, creating the "light bulb" suggestions and showing the rich preview of the suggested fixes.

## Code Description

## Task 1:

- There are two types of analyzers in C#: binary analyzers and source analyzers. Binary analyzers, such as FxCop, analyze compiled code, while source analyzers, such as StyleCop, analyze source code.

- To install a pre-existing analyzer like StyleCop or FxCop in a sample C# project, you can use NuGet packages. Once installed, the analyzer will automatically analyze your code and report any issues it finds. For example, StyleCop can report issues related to code formatting, while FxCop can report issues related to code quality and security.

- Issues found by the analyzer can be resolved by following the recommendations provided by the analyzer. For example, if StyleCop reports an issue related to code formatting, you can modify your code to follow the recommended formatting. Similarly, if FxCop reports an issue related to code quality, you can modify your code to improve its quality.

## Task 2:

- I have created the analyzer by using the Roslyn Analyzer in that SyntaxNodeContextAnalyzer, where the mocked visual studio is given.

- The Code Analyzer consists of two methods <br>

i) Initialize the visual studio instant where the code analysis is done for the program by `context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None)`, `context.EnableConcurrentExecution()`. The context refers to the current context of the visual studio. <br>

ii) Analyze the method that consists of the logic that type casts the instance (node) to MethodDeclarationSyntax. To access the number of lines in the method access the body element in the method and get the count of it. <br>

![Alt text](AnalyzerScreenshots\1-MethodSizeViolated.png)

- In the analyze method it checks for the line in the method exceeds the 10 lines, and it will show warnings.

![Alt text](AnalyzerScreenshots\2-MethodSizeViolationCodeFix.png)

- I have added the code fix to this code that give suggestion to resolve the warning. By removing the extra lines in the code.

## Task 3:

- I have created the analyzer by the use of the Roslyn Analyzer in that SyntaxNodeContextAnalyzer where the mocked visual studio is given.

- The code analyzer consists of two methods <br>

i) Initialize the visual studio instant where the code analysis is done for the program by `context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None)`, `context.EnableConcurrentExecution()`. The context is referred to the current context of the visual studio.<br>

ii) Analyze method that consists of the logic that type cast the instance (node) to ClassDeclarationSyntax. To access the number of the methods in the class. <br>

![Alt text](AnalyzerScreenshots\3-SRPRuleViolation.png)

- In the analyze method it checks for the number of methods in the class exceeds the five methods and it will show warnings.

![Alt text](AnalyzerScreenshots\4-SRPRuleViolationCodeFix.png)

- I have added the code fix to this code that give suggestion to resolve the warning. By moving the remaining method to the another class.

## Task 4:

- I have aRefactored of the code by when the class has more than five methods then the waring will be shown.

- In the code fix then additional methods are added to the array list in the batch of five and added to the newly created class. Any Uneven methods in the list is added the newly created class.

## Task 5:

- I have created the nuget package for the analyzer by building the Roslyn Analyzer of the analyzer project and then added to new console application as a project reference to implement the analysis of the code in the project

- This nuget package added to the local nuget package source and then the installed into the new console application.

![Alt text](AnalyzerScreenshots\5-NugetPackageForTheCodeAnalyzer.png)

- The warnings are shown in the error list window of the new console application by adding the newly created analyzer nuget package.

## Real-Time Example

1. **Code quality**: Roslyn analyzers can be used to enforce coding standards, identify potential bugs, and improve code quality. For example, you can create an analyzer that checks for the use of `var` keyword in your code and suggests using explicit types instead.

2. **Performance optimization**: Roslyn analyzers can also be used to optimize code performance. For example, you can create an analyzer that checks for the use of `string.Concat` method in your code and suggests using `StringBuilder` instead.

3. **Security**: Roslyn analyzers can be used to identify security vulnerabilities in your code. For example, you can create an analyzer that checks for the use of `System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode` method in your code and suggests using `System.Web.HttpUtility.HtmlEncode` instead.

4. **Custom rules**: You can create custom rules that are specific to your project or organization. For example, you can create a rule that checks for the use of `Console.WriteLine` method in your code and suggests using a logging framework instead.

## Conclusion

Roslyn Analyzers is a collection of useful analyzers for C# that can be used to improve code quality and maintainability. The package is available on NuGet Gallery. Roslyn analyzer that added as additional workloads files in the visual studio installer.

1. The package contains a set of 200+ analyzers for C#, powered by Roslyn

2. The package can be installed using the .NET CLI, Package Manager, or Packet CLI 1.

3. It maintains the code readability and implement the concept of the clean code.