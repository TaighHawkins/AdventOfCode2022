using Day5.CrateMover.Interface;

namespace Day5.CrateMover;

public class CrateMover9001: CrateMover, ICrateMover
{
    public
        CrateMover9001(Stack<char>[]? crateStacks) : base(crateStacks)
    {
    }

    public void FollowInstructions(Instruction[]? instructions)
    {
        if (instructions == null)
        {
            return;
        }

        Stack<char> crates = new();
        foreach (var instruction in instructions)
        {
            for (var ii = 0; ii < instruction.Count; ii++)
            {
                crates.Push(_crateStacks[instruction.From - 1].Pop());
            }

            while (crates.Any())
            {
                _crateStacks[instruction.To - 1].Push(crates.Pop());
            }
        }
    }
}