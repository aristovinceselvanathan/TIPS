using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Assignment19;

public class StringManipulationTestClass
{
    Program program = new Program();
    [Fact]
    public async Task ReadTheFileAsync_ValidPath_ReturnsFileContent()
    {
        // Arrange
        string path = "test.txt";
        string content = "Test file content";
        await File.WriteAllTextAsync(path, content);

        // Act
        string result = await Assignment19.FileOperations.ReadTheFile(path);

        // Assert
        Assert.Equal(content, result);
    }

    [Fact]
    public async Task WriteTheFileAsync_ValidPath_WritesDataToFile()
    {
        // Arrange
        string path = "test.txt";
        string data = "Test data";

        // Act
        await Assignment19.FileOperations.WriteTheFile(path, data);

        // Assert
        string result = await File.ReadAllTextAsync(path);
        Assert.Equal(data, result);
    }

    [Fact]
    public void FormatPost_WithNewlines_ReplacesWithTags()
    {
        // Arrange
        string post = "Line 1\nLine 2\nLine 3";

        // Act
        string result = Assignment19.Utility.FormatPost(post);

        // Assert
        Assert.Equal("Line 1<br>Line 2<br>Line 3", result);
    }

    [Fact]
    public void ExtractTags_WithHashtags_ReturnsTags()
    {
        // Arrange
        string post = "This is a #test post with #tags";

        // Act
        var tags = Assignment19.Utility.ExtractTags(post);

        // Assert
        Assert.Contains("#test", tags);
        Assert.Contains("#tags", tags);
    }
    [Fact]
    public async Task SearchForTextAsync_WithMatchingQuery_ReturnsMatchingFiles()
    {
        // Arrange
        string query = "hello";

        // Act
        List<string> result = await Assignment19.Utility.SearchForTheQueryInFiles(query);

        // Assert
        Assert.Contains("SW\\0.txt", result);
    }

    [Fact]
    public void CompareText_WithMatchingText_ReturnsScore()
    {
        // Arrange
        string post1 = "This is a sample text";
        string post2 = "This is a sample";

        // Act
        double score = Assignment19.Utility.CompareText(post1, post2);

        // Assert
        Assert.Equal(44.44, score, 2); // Adjust the expected score accordingly
    }

    [Fact]
    public void ParseURL_WithURLs_ReturnsListOfURLs()
    {
        // Arrange
        string post = "Visit our website at https://example.com and check https://example2.com";

        // Act
        List<string> result = Assignment19.Utility.ParseURL(post);

        // Assert
        Assert.Contains("https://example.com", result);
        Assert.Contains("https://example2.com", result);
    }

    [Fact]
    public async Task ConcatenateTitle_WithTitles_ReturnsConcatenatedTitlesAsync()
    {
        // Arrange
        List<string> filePaths = new List<string> { "file1.txt", "file2.txt" };
        string file1Content = "<title>Title 1</title>";
        string file2Content = "<TITLE>Title 2</TITLE>";
        await File.WriteAllTextAsync(filePaths[0], file1Content);
        await File.WriteAllTextAsync(filePaths[1], file2Content);

        // Act
        string result = Assignment19.Utility.ConcatenateTitle(filePaths);

        // Assert
        Assert.Equal("Title 1,\nTitle 2,\n", result);
    }

}
