using Day7.Parser;

namespace AdventOfCode2022.Tests;
using Day7;

public class Day7Tests
{
    private readonly Solution _solution;
    
    public Day7Tests()
    {
        _solution = new();
        _solution.ReadInput("day7TestInput.txt");
    }

    [Fact]
    public void ConfirmTestResults()
    {
        var parser = new DirectoryParser(
            File.ReadAllText("day7TestInput.txt")
                .Replace("\r\n", "\n")
                .Split("\n"));
        parser.ParseInput();
        var dict = parser.GetDirectorySizes();
        
        Assert.True(dict["/a/e"] == 584);
        Assert.True(dict["/a"] == 94853);
        Assert.True(dict["/d"] == 24933642);
        Assert.True(dict["/"] == 48381165);
    }

    [Fact]
    public void ConfirmSolutionOneWorks()
    {
        int size = _solution.GetLargestSmallDirectories();
        Assert.Equal(95437, size);
    }

    [Fact]
    public void ConfirmSolutionTwoWorks()
    {
        int smallestTarget = _solution.FindSmallestDirectoryAboveRequiredSpace();
        Assert.Equal(24933642, smallestTarget);
    }
}