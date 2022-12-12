namespace Day11;

public class Monkey
{
    private readonly string _worryModifier;
    public readonly List<long> _items;
    private Monkey _successMonkey;
    private Monkey _failMonkey;

    public long MonkeySpecificDivisor { get; }

    public long InspectionCount { get; private set; }

    public Monkey(string worryModifier, List<long> items, long monkeySpecificDivisor)
    {
        _worryModifier = worryModifier;
        _items = items;
        MonkeySpecificDivisor = monkeySpecificDivisor;
    }

    public void InspectItems(long worryDivisor, long worryModulo = 0)
    {
        for (var ii = 0; ii < _items.Count; ii++)
        {
            var modified = ModifyWorry(_items[ii]);
            if (worryModulo != 0)
            {
                modified %= worryModulo;
            }

            if (worryDivisor != 0)
            {
                modified /= worryDivisor;
            }
            _items[ii] = modified;
            InspectionCount++;
        }
    }

    public void AddSuccessMonkey(Monkey monkey) => _successMonkey = monkey;
    public void AddFailMonkey(Monkey monkey) => _failMonkey = monkey;

    public void ThrowItems()
    {
        var itemsToBeThrown = _items.ToArray();
        foreach (var item in itemsToBeThrown)
        {
            _items.RemoveAt(0);
            if (item % MonkeySpecificDivisor == 0)
            {
                _successMonkey.AddItem(item);
            }
            else
            {
                _failMonkey.AddItem(item);
            }
        }
    }

    private long ModifyWorry(long startingWorry)
    {
        var worryBits = _worryModifier.Split(' ');
        var firstValue = ConvertToValue(worryBits[0], startingWorry);
        var secondValue = ConvertToValue(worryBits[2], startingWorry);

        return worryBits[1] switch
        {
            "*" => firstValue * secondValue,
            "/" => firstValue / secondValue,
            "+" => firstValue + secondValue,
            "-" => firstValue - secondValue,
            _ => throw new InvalidOperationException("Unexpected operator indicator")
        };

        long ConvertToValue(string input, long original)
            => input switch
            {
                "old" => original,
                _ => long.Parse(input)
            };

    }

    public void AddItem(long item) => _items.Add(item);
}