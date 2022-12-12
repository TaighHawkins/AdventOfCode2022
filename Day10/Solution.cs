using AdventOfCode2022.Utilities;

namespace Day10;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private string[] _input;
    private readonly Dictionary<int, int> _signalStrengths = new() { { 1, 1} };
    private readonly List<bool> _pixels = new();

    public Solution()
    {
        EventName = "Cathode Ray Tube";
    }

    public override void ReadInput(string inputName = "")
    {
        _input = GetCleanedFileLines(inputName);
    }

    protected override void SolvePartOne()
    {
        GetSignalStrengthsAndCalculateStrength();
    }

    public int GetSignalStrengthsAndCalculateStrength()
    {
        InterpretInput();
        int signalStrength = CalculateSignalStrength();
        Console.WriteLine($"The signal strength is {signalStrength}");
        return signalStrength;
    }

    private int CalculateSignalStrength()
    {
        return _signalStrengths.Where(x => new[] { 20, 60, 100, 140, 180, 220 }.Contains(x.Key))
            .Sum(x => x.Key * x.Value);
    }

    private void InterpretInput()
    {
        if (_signalStrengths.Count > 1)
        {
            return;
        }

        int counter = 1;
        int x = 1;
        foreach (var input in _input)
        {
            _pixels.Add(ShouldBeLit(counter - 1, x));
            var split = input.Split(' ');
            counter++;
            _signalStrengths.Add(counter + 1, x);

            if (string.Equals(split[0], "addx", StringComparison.CurrentCultureIgnoreCase))
            {
                _pixels.Add(ShouldBeLit(counter - 1, x));
                counter++;
                x += int.Parse(split[1]);
                _signalStrengths.Add(counter + 1, x);
            }
        }

        Console.WriteLine("Signal Strengths Calculated");
    }

    private bool ShouldBeLit(int counter, int currentValue)
    {
        int workingCounter = counter;
        while (workingCounter >= 40)
        {
            workingCounter -= 40;
        }

        return Math.Abs(workingCounter - currentValue) <= 1;
    }

    protected override void SolverPartTwo()
    {
        RenderCrtDisplay();
    }

    public string RenderCrtDisplay()
    {
        InterpretInput();
        return RenderPixelDisplay();
    }

    private string RenderPixelDisplay()
    {
        InterpretInput();
        string display = string.Join("\r\n",
            _pixels
                .Batch(40)
                .Select(x =>
                    string.Join("", x.Select(y => y ? '█' : ' '))));
        Console.WriteLine(display);
        return display;
    }
}