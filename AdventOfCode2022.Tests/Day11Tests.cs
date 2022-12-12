using Day11;

namespace AdventOfCode2022.Tests;

public class Day11Tests
{
    [Fact]
    public void ConfirmSolutionOneWorks()
    {
        var solution = new Solution();
        solution.ReadInput("day11TestInput.txt");
        Assert.Equal((long)10605, solution.CalculateMonkeyBusinessAfterRounds(20, 3, 0));
    }

    [Fact]
    public void ConfirmSolutionTwoWorks()
    {
        var solution = new Solution();
        solution.ReadInput("day11TestInput.txt");
        Assert.Equal((long)2713310158,
            solution.CalculateMonkeyBusinessAfterRounds(10_000, 0, solution.CalculateCommonDivisor()));
    }
}