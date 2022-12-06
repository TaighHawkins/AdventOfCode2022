namespace Day5;

public class Instruction
{
    public Instruction(string input)
    {
        var split = input.Split(' ');
        Count = int.Parse(split[1]);
        From = int.Parse(split[3]);
        To = int.Parse(split[5]);
    }

    public int From { get; }
    public int To { get; }
    public int Count { get; }
}