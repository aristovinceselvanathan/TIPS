# MS Build with Simple Calculator App

C# projects use three important files for configuration and build: .csproj, .props, and .targets. Here's a brief overview of each file:

## .csproj

The .csproj file is the main project file for a C# project. It contains information about the project's files, references, and build settings. Here are some of the key elements of a .csproj file:

**ItemGroup**: This element groups related items together, such as source files, references, and content files.<br>

**Compile**: This element specifies C# source files to include in the project.<br>

**Reference**: This element specifies .NET assemblies to reference in the project.<br>

**PropertyGroup**: This element contains project-level properties, such as the target framework and output type.<br>

**Target**: This element specifies build targets to run during the build process.

## .props

The .props file is an MSBuild file that contains project-level properties and targets that can be shared across multiple projects. Here are some of the key elements of a .props file:

**PropertyGroup**: This element contains project-level properties that can be shared across multiple projects.<br>

**Target**: This element specifies build targets that can be shared across multiple projects.

## .targets

The .targets file is an MSBuild file that contains build targets that can be shared across multiple projects. Here are some of the key elements of a .targets file:

**Target**: This element specifies build targets that can be shared across multiple projects.<br>

**ItemGroup**: This element groups related items together, such as source files, references, and content files.

## Tasks

Tasks are defined in MSBuild using the <Task> element, which specifies the name of the task, the assembly that contains the task implementation, and any parameters that the task requires.

Tasks can be executed in a variety of ways, including:

- As part of a build target: Tasks can be included in a build target using the <Task> element. When the target is executed, the task is executed as well.
- As a standalone task: Tasks can be executed directly from the command line using the msbuild.exe tool. This is useful for testing and debugging tasks.
- As part of a custom build task: Tasks can be combined with other tasks to create custom build tasks that perform complex actions.

## Step by Step Instructions

1. Open the project's .csproj file in a text editor or an IDE like Visual Studio Code.
2. Review the project's configuration settings in the <PropertyGroup> element. This includes the target framework, output type, and other project-level properties.
3. Review the project's file references and build targets in the <ItemGroup> element. This includes source files, references, and content files.
4. If necessary, create or modify a .props file to define project-level properties that can be shared across multiple projects.
5. If necessary, create or modify a .targets file to define build targets that can be shared across multiple projects.
6. Open a command prompt or terminal window and navigate to the project's directory.
7. Run the msbuild command with the path to the project's .csproj file as the argument. This will build the project using the default build target.
8. Review the build output in the console window to ensure that the build was successful and that any errors or warnings are addressed