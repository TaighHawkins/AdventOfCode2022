namespace Day12;

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public char Elevation { get; set; }

    public int CheapestRouteCost { get; set; } = int.MaxValue;
    public Node[] CheapestRoute { get; set; }

    public void SetCheapestRoute(Node[] route)
    {
        var costToHere = route.Last().CheapestRouteCost + 1;
        if (costToHere < CheapestRouteCost)
        {
            CheapestRouteCost = costToHere;
            CheapestRoute = route;
        }
    }
}