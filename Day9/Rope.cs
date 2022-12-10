namespace Day9;

public class Rope
{
    private readonly Knot[] _knots;

    private Knot Head
        => _knots[0];

    private Knot Tail
        => _knots.Last();

    public Rope(int size)
    {
        _knots = Enumerable.Range(0, size)
            .Select(x => new Knot())
            .ToArray();

        for (var ii = 0; ii < _knots.Length; ii++)
        {
            var parentIndex = ii - 1;
            var childIndex = ii + 1;
            if (parentIndex >= 0)
            {
                _knots[ii].SetParent(_knots[parentIndex]);
            }

            if (childIndex < _knots.Length)
            {
                _knots[ii].SetChild(_knots[childIndex]);
            }
        }
    }

    public void FollowInstruction(Instruction instruction)
    {
        for (var ii = 0; ii < instruction.Distance; ii++)
        {
            switch (instruction.Direction)
            {
                case Direction.Up:
                    Head.Move(0, 1);
                    break;
                case Direction.Down:
                    Head.Move(0, -1);
                    break;
                case Direction.Right:
                    Head.Move(1, 0);
                    break;
                case Direction.Left:
                    Head.Move(-1, 0);
                    break;
                default:
                    throw new InvalidDataException();
            }

            var current = Head;
            while (current?.HasChild() == true)
            {
                current = current.GetChild();
                current?.ChaseHead();
            }
        }
    }

    public int CountUniqueTailPositions()
    {
        return Tail.GetHistory()
            .DistinctBy(x => (x[0], x[1]))
            .Count();
    }

}