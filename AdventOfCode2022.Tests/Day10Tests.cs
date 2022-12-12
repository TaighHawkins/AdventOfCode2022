using Day10;

namespace AdventOfCode2022.Tests;

public class Day10Tests
{
    private readonly Solution _solution;

    public Day10Tests()
    {
        _solution = new();
        _solution.ReadInput("day10TestInput.txt");
    }

    [Fact]
    public void ConfirmSolutionOneWorks()
    {
        Assert.Equal(13140, _solution.GetSignalStrengthsAndCalculateStrength());
    }

    [Fact]
    public void ConfirmSolutionTwoWorks()
    {
        Assert.Equal(@"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....", _solution.RenderCrtDisplay());
    }
}