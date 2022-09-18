namespace AdventOfCode.Helpers.Extensions;

public static class StringExtensions
{
    public static IEnumerable<string> SplitLines(this string input)
    {
        return input.Split("\r\n");
    }
}