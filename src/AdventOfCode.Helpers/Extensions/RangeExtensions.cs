namespace AdventOfCode.Helpers.Extensions;

public static class RangeExtensions
{
    public static int GetLength(this Range range)
    {
        return range.End.Value - range.Start.Value;
    }
    
    public static bool Contains(this Range parentRange, Range rangeToCheck)
    {
        return parentRange.Start.Value <= rangeToCheck.Start.Value && parentRange.End.Value >= rangeToCheck.End.Value;
    }
    
    public static bool Overlaps(this Range parentRange, Range rangeToCheck)
    {
        return (parentRange.Start.Value <= rangeToCheck.Start.Value && parentRange.End.Value >= rangeToCheck.Start.Value) ||
                   (parentRange.Start.Value <= rangeToCheck.End.Value && parentRange.End.Value >= rangeToCheck.End.Value);
    }
}