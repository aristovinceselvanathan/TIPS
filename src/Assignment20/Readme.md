# Advanced LINQ Challenges in C# 

## Overview 

In this assignment, you will be challenged with a series of tasks that will necessitate a deep understanding of LINQ in C#. You will work with a variety of data structures and databases, employing complex LINQ queries to manipulate and retrieve data. Furthermore, you will dive into the performance considerations and the advanced features of LINQ. 

## Task 1: Basic LINQ Queries 

Given a List<Product>, where Product is a class with properties ProductId, ProductName, Price, and Category, write LINQ queries to: 

Filter products under the category "Electronics" with a price greater than $500 and select only ProductName and Price. 

Using the result of the previous query, sort these filtered products in descending order of price. 

Find the average price of these filtered products. 

### Expected Outcome 

A LINQ query that filters and sorts products, and calculates an average, demonstrating your understanding of basic LINQ operations. 

## Task 2: Complex LINQ Queries 

With the same List<Product>, 

Group products by category and count the products in each category. Each group should also have the most expensive product in that category. 

Perform an inner join with a List<Supplier>, where Supplier is a class with properties SupplierId, SupplierName, and ProductId, to match products with their suppliers. 

### Expected Outcome 

LINQ queries that perform complex operations such as grouping and joining, demonstrating your ability to handle complex scenarios with LINQ. 

## Task 3: LINQ to Objects 

Given an array of integers, use LINQ to find the: 

Second highest number in the array. 

All unique pairs of numbers in the array that add up to a specified target. 

### Expected Outcome 

You will demonstrate your understanding of using LINQ to perform operations on in-memory objects such as arrays. 

## Task 4: LINQ to SQL / Entity Framework 

Connect to the provided SQL database and: 

Retrieve all entries from the 'Orders' table where 'OrderDate' is within the last 30 days. The output should be ordered by 'OrderDate' in descending order. 

Update the 'OrderStatus' of all orders placed by a specific customer to 'Completed' and return the count of orders updated. 

### Expected Outcome 

This task will show your ability to work with LINQ to interact with SQL databases. The successful completion of this task means you can handle basic database CRUD operations using LINQ. 

## Task 5: Performance Considerations with LINQ 

Given a List<Product>, write two LINQ queries: 

One that selects all products under the category "Books" and sorts them by price. 

An optimized version of the above query. 

### Expected Outcome 

You will demonstrate your understanding of performance considerations with LINQ. Upon successful completion, you should be able to analyze and optimize LINQ queries. 

## Task 6: Advanced LINQ Features 

Using lambda expressions, write a method that takes a Func<Product, bool> and returns a filtered list of products based on the function. 

Using expression trees, create a dynamic LINQ query that allows the user to specify the property to sort a List<Product> by. 

### Expected Outcome 

This task demonstrates your understanding of advanced LINQ features. The successful completion of this task means you can work with Lambda expressions and expression trees within the context of LINQ.

## Task 7: Query Builder 

Create a query builder utility that allows users to construct complex LINQ queries using a fluent API pattern. This utility should support filtering, sorting, and joining data. Follow the steps below to complete the bonus challenge: 

Explore Fluent API Pattern 

Implement a class called QueryBuilder with the following methods: 

Filter: Accepts a lambda expression that represents a filter condition and adds it to the query. 

SortBy: Accepts a lambda expression that represents the property to sort by and adds it to the query. 

Join: Accepts a lambda expression that represents a join condition and adds it to the query. 

Execute: Executes the constructed LINQ query and returns the result. 

Implement the necessary internal state and data structures in the QueryBuilder class to store the filter, sort, and join conditions. 

Ensure that the Filter, SortBy, and Join methods can be chained together in a fluent manner. For example: 

### Expected Outcome 

The completion of this task will demonstrate your advanced understanding of LINQ and your ability to build a flexible and extensible query builder utility using a fluent API. The utility should allow users to construct complex LINQ queries in a concise and readable manner. 

# Documentation

## Introduction 

LINQ, which stands for Language-Integrated Query, is a powerful feature in the C# programming language that enables developers to query and manipulate data in a more intuitive and seamless manner. Introduced in C# 3.0, LINQ is a paradigm-shifting addition to the language, bridging the gap between traditional programming constructs and data manipulation. It allows developers to express queries in a declarative, SQL-like syntax, and work with a wide range of data sources, including collections, databases, XML, and more.

Key aspects and concepts of LINQ in C# include:

- Declarative Syntax: LINQ introduces a declarative syntax that allows developers to express what they want to do with the data, rather than how to do it. This makes code more expressive and readable.

- Integration with C# Language: Unlike traditional query methods, LINQ is deeply integrated into the C# language. It leverages language features, such as lambda expressions and anonymous types, to create a more seamless experience.

- Standard Query Operators: LINQ provides a set of standard query operators that work across various data sources. These operators include Where, Select, OrderBy, GroupBy, and many more, enabling a consistent way to work with data regardless of the data source.

## Understandings

**1. Standard Query Operators:**

   - `Where`: The `Where` method is used for filtering elements based on a given condition. It returns a sequence of elements that satisfy the specified predicate.

   - `Select`: The `Select` method is used for projecting elements into a new form. It transforms each element in a sequence and returns a new sequence of the transformed elements.

   - `OrderBy` and `OrderByDescending`: These methods are used to sort elements in ascending or descending order based on a key.

   - `GroupBy`: The `GroupBy` method is used for grouping elements by a specified key. It returns a sequence of groups, each containing elements that share the same key.

   - `Join`: The `Join` method is used to combine two sequences based on a common key, similar to SQL JOIN operations.

   - `Aggregate`: The `Aggregate` method performs an aggregation operation on a sequence, such as calculating a sum, product, or a custom aggregation.

   - `Average`, `Sum`, `Min`, `Max`: These methods provide various aggregation functions to calculate the average, sum, minimum, and maximum values in a sequence.

**2. Anonymous Types:**

   - In LINQ, you can create anonymous types to represent the result of a query. These types are created on the fly and are useful for projecting and selecting specific properties from data sources.

   ```csharp
   var queryResult = from product in productList
                     where product.Price > 500
                     select new { product.ProductName, product.Price };
    ```

**3. `IEnumerable<T>` and `IQueryable<T>` Interfaces:**

   - The `IEnumerable<T>` interface represents a collection that can be enumerated. It is suitable for LINQ to Objects, where data is in-memory.

   - The `IQueryable<T>` interface is used for LINQ to SQL or Entity Framework, where data resides in a database. It allows for building queries that are executed against a data store.

**6. `IOrderedQueryable<T>` and `IOrderedEnumerable<T>` Interfaces:**

   - These interfaces represent the result of ordering operations. They enable further query operations while maintaining the ordered sequence.

These built-in methods and classes within LINQ make it a powerful tool for querying and manipulating data in a variety of scenarios, from simple in-memory collections to complex database interactions. Understanding these components is crucial for mastering LINQ and efficiently handling data in C# applications.

## Code Description:

1. **FilteredProducts:**
   - When the user selects this option, the program performs the "FilteredProducts" functionality.
   - It filters products based on specific criteria: products in the "Electronics" category with a price greater than $500.
   - The filtered products are then sorted in descending order of price, and the program calculates and displays the average price of these products.
   - This functionality demonstrates how to filter, sort, and perform aggregations on data using LINQ.

2. **GroupByCategory:**
   - Choosing this option triggers the "GroupByCategory" functionality.
   - It groups the list of products by their respective categories, counting the number of products in each category and identifying the most expensive product in each category.
   - The program displays the results, showing categories, product counts, and the most expensive product in each category.
   - This demonstrates LINQ's grouping and aggregation capabilities.

3. **JoinWithSupplier:**
   - This option initiates the "JoinWithSupplier" functionality.
   - It performs an inner join between the list of products and the list of suppliers based on matching product IDs.
   - The resulting data includes product names and their corresponding supplier names, ordered by supplier name.
   - This functionality showcases how LINQ can be used for joining and combining data from multiple sources.

4. **SecondMaxInTheArray:**
   - Selecting this option activates the "SecondMaxInTheArray" functionality.
   - It generates a random array of integers, and the program finds the second-highest number in the array.
   - The user is also prompted to input a target number, and the program identifies unique pairs of numbers in the array that add up to the specified target.
   - This demonstrates LINQ's capabilities for working with arrays and performing complex numerical operations.

5. **OrdersBefore30Days:**
   - When the user chooses this option, the program executes the "OrdersBefore30Days" functionality.
   - It filters orders that were placed within the last 30 days and displays them in descending order by OrderID.
   - Additionally, the program counts and displays the number of completed orders.
   - This functionality showcases LINQ's date-based filtering and ordering capabilities.

6. **BookCategory:**
   - This option triggers the "BookCategory" functionality.
   - It filters and displays products that belong to the "Books" category, sorting them in descending order by price.
   - This functionality demonstrates how LINQ can be used for category-based filtering and sorting.

7. **UserChoiceQuery:**
   - When the user selects this option, they have the ability to create a custom query for sorting products.
   - The program prompts the user to enter a property for sorting (e.g., ProductPrice, ProductCategory, ProductName) and the desired sorting order (ascending or descending).
   - The selected products are then sorted accordingly and displayed.
   - This functionality showcases LINQ's ability to create dynamic queries based on user input.

8. **DisplayAllList:**
   - Selecting this option displays all lists present in the program, including products, orders, and suppliers.
   - It provides a comprehensive overview of the available data and is useful for debugging and reviewing the data.

9. **JoinUsingQueryBuilder:**
   - The "JoinUsingQueryBuilder" functionality allows users to join products with suppliers using a query builder approach.
   - The program applies filters, sorts, and joins using a dynamic query builder and displays the results.
   - This demonstrates LINQ's capabilities for creating dynamic queries programmatically.

## Conclusion

In conclusion, It showcases a wide range of functionalities and capabilities of LINQ (Language-Integrated Query) in the context of data manipulation and querying. Each functionality, These functionalities cover filtering, grouping, joining, sorting, and more, offering a comprehensive overview of LINQ's power and flexibility.

The program's menu-driven interface allows users to interact with these LINQ operations, making it an educational tool for those looking to learn LINQ or to explore its advanced features. The program's structure and organization provide clarity and ease of use, while comments and method names offer excellent documentation for each functionality.

The program is a testament to the versatility and expressiveness of LINQ in C#, showcasing its ability to work with diverse data sources, perform complex operations, and adapt to dynamic user input. It also demonstrates the use of LINQ to work with both in-memory data structures and external data sources like databases.