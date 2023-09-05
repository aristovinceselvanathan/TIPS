# Memory Optimization in C#: A Practical Assignment

## Introduction

In this assignment, we'll explore memory management in C#, a critical aspect of any high-
performance application- We'll learn how to detect, diagnose, and resolve memory issues in a C#
codebase. We'll also discuss best practices for memory management and use tools for memory
profiling.Upon completing this assignment, you'll have a deeper understanding of how to optimize
the pertbrmance of your C# applications by managing memory more effectively<br>

## Task 1: Detecting and Diagnosing Memory Issues

**Objective**: To identify and diagnose memory issues in a program.Code Snippet with Memory <br>
**Issue**: <br>

``` csharp
public class MemoryEater
{
    List<int[]> memAll0c = new List<int[]>;
    public void Allocate()
    {
        while (true)
        {
            memAll0c.Add(new int[1000]);
            // Assume memA110c variable is used only within this loop.
            Thread.Sleep(10);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        MemoryEater me = new MemoryEater();
        me. Allocate();
    }
}
```

### Steps

1. Analyze the above code snippet. Can you identify the memory issue here?
2. Use a memory profiler tool to diagnose the problem in the code. You can use tools like
Visual Studio's built-in Diagnostic Tools <br>
**Expected Outcome**: Identitication and diagnosis of the memory issue in the provided code snippet.

## Task 2: Implementing Memory Management Best

**Objective**: To fix the memory issue in the provided code snippet and implement memory management best practices.

### Steps

1. Based on your diagnosis, fix the memory issue in the provided code snippet.
2. Implement other best practices for memory management in C#. enmis might include practices such as (All the below point may not necessary apply to the given problem):

- Minimizing allocations in performance-critical code paths
- Using using statements or finally blocks to ensure resources are cleaned up properly
- Avoiding large object heap allocations when possible

**Expected Outcome:** The optimized code with memory management best practices implemented.

## Task 3: Memory Profiling

Objective: To understand and demonstrate the use of the memory profiling tool in VS for C#.

### Steps

1. Use the same memory profiler tool as in Task 2 (or choose another if you prefG-) to profile the memory usage of the optimized code from Task 3.
2. Document the changes in memory usage before and alter your optimizations. Can you explain why these changes occurred based on your understanding of memory management in C#?<br>
**Expected Outcome**: A comparison of memory usage bef6re and after optimization. A clear understanding of how memory profiling tools in VS can help optimize code.

## Documentation Report:

### Description

1. A code snippet with a memory issue is rectified by using the list in the local reference so that the list will be out of scope once the method is executed.
2. So that the memory will be freed up. Also, memory is freed up by using the clear method. The memory profiling is done using Visual Studio's built-in diagnostic tools. The memory usage is compared before and after the optimisation.
3. The memory usage is reduced after the optimization. The memory profiling tools in VS can help optimise code by showing the memory usage of the code. So that we can optimise the code by reducing the memory usage.

### Chanllenges Faced:

1. The main challenge faced is to find the memory issue in the code by using the memory profiling tools.
2. The memory profiling tools in VS can help optimise code by showing the memory usage of the code. So that we can optimise the code by reducing the memory usage.
3. Explore how memory management works in C#.

### Takeaways:
1. The memory profiling tools help in finding the memory usage of the code.
2. The memory management in C# is very important to optimise the code.



