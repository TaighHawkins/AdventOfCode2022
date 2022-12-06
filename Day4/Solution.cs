namespace Day4;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private List<Assignment[]> _assignmentPairs;

    public override void ReadInput(string inputName = "")
    {
        _assignmentPairs = GetCleanedFileLines(inputName).Select(x =>
        {
            var split = x.Split(',');
            var assignmentOne = split[0].Split('-');
            var assignmentTwo = split[1].Split('-');
            return new Assignment[]
                {
                    new(int.Parse(assignmentOne[0]), int.Parse(assignmentOne[1])),
                    new(int.Parse(assignmentTwo[0]), int.Parse(assignmentTwo[1]))
                };
        }).ToList();
    }

    protected override void SolvePartOne()
    {
        CountRedundantAssignments();
    }

    public int CountRedundantAssignments()
    {
        var count = _assignmentPairs.Count(x => x[0].OneAssignmentIsRedundant(x[1]));

        Console.WriteLine($"There are {count} redundant assignments");
        return count;
    }

    protected override void SolverPartTwo()
    {
        CountOverlappingAssignments();
    }

    public int CountOverlappingAssignments()
    {
        var count = _assignmentPairs.Count(x => x[0].OverlapsWithAssignment(x[1]));

        Console.WriteLine($"There are {count} overlapping assignments");
        return count;
    }
}