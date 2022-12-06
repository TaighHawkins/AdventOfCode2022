using Day1;

namespace AdventOfCode2022.Tests;

public class Day1Tests
{
    private readonly Solution _solution;
    public Day1Tests()
    {
        _solution = new Solution();
        _solution.ReadInput("day1TestInput.txt");
    }
    
    [Fact]
    public void TestSolutionOneWorks()
    {
        Elf? elf = _solution.GetMostCalorificElf();
        Assert.Equal(24000, elf.CalorificValue);
    }
    
    [Fact]
    public void TestSolutionTwoWorks()
    {
        List<Elf> elves = _solution.GetTopThreeMostCalorificElves();
        Assert.True(elves.Count == 3);
        Assert.Equal(45000, elves.Sum(x => x.CalorificValue));
    }
}