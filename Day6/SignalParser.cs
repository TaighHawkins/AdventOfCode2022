namespace Day6;

public class SignalParser
{
    private readonly string _input;

    public SignalParser(string input)
    {
        _input = input;
    }

    public int IdentifyStartOfPacketMarker(int uniqueCount)
    {
        var chars = new Queue<char>(uniqueCount);
        var ii = 0;
        for (; !AllUnique(); ii++)
        {
            if (chars.Count == uniqueCount)
            {
                chars.Dequeue();
            }
            chars.Enqueue(_input[ii]);
        }

        Console.WriteLine($"Start of sequence marker identified at {ii} characters");
        return ii;
        
        bool AllUnique()
        {
            if (chars.Count < uniqueCount)
            {
                return false;
            }
            
            var arr = new char[uniqueCount];
            chars.CopyTo(arr, 0);
            return arr.Distinct().Count() == uniqueCount;
        }
    }
}