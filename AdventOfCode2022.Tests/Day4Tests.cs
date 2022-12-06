namespace AdventOfCode2022.Tests;
using Day4;

public class Day4Tests
{
    private readonly Solution _solution;
    public Day4Tests()
    {
        _solution = new Solution();
        _solution.ReadInput("day4TestInput.txt");
    }

    [Fact]
    public void TestSolutionOneWorks()
    {
        int count = _solution.CountRedundantAssignments();
        Assert.Equal(2, count);
    }

    [Fact]
    public void TestSolutionTwoWorks()
    {
        int score = _solution.CountOverlappingAssignments();
        Assert.Equal(4, score);
    }


    [Theory]
    [MemberData(nameof(EncompassedAssignmentData))]
    public void EncompassedAssignmentsIdentifiedCorrectly(int min1, int max1, int min2, int max2, bool expected)
    {
        Assert.Equal(expected, new Assignment(min1, max1).OneAssignmentIsRedundant(new Assignment(min2, max2)));
    }

    public static IEnumerable<object[]> EncompassedAssignmentData()
    {
        yield return new object[] { 2, 3, 3, 4, false };
        yield return new object[] { 1, 2, 3, 4, false };
        yield return new object[] { 3, 9, 4, 6, true };
        yield return new object[] { 3, 4, 2, 3, false };
        yield return new object[] { 3, 4, 2, 7, true };
    }

    [Theory]
    [MemberData(nameof(OverlappingBoundsData))]
    public void OverlappingBoundsIdentifiedCorrectly(int min1, int max1, int min2, int max2, bool expected)
    {
        Assert.Equal(expected, new Assignment(min1, max1).OverlapsWithAssignment(new Assignment(min2, max2)));
    }

    public static IEnumerable<object[]> OverlappingBoundsData()
    {
        yield return new object[] { 2, 3, 3, 4, true };
        yield return new object[] { 1, 2, 3, 4, false };
        yield return new object[] { 3, 9, 4, 6, true };
        yield return new object[] { 3, 4, 2, 3, true };
        yield return new object[] { 3, 4, 2, 7, true };
    }
}