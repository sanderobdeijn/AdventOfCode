using System.Diagnostics;

namespace AdventOfCode.Year2022.Day02;

public static class Solver
{
    private static List<string> GetStrategyGuide(string input)
    {
        return input.SplitLines().ToList();
    }
    
    public static object CalculateGamepointFirstStrategy(string input)
    {
        var strategyGuide = GetStrategyGuide(input);

        var groupedStategyGuide = strategyGuide.GroupBy(x => x);

        var score = 0;

        foreach (var strategy in groupedStategyGuide)
        {
            score += CalculateGameResult(strategy.Key) * strategy.Count();
            score += CalculateShapeResult(strategy.Key) * strategy.Count();
        }
        return score;
    }

    public static object CalculateGamepointSecondStrategy(string input)
    {
        var strategyGuide = GetStrategyGuide(input);

        var groupedStategyGuide = strategyGuide.GroupBy(x => x);

        var score = 0;

        foreach (var strategy in groupedStategyGuide)
        {
            var (result, shape) = GetGameResult(strategy.Key);
            score += (int)result * strategy.Count();
            score += (int)shape * strategy.Count();
        }
        return score;
    }

    private static (GameResult result, Shape shape) GetGameResult(string strategy)
    {
        return strategy switch
        {
            "A X" => (GameResult.Loss, Shape.Scissors),
            "B X" => (GameResult.Loss, Shape.Rock),
            "C X" => (GameResult.Loss, Shape.Paper),
            "A Y" => (GameResult.Draw, Shape.Rock),
            "B Y" => (GameResult.Draw, Shape.Paper),
            "C Y" => (GameResult.Draw, Shape.Scissors),
            "A Z" => (GameResult.Win, Shape.Paper),
            "B Z" => (GameResult.Win, Shape.Scissors),
            "C Z" => (GameResult.Win, Shape.Rock),
            _ => throw new InvalidOperationException()
        };
    }

    private static int CalculateShapeResult(string strategy)
    {
        return strategy.Substring(2) switch
        {
            "X" => (int)Shape.Rock,
            "Y" => (int)Shape.Paper,
            "Z" => (int)Shape.Scissors,
            _ => throw new InvalidOperationException()
        };
    }

    private static int CalculateGameResult(string strategy)
    {
        return strategy switch
        {
            "A Y" => (int)GameResult.Win,
            "B Z" => (int)GameResult.Win,
            "C X" => (int)GameResult.Win,
            "A Z" => (int)GameResult.Loss,
            "B X" => (int)GameResult.Loss,
            "C Y" => (int)GameResult.Loss,
            "A X" => (int)GameResult.Draw,
            "B Y" => (int)GameResult.Draw,
            "C Z" => (int)GameResult.Draw,
            _ => throw new InvalidOperationException()
        };
    }
}