using Day8;

namespace AdventOfCode2022.Tests;

public class Day8Tests
{
    private Solution _solution;

    public Day8Tests()
    {
        _solution = new();
        _solution.ReadInput("day8TestInput.txt");
    }

    [Fact]
    public void SolutionOneWorks()
    {
        int count = _solution.CountVisibleTreesFromTheOutside();
        Assert.Equal(21, count);
    }

    [Fact]
    public void SolutionTwoWorks()
    {
        int scenicScore = _solution.GetMostScenicTree();
        Assert.Equal(8, scenicScore);
    }
}