namespace Day1;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private List<Elf>? _elves;

    public override void ReadInput(string inputName = "")
    {
        List<List<int>> rawValues = GetCleanedFileAsString(inputName)
            .Split("\n\n")
            .Select(x => x.Trim()
                .Split('\n')
                .Select(int.Parse).ToList())
            .ToList();
        
        _elves = rawValues.Select(
            (x, ii) => new Elf
            {
                Id = ii,
                CalorificValue = x.Sum()
            }).ToList();
    }

    protected override void SolvePartOne()
    {
        GetMostCalorificElf();
    }

    protected override void SolverPartTwo()
    {
        GetTopThreeMostCalorificElves();
    }

    public Elf? GetMostCalorificElf()
    {
        if (_elves is null)
        {
            throw new InvalidOperationException($"Please call {nameof(ReadInput)} before calling a solve operation");
        }
        
        var calorificElf = _elves.MaxBy(x => x.CalorificValue);
        Console.WriteLine($"Elf {calorificElf?.Id} has the most calories at {calorificElf?.CalorificValue}");
        return calorificElf;
    }

    public List<Elf> GetTopThreeMostCalorificElves()
    {
        if (_elves is null)
        {
            throw new InvalidOperationException($"Please call {nameof(ReadInput)} before calling a solve operation");
        }
        
        List<Elf> topThreeElves = _elves
            .OrderByDescending(x => x.CalorificValue)
            .Take(3)
            .ToList();
        
        Console.WriteLine($"The top three elves have a calorific value {topThreeElves.Sum(x => x.CalorificValue)}");
        return topThreeElves;
    }
}