namespace AdventOfCode.Year2021.Day14;

public static class Solver
{
    public static long GetNumberOfMostCommonElementMinusNumberOfLeastCommonElementsAfterNumberOfSteps(string input, int numberOfSteps)
    {
        var polymerPairs = GetPolymerPairs(input);
        var template = GetTemplate(input);
        var inserter = GetInserter(polymerPairs, template);
        
        var polymerPairsWithCount = GetSteps(numberOfSteps, polymerPairs, inserter).PolymerPairsWithCount;
        var charCount = GetCharCount(polymerPairsWithCount, template);

        return charCount.Max(x => x.Value) - charCount.Min(x => x.Value);
    }

    private static Dictionary<(char, char), char> GetPolymerPairs(string input)
    {
        return input.SplitLines().Where(x => x.Contains('-')).Select(x => x.Split(" -> ")).Select(y => ((y[0].First(), y[0].Last()), y[1].First())).ToDictionary(t => t.Item1, t => t.Item2);
    }

    private static string GetTemplate(string input)
    {
        return input.SplitLines().First();
    }

    private static Inserter GetInserter(Dictionary<(char, char), char> polymerPairs, string template)
    {
        return new Inserter(GetPolymerPairsToExpand(polymerPairs.Select(x => x.Key).ToList(), template.Select(x => x).ToList()));
    }
    
    private static Dictionary<(char, char), long> GetPolymerPairsToExpand(List<(char, char)> polymerPairs, List<char> template)
    {
        var polymerPairsCounter = polymerPairs.ToDictionary(x => x, x => (long)0);

        for (var i = 0; i < template.Count -1; i++)
        {
            var key = (template.ElementAt(i), template.ElementAt(i + 1));

            polymerPairsCounter[key]++;
        }

        return polymerPairsCounter;
    }
    
    private static Inserter GetSteps(int steps, Dictionary<(char, char), char> polymerPairs, Inserter inserter)
    {
        for (var i = 0; i < steps; i++)
        {
            inserter = inserter.NextStep(polymerPairs);
        }

        return inserter;
    }
    
    private static Dictionary<char, long> GetCharCount(Dictionary<(char, char), long> polymerPairsWithCount, string template)
    {
        var charCounts = polymerPairsWithCount.GroupBy(x => x.Key.Item1).Select(x => (x.Key, x.Sum(y=> y.Value))).ToDictionary(x=> x.Key,x=>x.Item2);

        charCounts[template.Last()]++;
        return charCounts;
    }
}