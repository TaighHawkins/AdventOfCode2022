namespace Day3.Extensions;

public static class IEnumerableExtensions
{
    public static char GetSingleCommonElement(this IEnumerable<string> strings)
    {
        return strings
            .Aggregate<IEnumerable<char>>((a, b) => a.Intersect(b))
            .Single();
    }

    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
        int maxItems)
    {
        return items.Select((item, inx) => new { item, inx })
            .GroupBy(x => x.inx / maxItems)
            .Select(g => g.Select(x => x.item));
    }
}