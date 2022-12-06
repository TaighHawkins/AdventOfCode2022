namespace Day2;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private List<Turn>? _turns;
    public override void ReadInput(string inputName = "")
    {
        _turns = GetCleanedFileLines(inputName)
            .Select(
                x => new Turn
                {
                    OpponentPlay = x[0],
                    Response = x[2]
                }).ToList();
    }

    protected override void SolvePartOne()
    {
        GetStrategyScore();
    }

    public int GetStrategyScore()
    {
        if (_turns is null)
        {
            throw new InvalidOperationException($"Please call {nameof(ReadInput)} before calling a solve operation");
        }
        
        var score = _turns.Select(x => x.GetResultWithFirstConversion()).Sum();
        Console.WriteLine($"The first strategy produced a score of {score}");
        return score;
    }

    protected override void SolverPartTwo()
    {
        GetStrategyScoreBasedOnOutcome();
    }
    
    public int GetStrategyScoreBasedOnOutcome()
    {
        if (_turns is null)
        {
            throw new InvalidOperationException($"Please call {nameof(ReadInput)} before calling a solve operation");
        }
        
        var score = _turns.Select(x => x.GetResultWithSecondConversion()).Sum();
        Console.WriteLine($"The second strategy produced a score of {score}");
        return score;
    }
}