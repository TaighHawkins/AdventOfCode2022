namespace AdventOfCode2022.Utilities;

public static class DictionaryExtensions
{
    public static IEnumerable<IEnumerable<T>> BatchByKey<T>(this Dictionary<int, T> items,
        int maxItems)
    {
        return items
            .GroupBy(x => x.Key / maxItems)
            .Select(g => g.Select(x => x.Value));
    }
}