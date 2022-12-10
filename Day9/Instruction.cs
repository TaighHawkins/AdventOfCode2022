namespace Day9;

public class Instruction
{
    public Instruction(string input)
    {
        var split = input.Split(' ');
        Distance = int.Parse(split[1]);
        Direction = split[0] switch
        {
            "U" => Direction.Up,
            "D" => Direction.Down,
            "L" => Direction.Left,
            "R" => Direction.Right,
            _ => throw new InvalidDataException()
        };
    }

    public Direction Direction { get; }
    public int Distance { get; }
}