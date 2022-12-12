namespace Day3.Extensions;

public static class IEnumerableExtensions
{
    public static char GetSingleCommonElement(this IEnumerable<string> strings)
    {
        return strings
            .Aggregate<IEnumerable<char>>((a, b) => a.Intersect(b))
            .Single();
    }
}