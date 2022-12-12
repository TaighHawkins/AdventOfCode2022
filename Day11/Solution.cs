namespace Day11;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private Dictionary<int, Monkey> _monkeys = new();

    public Solution()
    {
        EventName = "Monkey in the Middle";
    }
    public override void ReadInput(string inputName = "")
    {
        var monkeyData = GetCleanedFileAsString(inputName).Split("\n\n")
            .Select(x =>
            {
                var input = x.Split('\n');
                var monkeyId = int.Parse(input[0].Trim(':').Split(' ')[1]);
                var items = input[1]
                    .Split(": ")[1]
                    .Replace(",", "")
                    .Split(' ')
                    .Select(long.Parse)
                    .ToList();
                var operation = input[2].Split(": ")[1].Replace("new = ", "");
                var divisor = uint.Parse(input[3].Split(' ')[^1]);
                var successTarget = int.Parse(input[4].Split(' ')[^1]);
                var failureTarget = int.Parse(input[5].Split(' ')[^1]);

                return (new KeyValuePair<int, Monkey>(monkeyId, new Monkey(operation, items, divisor)), successTarget, failureTarget);
            });
        _monkeys = monkeyData.ToDictionary(x => x.Item1.Key, x => x.Item1.Value);

        foreach (var data in monkeyData)
        {
            _monkeys[data.Item1.Key].AddSuccessMonkey(_monkeys[data.successTarget]);
            _monkeys[data.Item1.Key].AddFailMonkey(_monkeys[data.failureTarget]);
        }
    }

    protected override void SolvePartOne()
    {
        ReadInput();
        CalculateMonkeyBusinessAfterRounds(20, 3, 0);
    }

    public long CalculateMonkeyBusinessAfterRounds(int roundLimit, long worryDivisor, long worryModulo)
    {
        var monkeys = _monkeys.Values.ToArray();
        for (var ii = 0; ii < roundLimit; ii++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.InspectItems(worryDivisor, worryModulo);
                monkey.ThrowItems();
            }
        }

        var monkeyBusiness = monkeys
            .OrderByDescending(x => x.InspectionCount)
            .Take(2)
            .Aggregate((long)1, (x, y) => x * y.InspectionCount);

        Console.WriteLine($"Calculated monkey business of top two monkeys is {monkeyBusiness}");
        return monkeyBusiness;
    }

    protected override void SolverPartTwo()
    {
        ReadInput();
        CalculateMonkeyBusinessAfterRounds(10_000, 0, CalculateCommonDivisor());
    }

    public long CalculateCommonDivisor()
        => _monkeys.Aggregate(1L, (x, kv) => x * kv.Value.MonkeySpecificDivisor);
}