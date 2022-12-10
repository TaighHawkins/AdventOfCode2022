namespace Day9;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private Instruction[] _instructions;

    public Solution()
    {
        EventName = "Rope Bridge";
    }

    public override void ReadInput(string inputName = "")
    {
        _instructions = GetCleanedFileLines(inputName)
            .Select(x => new Instruction(x))
            .ToArray();
    }

    protected override void SolvePartOne()
    {
        ModelRope(2);
    }

    public int ModelRope(int ropeLength)
    {
        var rope = new Rope(ropeLength);
        foreach (var instruction in _instructions)
        {
            rope.FollowInstruction(instruction);
        }

        int count = rope.CountUniqueTailPositions();

        Console.WriteLine($"(v2) The tail took {count} unique positions");
        return count;
    }

    protected override void SolverPartTwo()
    {
        ModelRope(10);
    }
}