using Day5.CrateMover.Interface;

namespace Day5.CrateMover;

public class CrateMover9000 : CrateMover, ICrateMover
{
    public CrateMover9000(Stack<char>[]? crateStacks) : base(crateStacks)
    {
    }

    public void FollowInstructions(Instruction[]? instructions)
    {
        if (instructions == null)
        {
            return;
        }

        foreach (var instruction in instructions)
        {
            for (var ii = 0; ii < instruction.Count; ii++)
            {
                var crate = _crateStacks[instruction.From - 1].Pop();
                _crateStacks[instruction.To - 1].Push(crate);
            }
        }
    }
}