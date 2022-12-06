using System.Text;

namespace Day5.CrateMover.Interface;

public interface ICrateMover
{
    void FollowInstructions(Instruction[]? instructions);
    string ReadTopOfStacks();
}