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

    public bool OneAssignmentIsRedundant(Assignment other)
    {
        return (other.Min >= Min && other.Max <= Max)
            || (Min >= other.Min && Max <= other.Max);
    }

    public bool OverlapsWithAssignment(Assignment other)
    {
        return (other.Min <= Min && other.Max >= Min)
            || (other.Min <= Max && other.Max >= Max )
            || OneAssignmentIsRedundant(other);
    }
}