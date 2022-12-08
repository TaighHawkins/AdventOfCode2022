using System.Collections;
using System.Text;
using Day5.CrateMover;
using Day5.CrateMover.Interface;

namespace Day5;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private Stack<char>[]? _stacks;
    private Instruction[]? _instructions;

    public Solution()
    {
        EventName = "Supply Stacks";
    }

    public override void ReadInput(string inputName = "")
    {
        var rawInput = GetCleanedFileAsString(inputName);
        var splitInput = rawInput.Split("\n\n");
        var stackMap = splitInput[0].Split('\n');
        _instructions = splitInput[1].Split('\n').Select(x => new Instruction(x)).ToArray();
        var containerCount = int.Parse(stackMap.Last().Split(' ').Last());
        _stacks = Enumerable.Range(0, containerCount)
            .Select(x => new Stack<char>())
            .ToArray();

        for (var ii = _stacks.Length - 1; ii >= 0; ii-- )
        {
            for (var jj = 0; jj < containerCount; jj++)
            {
                // Assumption: We never have more than 9 crates
                var mapLine = stackMap[ii];
                var charIndex = (4 * jj) + 1;
                if (mapLine.Length < charIndex)
                {
                    break;
                }

                var letter = mapLine[charIndex];
                if (letter != ' ')
                {
                    _stacks[jj].Push(letter);
                }
            }
        }
    }

    protected override void SolvePartOne()
    {
        var crateMover = InitialiseCrateMover9000();
        CompleteInstructionsAndReadTopCrates(crateMover);
    }

    public ICrateMover InitialiseCrateMover9000()
    {
        Console.WriteLine("Initializing CrateMover 9000 ...");
        return new CrateMover9000(_stacks);
    }

    public ICrateMover InitialiseCrateMover9001()
    {
        Console.WriteLine("Initializing CrateMover 9001 ...");
        return new CrateMover9001(_stacks);
    }

    public string CompleteInstructionsAndReadTopCrates(ICrateMover crateMover)
    {
        crateMover.FollowInstructions(_instructions);
        return crateMover.ReadTopOfStacks();
    }

    protected override void SolverPartTwo()
    {
        var crateMover = InitialiseCrateMover9001();
        CompleteInstructionsAndReadTopCrates(crateMover);
    }
}