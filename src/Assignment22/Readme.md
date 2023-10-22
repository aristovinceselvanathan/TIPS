# Exploring NuGet Packages: Use, Creation, and Management 

## Objective 

To enhance the understanding of NuGet packages, from usage and creation to management with a custom NuGet server. 

## Part 1: Creating NuGet Packages 

### Task 1.1: Create a Class Library Project 

Start a new .NET Standard class library project. Name it MyMathLibrary. 

Implement a method named CalculateFibonacci in this library. The method should accept an integer 'n' and return a list of the first 'n' numbers in the Fibonacci series. 

Add a reference to the NuGet package MathNet.Numerics. This library will help us validate our Fibonacci series generation logic. 

Note: When you add a reference to an existing NuGet package in your project, you're creating a dependency. This dependency, along with its version, should be reflected in your .nuspec file in the `<dependencies>` tag. This way, when someone installs your NuGet package, the dependencies will be installed automatically. This approach makes it easier to handle nested dependencies and ensures that your package works as expected in other projects.  

Use the Generate.OddFibonacciNumbers() method from the MathNet.Numerics package inside your CalculateFibonacci method to generate the Fibonacci series. 

Ensure your method handles exceptions and edge cases, like negative numbers and non-integer input. 

### Task 1.2: Create a .nuspec file 

Add a .nuspec file to your project to define the properties of the package. 

Populate the mandatory tags: `<id>, <version>, <authors>, <owners>,` and `<description>`. 

Include the following advanced tags: 

`<dependencies>`: Define the dependencies of your NuGet package. It's crucial to include this tag to ensure that anyone who installs your NuGet package also installs its dependencies. In this case, add the dependency from Task 1.1 

`<files>`: Define the files that you want to include in the package. This tag allows you to explicitly choose which files to include in the package and where to place them in the package. 

`<releaseNotes>`: Include any important notes about the current release of the package. This is helpful for users to understand the changes in the current version.

`<icon>` and `<iconUrl>`: Add an icon to your package. Note that starting with NuGet 5.3 and Visual Studio 2019 version 16.3, pack task attempts to extract icon image from the package. If extraction fails, pack task will fall back to using `<iconUrl>`. 

`<frameworkAssemblies>`: Specify any .NET Framework assemblies that are required by the package. This is required when your library is built against the .NET Framework and it depends on an assembly that isn't automatically referenced by MSBuild. 

`<frameworkAssemblies>`: Specify any .NET Framework assemblies that are required by the package. This is required when your library is built against the .NET Framework and it depends on an assembly that isn't automatically referenced by MSBuild. 

`<tags>`: Specify the tags that apply to the package. This helps users discover your package through NuGet search. 

With these advanced tags, you can tailor your .nuspec file to better suit the needs of your NuGet package and make it more user-friendly. 

### Task 1.3: Pack the library 

Use the dotnet pack command to package the library into a .nupkg file. 

Open the .nupkg file with the NuGet Package Explorer and explain what you see. 

## Part 2: Using NuGet Packages 

### Task 2.1: Create a new application 

Start a new .NET Core console application, MyConsoleApplication. 

Add a reference to the NuGet package you created in Part 1. The dependency of your NuGet Package should also be installed automatically. 

Use the method you created in the class library in this console application. 

### Task 2.2: Document the process 

Write a brief step-by-step guide on how you added the NuGet package reference to the application. 

Discuss any challenges you encountered during this process and explain how you solved them. 

## Part 3: Publishing to a Custom NuGet Server 

### Task 3.1: Set up BaGet 

Install and configure BaGet on your local machine. 

Set up a NuGet API key in BaGet for publishing packages. 

### Task 3.2: Publish the package 

Use the dotnet nuget push command to publish the .nupkg file from Part 1 to your BaGet server. 

Check the BaGet web interface to validate that your package was successfully published. 

### Task 3.3: Document the steps 

Write a detailed guide on how you set up and configured BaGet. 

Discuss any challenges you encountered and how you solved them.

# Documentation Report: NuGet Packages - Usage, Creation, and Management

## Introduction

This documentation report provides a comprehensive guide to understanding and working with NuGet packages, including creating, using, and managing them. The objective is to enhance your knowledge of NuGet packages and their lifecycle. This report covers three main parts: creating NuGet packages, using them in applications, and publishing to a custom NuGet server. It includes step-by-step instructions, best practices, and tips for successful package management.

## Understandings

In the process of exploring NuGet packages, you gain several important understandings and insights:

1. **NuGet Package Creation**: You learn how to create NuGet packages for your own libraries and code components. This involves defining metadata, specifying dependencies, and organizing package content.

2. **Dependency Management**: By adding references to existing NuGet packages like "MathNet.Numerics," you understand how NuGet simplifies dependency management. NuGet automatically fetches and installs the required dependencies, ensuring that your project works seamlessly.

3. **Metadata and Documentation**: Creating a .nuspec file helps you appreciate the importance of metadata and documentation in NuGet packages. Properly defining metadata ensures discoverability, while clear documentation aids users in understanding package functionality.

4. **Versioning and Publishing**: You gain insights into versioning NuGet packages and publishing them to a custom NuGet server. Versioning helps users understand updates and changes in your package, and publishing makes your package available for others to use.

6. **NuGet Package Manager**: In the context of using NuGet packages, you become familiar with the NuGet Package Manager. This tool simplifies the process of adding, updating, and managing packages in your projects.

7. **Package Reference**: You learn how to reference and consume NuGet packages in your projects. Understanding this process is crucial for reusing code and accelerating development.

8. **Package Conflicts**: You may encounter challenges related to package conflicts or version mismatches. These challenges deepen your understanding of NuGet's version resolution and conflict resolution mechanisms.

9. **Local NuGet Server**: By setting up and configuring a local NuGet server (such as BaGet), you gain insight into hosting and distributing packages within your organization. This can enhance code sharing and collaboration among team members.

10. **API Key Usage**: The use of an API key to secure package uploads emphasizes the importance of security and access control when publishing packages.

11. **Documentation and Communication**: Throughout the process, you appreciate the value of documenting your work. Clear and comprehensive documentation helps team members understand and replicate the processes you've followed.

## Code Description

Certainly! Below, I'll provide a brief code description for key components of the tasks mentioned in the original document related to NuGet packages. This description will help you understand the code and its purpose.

**Task 1.1: Create a Class Library Project**

- In this task, I have created a .NET Standard class library project named "MyMathLibrary" and implemented a method named `CalculateFibonacci` in this library, which calculates the Fibonacci sequence. This code can serve as the core functionality of your NuGet package.

- It uses the MathNet.Numerics NuGet package to generate the Fibonacci series and I have used the Take method to take the first n numbers from the Fibonacci series.

- I have used select LINQ method to convert to the int and then converted the result to a list.

```csharp
namespace MyMathLibrary
{
    using MathNet.Numerics;

    /// <summary>
    /// Program Class Library
    /// </summary>
    public class Program
    {
        /// <summary>
        /// To Calculate the Fibonacci Series from the given number
        /// </summary>
        /// <param name="fibonacciNumber">The number of Fibonacci series to be returned</param>
        /// <returns>List of the Fibonacci series</returns>
        public static List<int> CalculateFibonacci(int fibonacciNumber)
        {
            return Generate.FibonacciSequence().Take(fibonacciNumber).Select(number => (int)number).ToList();
        }
    }
}
```

**Task 1.2: Create a .nuspec file**

In this task, I have created a .nuspec file that defines the metadata and properties of your NuGet package. This file is essential for packaging and distributing your library. It also describes about the version, description, owners, authors, tags, release notes, dependencies, and files. It used for the package creation and Package distribution.

```xml
<?xml version="1.0" encoding="utf-8"?>
<package>
	<metadata>
		<id>2400234</id>
		<version>1.1.0</version>
		<description>MyMathLibrary is math metrics library to used to generate the fibonacci series.</description>
		<owners>Aristo Vince</owners>
		<authors>Aristo Vince</authors>
		<tags>Fibonacci Series Generator</tags>
		<releaseNotes>Added edge case checking for fibonacci series</releaseNotes>
		<dependencies>
			<dependency id="MathNet.Numerics" version="5.0.0" />
		</dependencies>
	</metadata>
	<files>
		<file src="./bin/Debug/net6.0/MyMathLibrary.dll" target="./lib"/>
	</files>
</package>
```

**Task 1.3: Pack the library**

- In this task,I have packed the class library into a .nupkg file using the `nuget pack` command. The resulting .nupkg file contains your library, metadata, and dependencies.

- Before this need to install NuGet Windows x86 Commandline to use the nuget command.

``` bash
nuget pack MyMathLibrary.csproj
```

**Task 2.1: Create a new application**

- Here, I have created a .NET Core console application named "MyConsoleApplication" and add a reference of created NuGet package to the application. This nuget package consist of the CalculateFibonacci method which is used to generate the fibonacci series.

- Joined all the array elements using the string.Join method and displayed the result in the console. I have limited upto 47 numbers in the fibonacci series because of the int data type limitation.

```csharp
namespace MyConsoleApplication
{
    using MyMathLibrary;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// To generate the fibonacci series
        /// </summary>
        /// <param name="args">String array in the parameters of the main method</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fibonacci Series Generator\n");
            Console.Write("Enter the number of the Fibonacci series to be generated : ");
            if (int.TryParse(Console.ReadLine(), out int result) && result > 0 && result <= 47)
            {
                Console.WriteLine("Array is [{0}]", string.Join(",", MyMathLibrary.Program.CalculateFibonacci(result).ToArray()));
            }
            else
            {
                Console.WriteLine("Invalid number - Please enter number between 1 to 47");
            }
        }
    }
}
```

**Task 3.1: Set up BaGet**

- In this task, I have installed the baget server from the github [Baget Repo](https://github.com/loic-sharma/BaGet). 
- I have set the ApiKey in the appsettings.json file and used the same key to publish the nuget package to the server.
- I have extract the zip file and run the command `dotnet BaGet.dll` to start the server. I have used the default port 5000 to run the server.
```bash
start http://localhost:5000/
```

**Task 3.2: Publish the package**

To publish the NuGet package to your custom NuGet server, you use the `dotnet nuget push` command, providing the package file, source, and API key as parameters.

```bash
dotnet nuget push -s http://10ca1host:5000/v3/index.json package.nupkg
```
![Baget Publish](BagetPublish.png)

## 5. Conclusion

This documentation report has provided a comprehensive guide to working with NuGet packages, from creation to usage and management. By following the steps outlined in this report, you can create, use, and distribute NuGet packages with confidence, facilitating code reuse, and efficient package management. Whether you are a package creator or a package user, understanding these processes is essential for successful .NET development.