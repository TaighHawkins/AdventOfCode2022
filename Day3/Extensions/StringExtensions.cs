namespace Day3.Extensions;

public static class StringExtensions
{
    public static string[] SplitStringInTwoEqualPieces(this string s)
    {
        string partOne = s[..(s.Length/2)];
        string partTwo = s[(s.Length/2)..];
        return new[] { partOne, partTwo };
    }
    public static char SplitStringInTwoAndFindCommonCharacter(this string s)
    {
        return s.SplitStringInTwoEqualPieces().GetSingleCommonElement();
    }
}