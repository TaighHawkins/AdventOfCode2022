namespace Day6;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private SignalParser? _signalParser;

    public Solution()
    {
        EventName = "Tuning Trouble";
    }

    public override void ReadInput(string inputName = "")
    {
        _signalParser = new SignalParser(GetCleanedFileAsString(inputName));
    }

    protected override void SolvePartOne()
    {
        _signalParser?.IdentifyStartOfPacketMarker(4);
    }

    protected override void SolverPartTwo()
    {
        _signalParser?.IdentifyStartOfPacketMarker(14);
    }
}