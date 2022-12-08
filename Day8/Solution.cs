namespace Day8;

public class Solution : AdventOfCode2022.Abstractions.Solution
{
    private Tree[,] _trees;
    private int _width;
    private int _height;
    public Solution()
    {
        EventName = "Treetop Tree House";
    }
    public override void ReadInput(string inputName = "")
    {
        var rawLines = GetCleanedFileLines(inputName);
        _width = rawLines.First().Length;
        _height = rawLines.Length;
        _trees = new Tree[_width, _height];
        for (var ii = 0; ii < _width; ii++)
        {
            for (var jj = 0; jj < _height; jj++)
            {
                _trees[ii, jj] = new Tree { Height = int.Parse(rawLines[ii][jj].ToString()) };
            }
        }
    }

    protected override void SolvePartOne()
    {
        CountVisibleTreesFromTheOutside();
    }

    public int CountVisibleTreesFromTheOutside()
    {
        ScanTreeLine(0,
            0,
            ii => ii < _width,
            ii => ii < _height,
            ii => ++ii,
            ii => ++ii,
            (ii, jj) => _trees[ii, jj]);
        ScanTreeLine(0,
            _height - 1,
            ii => ii < _width,
            ii => ii >= 0,
            ii => ++ii,
            ii => --ii,
            (ii, jj) => _trees[jj, ii]);
        ScanTreeLine(_width - 1,
            0,
            ii => ii >= 0,
            ii => ii < _height,
            ii => --ii,
            ii => ++ii,
            (ii, jj) => _trees[jj, ii]);
        ScanTreeLine(_width - 1,
            _height - 1,
            ii => ii >= 0,
            ii => ii >= 0,
            ii => --ii,
            ii => --ii,
            (ii, jj) => _trees[ii, jj]);

        int count = 0;
        for (var ii = 0; ii < _width; ii++)
        {
            for (var jj = 0; jj < _height; jj++)
            {
                if (_trees[ii, jj].Visible)
                {
                    count++;
                }
            }
        }

        Console.WriteLine($"There are {count} trees visible from the outside");
        return count;
    }

    public int GetMostScenicTree()
    {
        CalculateScenicScoreForEveryTree();
        int mostScenic = 0;
        for (var ii = 0; ii < _width; ii++)
        {
            for (var jj = 0; jj < _height; jj++)
            {
                if (_trees[ii, jj].ScenicScore > mostScenic)
                {
                    mostScenic = _trees[ii, jj].ScenicScore;
                }
            }
        }
        Console.WriteLine($"The most scenic tree has a score of {mostScenic}");
        return mostScenic;
    }

    private void CalculateScenicScoreForEveryTree()
    {
        for (var ii = 0; ii < _width; ii++)
        {
            for (var jj = 0; jj < _height; jj++)
            {
                CalculateScenicScoreForTree(ii, jj);
            }
        }
    }

    public void CalculateScenicScoreForTree(int x, int y)
    {
        int down = CountVisibleTreesInLine(x, y, ii => ii >= 0, ii => --ii, (ii, jj) => _trees[ii, jj]);
        int up = CountVisibleTreesInLine(x, y, ii => ii < _height, ii => ++ii, (ii, jj) => _trees[ii, jj]);
        int left = CountVisibleTreesInLine(y, x, ii => ii <  _width, ii => ++ii, (ii, jj) => _trees[jj, ii]);
        int right = CountVisibleTreesInLine(y, x, ii => ii >= 0, ii => --ii, (ii, jj) => _trees[jj, ii]);

        _trees[x, y].ScenicScore = down * up *left * right;
    }

    private void ScanTreeLine(
        int startX,
        int startY,
        Func<int, bool> continueX,
        Func<int, bool> continueY,
        Func<int, int> xIncrementor,
        Func<int, int> yIncrementor,
        Func<int, int, Tree> treePicker)
    {
        for (var ii = startX; continueX(ii); ii = xIncrementor(ii))
        {
            var currentMax = -1;
            for (var jj = startY; continueY(jj); jj = yIncrementor(jj))
            {
                var tree = treePicker(ii, jj);
                if (tree.Height > currentMax)
                {
                    tree.Visible = true;
                    currentMax = tree.Height;
                }
            }
        }
    }

    private int CountVisibleTreesInLine(
        int constantRowOrColumn,
        int scanStart,
        Func<int, bool> continueScan,
        Func<int, int> scanNextStep,
        Func<int, int, Tree> treePicker)
    {
        var myTree = treePicker(constantRowOrColumn, scanStart).Height;
        var count = 0;
        var scanAfterStep = scanNextStep(scanStart);
        if (!continueScan(scanAfterStep))
        {
            return 0;
        }

        for (var ii = scanAfterStep; continueScan(ii); ii = scanNextStep(ii))
        {
            var tree = treePicker(constantRowOrColumn, ii);
            if (tree.Height < myTree)
            {
                count++;
            }

            if (tree.Height >= myTree)
            {
                count++;
                break;
            }
        }

        return count;
    }

    protected override void SolverPartTwo()
    {
        GetMostScenicTree();
    }
}