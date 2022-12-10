namespace Day9;

public class Knot
{
    private int[] _position = { 0, 0 };
    private readonly List<int[]> _history = new() { new[] { 0, 0 } };
    private Knot? _parent;
    private Knot? _child;

    private int[] CurrentPosition
        => _position;

    public void SetParent(Knot? knot) => _parent = knot;
    public Knot? GetChild() => _child;
    public void SetChild(Knot? knot) => _child = knot;
    public bool HasChild() => _child is not null;
    public IEnumerable<int[]> GetHistory() => _history;

    public void Move(int x, int y)
    {
        _position[0] += x;
        _position[1] += y;

        UpdateHistory();
    }

    public void ChaseHead()
    {
        if (_parent is null)
        {
            return;
        }

        if (!IsAdjacent())
        {
            var rawXDiff = (_parent.CurrentPosition[0] - _position[0]) / 2d;
            var rawYDiff = (_parent.CurrentPosition[1] - _position[1]) / 2d;

            var xDiff = rawXDiff > 0 ? Math.Ceiling(rawXDiff) : Math.Floor(rawXDiff);
            var yDiff = rawYDiff > 0 ? Math.Ceiling(rawYDiff) : Math.Floor(rawYDiff);

            _position = new[] { (int)(_position[0] + xDiff), (int)(_position[1] + yDiff) };
        }

        UpdateHistory();
    }

    private bool IsAdjacent()
    {
        if (_parent is null)
        {
            return false;
        }

        return IsOneOff(_parent.CurrentPosition[0], _position[0])
               && IsOneOff(_parent.CurrentPosition[1], _position[1]);
    }

    private static bool IsOneOff(int start, int compareTo)
        => Math.Abs(compareTo - start) <= 1;

    private void UpdateHistory()
    {
        _history.Add(new [] { _position[0], _position[1]});
    }
}