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
        string result = await Program.ReadTheFile(path);

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
        await Program.WriteTheFile(path, data);

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
        string result = Program.FormatPost(post);

        // Assert
        Assert.Equal("Line 1<p></p>Line 2<p></p>Line 3", result);
    }

    [Fact]
    public void ExtractTags_WithHashtags_ReturnsTags()
    {
        // Arrange
        string post = "This is a #test post with #tags";

        // Act
        var tags = Program.ExtractTags(post);

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
        List<string> result = await Program.SearchForTextAsync(query);

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
        double score = Program.CompareText(post1, post2);

        // Assert
        Assert.Equal(0.44, score, 2); // Adjust the expected score accordingly
    }

    [Fact]
    public void ParseURL_WithURLs_ReturnsListOfURLs()
    {
        // Arrange
        string post = "Visit our website at https://example.com and check https://example2.com";

        // Act
        List<string> result = Program.ParseURL(post);

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
        string result = Program.ConcatenateTitle(filePaths);

        // Assert
        Assert.Equal("Title 1, Title 2, ", result);
    }

}
