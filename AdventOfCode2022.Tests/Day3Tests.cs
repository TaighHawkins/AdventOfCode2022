using Day3.Extensions;
using Day3;

namespace AdventOfCode2022.Tests;

public class Day3Tests
{
    private Solution _solution;
    public Day3Tests()
    {
        _solution = new Solution();
        _solution.ReadInput("day3TestInput.txt");
    }

    [Theory]
    [InlineData('a', 1)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    [InlineData('Z', 52)]
    [InlineData('p', 16)]
    [InlineData('L', 38)]
    [InlineData('P', 42)]
    [InlineData('v', 22)]
    [InlineData('t', 20)]
    [InlineData('s', 19)]
    public void CharConversionToPriorityReturnsAsExpected(char c, int expectedScore)
    {
        Assert.Equal(expectedScore, c.ConvertCharToPriority());
    }

    [Theory]
    [InlineData("abcdefGHIJKa")]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp")]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL")]
    [InlineData("PmmdzqPrVvPwwTWBwg")]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn")]
    [InlineData("ttgJtRGJQctTZtZT")]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw")]
    public void StringSplitResultsInTwoEqualPieces(string input)
    {
        var pieces = input.SplitStringInTwoEqualPieces();
        Assert.Equal(pieces[0].Length, pieces[1].Length);
    }

    [Theory]
    [InlineData("abcdefGHIJKa", 'a')]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJQctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
    public void CharExtractionReturnsAsExpected(string input, char expected)
    {
        Assert.Equal(expected, input.SplitStringInTwoAndFindCommonCharacter());
    }

    [Fact]
    public void TestSolutionOneWorks()
    {
        var priority = _solution.GetPriorityOfDuplicatedItems();
        Assert.Equal(157, priority);
    }

    [Fact]
    public void TestSolutionTwoWorks()
    {
        var priority = _solution.GetPriorityOfGroupBadges();
        Assert.Equal(70, priority);
    }
}