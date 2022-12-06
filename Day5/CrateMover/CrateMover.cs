using System.Text;

namespace Day5.CrateMover;

public class CrateMover
{
    protected readonly Stack<char>[] _crateStacks;

    public CrateMover(Stack<char>[]? crateStacks)
    {
        if (crateStacks == null)
        {
            return;
        }

        _crateStacks = new Stack<char>[crateStacks.Length];
        for (var ii = 0; ii < crateStacks.Length; ii++)
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
        foreach (var stack in _crateStacks)
        {
            sb.Append(stack.Pop());
        }

        var topLetters = sb.ToString();
        Console.WriteLine($"The top letter of each stack reads: {topLetters}");
        return topLetters;
    }
}