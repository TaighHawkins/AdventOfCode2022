namespace Day12;

public class Node
{
    public Node(char c, int x, int y)
    {
        Elevation = c switch
        {
            'S' => 'a',
            'E' => 'z',
            _ => c
        };
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public char Elevation { get; set; }

    public int CheapestRouteCost { get; set; } = int.MaxValue;
    public Node[] CheapestRoute { get; set; }

    public void SetCheapestRoute(Node prev)
    {
        var costToHere = prev.CheapestRouteCost + 1;
        if (costToHere < CheapestRouteCost)
        {
            CheapestRouteCost = costToHere;
        }
    }
}