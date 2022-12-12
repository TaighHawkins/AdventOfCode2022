namespace Day12;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private Node[][] _grid;
    private int[] _start;
    private int[] _end;
    private int _maxX;
    private int _maxY;

    public override void ReadInput(string inputName = "")
    {
        var lines = GetCleanedFileLines(inputName);
        _maxY = lines.Length;
        _maxX = lines[0].Length;
        _grid = new Node[_maxY][];

        for (var ii = 0; ii < lines.Length; ii++)
        {
            var line = lines[ii];
            var nodes = new Node[line.Length];
            for (var jj = 0; jj < line.Length; jj++)
            {
                var c = line[jj];
                nodes[jj] = new Node(c, ii, jj);
                switch (c)
                {
                    case 'S':
                        _start = new[] { ii, jj };
                        break;
                    case 'E':
                        _end = new[] { ii, jj };
                        break;
                }
            }

            _grid[ii] = nodes;
        }

        _grid[_start[0]][_start[1]].CheapestRouteCost = 0;
    }

    protected override void SolvePartOne()
    {
        SearchGrid(_start);
    }

    public int SearchGrid(IReadOnlyList<int> start)
    {
        var stack = new Stack<int[]>();
        stack.Push(new[] { start[0], start[1] });
        while (stack.Count > 0)
        {
            WalkStep(stack);
        }

        var cheapestRouteCost = _grid[_end[0]][_end[1]].CheapestRouteCost;
        Console.WriteLine($"The cheapest cost to the peak is {cheapestRouteCost}");
        return cheapestRouteCost;
    }

    private void WalkStep(Stack<int[]> stack)
    {
        var current = stack.Pop();
        var currentNode = _grid[current[0]][current[1]];
        var currentCost = currentNode.CheapestRouteCost;
        var fromHereToThere = currentCost + 1;
        var possibleSteps = GetValidLocationsFromStart(current);

        foreach (var step in possibleSteps)
        {
            Node there = _grid[step[0]][step[1]];
            if (fromHereToThere < there.CheapestRouteCost)
            {
                there.CheapestRouteCost = fromHereToThere;
                stack.Push(step);
            }
        }
    }

    private List<int[]> GetValidLocationsFromStart(IReadOnlyList<int> start)
    {
        var points = new List<int[]>
        {
            new[] { start[0], start[1] + 1 },
            new[] { start[0], start[1] - 1 },
            new[] { start[0] + 1, start[1] },
            new[] { start[0] - 1, start[1] }
        };

        return points.Where(x => WithinBounds(x, start)).Reverse().ToList();
    }

    private bool WithinBounds(IReadOnlyList<int> next, IReadOnlyList<int> start)
    {
        if (start[0] == _end[0] && start[1] == _end[1])
        {
            return false;
        }

        if (!(next[0] >= 0 && next[1] < _maxX && next[1] >= 0 && next[0] < _maxY))
        {
            return false;
        }

        var nextElevation = (int)_grid[next[0]][next[1]].Elevation;
        var currentElevation = (int)_grid[start[0]][start[1]].Elevation;
        return nextElevation - currentElevation <= 1;
    }

    protected override void SolverPartTwo()
    {
        SearchGridFromAllStartPoints();
    }

    public int SearchGridFromAllStartPoints()
    {
        var startPoints = _grid.SelectMany(x => x).Where(x => x.Elevation == 'a').ToArray();
        List<int> totals = new List<int>();
        foreach (var start in startPoints)
        {
            ResetGrid();
            _grid[start.X][start.Y].CheapestRouteCost = 0;
            int steps = SearchGrid(new[] { start.X, start.Y });
            totals.Add(steps);
            Console.WriteLine($"Cost for search from {start.X},{start.Y} took {steps}");
        }

        var min = totals.Min();
        Console.WriteLine($"The shortest trip from an a spot to E is {min}");
        return min;
    }

    private void ResetGrid()
    {
        foreach (var node in _grid.SelectMany(x => x))
        {
            node.CheapestRouteCost = int.MaxValue;
        }
    }
}
