namespace BusShuttle.Tests;

using BusShuttle;

public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;

    public FileSaverTests()
    {
        testFileName = "test-doc.txt";
        fileSaver = new FileSaver(testFileName);
    }

    [Fact]
    public void Test_FileSaver_Append()
    {
        // Act
        fileSaver.AppendLine("Hello, World!");
        
        // Assert
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Hello, World!" + Environment.NewLine, contentFromFile);
    }
}
