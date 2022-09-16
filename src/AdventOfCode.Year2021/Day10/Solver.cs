namespace AdventOfCode.Year2021.Day10;

public static class Solver
{
    public static int TotalSyntaxErrorScore(string input)
    {
        var navigationLines = input.Split("\r\n").Select(x=> new NavigationLine(x)).ToList();
        
        return navigationLines.Select(x => x.DeterimineStatus().IllegalValue).Sum();
    }

    public static List<long> CalculateCompletionScores(List<NavigationLine> navigationLines)
    {
        return navigationLines.Where(x => x.DeterimineStatus().status == Status.Incomplete).Select(x => x.CalculateCompletionScore()).ToList();
    }
    
    public static long GetMiddleScore(string input)
    {
        var navigationLines = input.Split("\r\n").Select(x=> new NavigationLine(x)).ToList();
        
        var orderedScores = CalculateCompletionScores(navigationLines).OrderBy(x => x).ToList();

        return orderedScores.ElementAt(orderedScores.Count() / 2);
    }
}