using AdventOfCode2022.Utilities;
using Day3.Extensions;

namespace Day3;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private string[] _rucksacks;

    public Solution()
    {
        EventName = "Rucksack Reorganization";
    }

    public override void ReadInput(string inputName = "")
    {
        _rucksacks = GetCleanedFileLines(inputName);
    }

    protected override void SolvePartOne()
    {
        GetPriorityOfDuplicatedItems();
    }

    public int GetPriorityOfDuplicatedItems()
    {
        if (_rucksacks is null)
        {
            throw new InvalidOperationException($"Please call {nameof(ReadInput)} before calling a solve operation");
        }

        int totalPriority = _rucksacks
            .Select(x => x.SplitStringInTwoAndFindCommonCharacter().ConvertCharToPriority())
            .Sum();

        Console.WriteLine($"The total priority of all common characters in rucksacks is {totalPriority}");
        return totalPriority;
    }

    protected override void SolverPartTwo()
    {
        GetPriorityOfGroupBadges();
    }

    public int GetPriorityOfGroupBadges()
    {
        if (_rucksacks is null)
        {
            throw new InvalidOperationException($"Please call {nameof(ReadInput)} before calling a solve operation");
        }

        var groupPriority = _rucksacks
            .Batch(3)
            .Select(x => x.GetSingleCommonElement().ConvertCharToPriority())
            .Sum();

        Console.WriteLine($"The total priority of all group badges is {groupPriority}");
        return groupPriority;
    }

}