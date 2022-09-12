using System.Numerics;

namespace AdventOfCode.Year2021.Day06;

public class Day
{
    public List<LanternfishColony> LanternfishColonies { get; init; }

    public long LanternfishCount => LanternfishColonies.Sum(x => x.Count);

    public Day(IEnumerable<int> startingDayValues)
    {
        LanternfishColonies = ParseToLanternfishColonies(startingDayValues).ToList();
    }

    public Day(IEnumerable<LanternfishColony> newColonies)
    {
        LanternfishColonies = newColonies.ToList();
    }

    private static IEnumerable<LanternfishColony> ParseToLanternfishColonies(IEnumerable<int> startingDay)
    {
        return startingDay.GroupBy(x => x).Select(x => new LanternfishColony(x.Key, (long)x.Count()));
    }

    public Day NextDay()
    {
        var groupedNewColonies = LanternfishColonies.SelectMany(x => x.NextDay()).GroupBy(x => x.DaysUntilReproduction);

        var mergedColonies = groupedNewColonies.Where(x => x.Count() > 1).Select(x => new LanternfishColony(x.Key, x.Sum(x => x.Count)));

        var newColonies = groupedNewColonies.Where(x => x.Count() == 1).Select(x => x.First()).Concat(mergedColonies);

        return new Day(newColonies);
    }
}
