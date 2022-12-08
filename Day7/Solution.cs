using Day7.Parser;

namespace Day7;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private DirectoryParser _parser;

    public Solution()
    {
        EventName = "No Space Left On Device";
    }

    public override void ReadInput(string inputName = "")
    {
        _parser = new DirectoryParser(GetCleanedFileLines(inputName));
        _parser.ParseInput();
    }

    protected override void SolvePartOne()
    {
        GetLargestSmallDirectories();
    }

    public int GetLargestSmallDirectories()
    {
        var size = _parser.GetDirectorySizes().Values.Where(x => x <= 100000).Sum();
        Console.WriteLine($"The sum of all directories smaller than 100000 is {size}");
        return size;
    }

    protected override void SolverPartTwo()
    {
        FindSmallestDirectoryAboveRequiredSpace();
    }

    public int FindSmallestDirectoryAboveRequiredSpace()
    {
        var dict = _parser.GetDirectorySizes();
        var totalStored = dict.Values.Max();
        var totalAvailable = 70000000;
        var target = 30000000;
        var diff = target - (totalAvailable - totalStored);
        var smallest = dict.Values.Where(x => x >= diff).Min();
        Console.WriteLine($"The smallest directory to free up at least {target} space is {smallest}");
        return smallest;
    }
}