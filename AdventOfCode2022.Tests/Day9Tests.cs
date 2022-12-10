using Day9;

namespace AdventOfCode2022.Tests;

public class Day9Tests
{
    public Day9Tests()
    {

    }

    [Fact]
    public void ConfirmSolutionOneWorks()
    {
        var solution = new Solution();
        solution.ReadInput("day9TestInput.txt");
        var count = solution.ModelRope(2);
        Assert.Equal(13, count);
    }

    [Fact]
    public void ConfirmSolutionTwoWorks()
    {
        var solution = new Solution();
        solution.ReadInput("day9TestInput2.txt");
        var count = solution.ModelRope(10);
        Assert.Equal(36, count);
    }
}