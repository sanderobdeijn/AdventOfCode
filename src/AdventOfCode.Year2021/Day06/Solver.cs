using AdventOfCode.Year2021.Day05;

namespace AdventOfCode.Year2021.Day06;

public static class Solver
{
    public static long GetNumberOfLanternFishAfterDay(string input, int maxDays)
    {
        var startingDay = GetStartingDay(input);
        
        var currentDay = startingDay;

        for (var i = 0; i < maxDays; i++)
        {
            currentDay = currentDay.NextDay();
        }

        return currentDay.LanternfishCount;
    }

    private static Day GetStartingDay(string input)
    {
        return new Day(input.Split(',').Select(x => int.Parse(x)));
    }
}