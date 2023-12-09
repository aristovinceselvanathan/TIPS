# String Manipulation

## Task 1: Post Formatting

### Description

I have implemented a function named FormatPost(string post) that takes a string of text (a blog post) and formats it.

Steps

1. I have created the FormatPost function with a string parameter.

2. Using the Stringbuilder to replace double line breaks with `<p>` and `</p>` tags and single line breaks with `<br>` tags.

3. Implemented logic to trim any trailing spaces.

## Task 2: Tag Extraction

## Description

I have implemented a function named ExtractTags(string post) that extracts all hash tagged words from the post (words starting with '#').

Steps

1. I have created the ExtractTags function with a string parameter.

2. Implemented logic to find and extract words starting with '#' using string contains.

3. And return a list of the extracted words without the '#'.

## Task 3: Text Searching

### Description

I have implementd a function named SearchPosts(string query) that takes a search query and returns all posts that contain the query.

Steps

1. I have created the SearchPosts function with a string parameter.

2. Implemented logic to search all posts for the given query to search for all query in the files.

3. And return a list of all posts that contain the query.

## Task 4: Advanced Text Analysis

### Description

You are to implement a function named AnalyzeText(string post) that takes in a blog post and returns a dictionary of words and their frequencies. Exclude common stop words (e.g., 'the', 'is', 'at', 'which', 'on') in your analysis

Steps

1. I have created the AnalyzeTextfunction with a string parameter.

2. Implemented logic to split the post into individual words by spaces.

3. Implemented logic to filter out common stop words compares with words in the text file.

4. Implemented logic to count the frequencies by count the number of occurrence using dictionary.

5. And return a dictionary with each word as the key and its frequency as the value.

## Task 5: Text Comparison

### Description

I have created a function named ComparePosts(string post1, string post2) that compares two texts and returns a similarity score based on the number of identical words in both texts.

Steps

1. I have created the ComparePosts function with two string parameters.

2. Implemented logic to compare the two posts using the similarity of the words repeated. And calculate score according to it.

3. And return the calculated similarity score.

## Task 6: Regular Expression Parsing

### Description

I have implemented a function named ParseURLs(string post) that parses a blog post and identifies all URLs.

Steps

1. I have created the ParseURLs function with a string parameter.

2. Implemented logic to identify and extract all URLs from the post using regex.

3. And return a list of the extracted URLs.

## Task 7: Efficient String Concatenation with StringBuilder

### Description

I have implemented a function named ConcatenateTitles(List`<string>` file paths) that takes a list of file paths (each pointing to a blog post file) and concatenates the titles of all the posts into a single string using StringBuilder. Assume that the title of the post is between `</TITLE>`. 

Steps

1. I have created the ConcatenateTitles function with a parameter of type List`<string>`. Each string in the list should be a file path to a blog post file.

2. Initialized a StringBuilder object to add the titles.

3. Use a loop to iterate over the list of file paths. For each file:

- Open the file for reading.

- Read the first line of the file, which is the title of the post.

- Append the title to the StringBuilder object, followed by a newline character.

- Close the file.

4. After the loop, use the ToString method of the StringBuilder object to get the final concatenated string.

5. And return the concatenated string.

## Understanding

### Working with Strings amd Regular Expression

The **string** is a sequence of characters that represents text. It is a reference type and can be manipulated using various methods and properties provided by the .NET framework. For example, you can concatenate two strings using the `+` operator, or you can find the length of a string using the `Length` property.

A **regular expression** (regex) is a pattern that is used to match text. It is a powerful tool for searching, replacing, and validating text. In C#, you can use the `Regex` class to work with regular expressions. The `Regex` class provides methods and properties to work with regular expressions, such as `IsMatch`, `Match`, and `Replace`. 

For instance, you can use a regex pattern to check whether a given string matches that pattern. For example, the regex pattern `"^m.t$"` indicates a three-letter string where:

- `^` indicates the string starts with `m`.
- `.` indicates any one letter or character.
- `$` indicates the string ends with `t`.

## Descriptions of Various Streams Used

## Real-time Use Case

1. **Data validation**: Regular expressions can be used to validate user input data, such as email addresses, phone numbers, and zip codes. For example, you can use a regex pattern to check whether a given string matches that pattern.

2. **Data extraction**: Regular expressions can be used to extract specific data from a text document. For instance, you can use a regex pattern to extract all the email addresses from a given text file.

3. **Log parsing**: Regular expressions can be used to parse log files and extract useful information from them. For example, you can use a regex pattern to extract all the error messages from a log file.

4. **Search and replace**: Regular expressions can be used to search for specific patterns within a text string and replace them with other patterns. For example, you can use a regex pattern to replace all the occurrences of a word in a text file with another word.

5. **Data cleaning**: Regular expressions can be used to clean up data by removing unwanted characters or formatting. For example, you can use a regex pattern to remove all the special characters from a given text file.

## Conclusion

- **String manipulation** is the process of modifying or extracting parts of a string. In C#, strings are immutable, meaning that once a string is created, it cannot be changed. However, you can create new strings by concatenating or replacing parts of the original string. C# provides many built-in methods for string manipulation, such as `Substring`, `Replace`, `Split`, `Trim`, and `ToUpper`/`ToLower`¹.

- **Regular expressions** (regex) are patterns used to match character combinations in strings. They are a powerful tool for searching, validating, and manipulating text. C# provides a `Regex` class in the `System.Text.RegularExpressions` namespace that allows you to work with regular expressions. The `Regex` class provides methods such as `Match`, `Matches`, `Replace`, and `Split` that enable you to search for, replace, and split strings based on regular expressions¹³.
