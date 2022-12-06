using System.Text;

namespace Day5.CrateMover;

public class CrateMover
{
    protected readonly Stack<char>[]? _crateStacks;

    public CrateMover(IReadOnlyList<Stack<char>>? crateStacks)
    {
        if (crateStacks == null)
        {
            return;
        }

        // We copy the stacks from one to another to ensure each cratemover works on its own copy
        _crateStacks = new Stack<char>[crateStacks.Count];
        for (var ii = 0; ii < crateStacks.Count; ii++)
        {
            var arr = new char[crateStacks[ii].Count];
            crateStacks[ii].CopyTo(arr, 0);
            Array.Reverse(arr);
            _crateStacks[ii] = new Stack<char>(arr);
        }
    }

    public string ReadTopOfStacks()
    {
        StringBuilder sb = new();
        if (_crateStacks == null)
        {
            throw new InvalidOperationException(
                "Unable to read the top of the stacks if the stack map hasn't been loaded");
        }
        
        foreach (var stack in _crateStacks)
        {
            sb.Append(stack.Pop());
        }

        var topLetters = sb.ToString();
        Console.WriteLine($"The top letter of each stack reads: {topLetters}");
        return topLetters;
    }
}