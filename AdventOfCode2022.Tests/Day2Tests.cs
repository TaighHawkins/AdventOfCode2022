namespace AdventOfCode2022.Tests;
using Day2;

public class Day2Tests
{
    private readonly Solution _solution;
    public Day2Tests()
    {
        _solution = new Solution();
        _solution.ReadInput("day2TestInput.txt");
    }
    
    [Fact]
    public void TestSolutionOneWorks()
    {
        int score = _solution.GetStrategyScore();
        Assert.Equal(15, score);
    }
    
    [Fact]
    public void TestSolutionTwoWorks()
    {
        int score = _solution.GetStrategyScoreBasedOnOutcome();
        Assert.Equal(12, score);
    }
}