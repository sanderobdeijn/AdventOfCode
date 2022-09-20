namespace AdventOfCode.Year2021.Day14;

public class Inserter
{
    public Inserter(Dictionary<(char, char), long> polymerPairsWithCount)
    {
        PolymerPairsWithCount = polymerPairsWithCount;
    }

    public Dictionary<(char, char), long> PolymerPairsWithCount { get; }

    public Inserter NextStep(Dictionary<(char, char), char> polymerPairsMap)
    {
        var newPolymerPairsWithCount = polymerPairsMap.ToDictionary(x => x.Key, x => (long)0);

        foreach (var polymerPairWithCount in PolymerPairsWithCount)
        {
            var intermediate = polymerPairsMap[polymerPairWithCount.Key];

            newPolymerPairsWithCount[(polymerPairWithCount.Key.Item1, intermediate)] += polymerPairWithCount.Value;
            newPolymerPairsWithCount[(intermediate, polymerPairWithCount.Key.Item2)] += polymerPairWithCount.Value;
        }

        return new Inserter(newPolymerPairsWithCount);
    }
}
