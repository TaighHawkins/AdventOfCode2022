namespace Day3.Extensions;

public static class CharExtensions
{
    public static int ConvertCharToPriority(this char c)
    {
        return c > 96 ? c - 96 : (c - 64) + 26;
    }
}