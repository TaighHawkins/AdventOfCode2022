namespace Day4;

public class Assignment
{
    public int Min { get; init; }
    public int Max { get; init; }

    public Assignment(int min, int max)
    {
        Min = min;
        Max = max;
    }

    /// <summary>
    /// Returns true if one assignment is a subset of the other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool OneAssignmentIsRedundant(Assignment other)
    {
        return (other.Min >= Min && other.Max <= Max)
            || (Min >= other.Min && Max <= other.Max);
    }

    /// <summary>
    /// Returns true if any part of one assignment is contained within the other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool OverlapsWithAssignment(Assignment other)
    {
        return (other.Min <= Min && other.Max >= Min)
            || (other.Min <= Max && other.Max >= Max )
            || OneAssignmentIsRedundant(other);
    }
}