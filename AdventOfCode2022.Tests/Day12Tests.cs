using Day12;

namespace AdventOfCode2022.Tests;

public class Day12Tests
{
    [Fact]
    public void ConfirmSolutionOneWorks()
    {
        var solution = new Solution();
        solution.ReadInput("day12TestInput.txt");
        Assert.Equal(31, solution.SearchGrid(new [] { 0, 0 }));
    }

    [Fact]
    public void ConfirmSolutionTwoWorks()
    {
        var solution = new Solution();
        solution.ReadInput("day12TestInput.txt");
        Assert.Equal(29, solution.SearchGridFromAllStartPoints());
    }
}