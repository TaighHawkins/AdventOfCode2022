using Day5;

namespace AdventOfCode2022.Tests;

public class Day5Tests
{
    private readonly Solution _solution;
    public Day5Tests()
    {
        _solution = new();
        _solution.ReadInput("day5TestInput.txt");
    }

    [Fact]
    public void TestSolutionOneWorks()
    {
        Assert.Equal("CMZ", _solution.CompleteInstructionsAndReadTopCrates(_solution.InitialiseCrateMover9000()));
    }

    [Fact]
    public void TestSolutionTwoWorks()
    {
        Assert.Equal("MCD", _solution.CompleteInstructionsAndReadTopCrates(_solution.InitialiseCrateMover9001()));
    }
}