namespace AdventOfCode.Year2021.Day09;

public static class Solver
{
    public static int SumOfRiskLevelAtAllLowPoints(string input)
    {
        var points = GetPoints(input);
        
        var lowPoints = GetLowPoints(points);

        return lowPoints.Select(x => x.Value + 1).Sum();
    }
    
    private static List<Point> GetLowPoints(List<Point> points)
    {
        var lowPoints = new List<Point>();

        foreach (var point in points)
        {
            var adjacentPoints = points.Where(x => x.IsAdjacent(point));
            if(point.IsPointLowerThanAdjacentPoints(adjacentPoints))
            {
                lowPoints.Add(point);
            }
        }

        return lowPoints;
    }
    
    private static List<Point> GetPoints(string input)
    {
        var values = input.SplitLines().Select(x => x.Chunk(1).Select(y => int.Parse(y)).ToList()).ToList();

        var points = new List<Point>();

        for (var y = 0; y < values.Count; y++)
        {
            var row = values.ElementAt(y);
            for (var x = 0; x < row.Count; x++)
            {
                points.Add(new Point(x,y,row[x]));
            }
        }

        return points;
    }

    public static int Largest3BasinSizesMultiplied(string input)
    {
        var points = GetPoints(input);
        
        var basins = GetBasins(points);

        var largest3Basins = basins.Select(x => x.Count).OrderByDescending(x => x).Take(3);

        return largest3Basins.Aggregate((a, b) => a * b);
    }
    
    private static List<List<Point>> GetBasins(List<Point> points)
    {
        var basins = GetLowPoints(points).Select(x => new List<Point>() { x }).ToList();

        var basinNumbers = points.Where(x => x.Value != 9).ToList();

        for (var y = 0; y < basins.Count; y++)
        {
            var basin = basins.ElementAt(y);
            for (var i = 0; i < basin.Count; i++)
            {
                var adjacentPoints = basinNumbers.Where(x => basin.ElementAt(i).IsAdjacent(x)).ToList();
                basin.AddRange(adjacentPoints);

                for (var x = 0; x < adjacentPoints.Count(); x++)
                {
                    var adjacentPoint = adjacentPoints.ElementAt(x);
                    basinNumbers.Remove(adjacentPoint);
                }
            }

        }

        return basins.Select(x => x.Distinct().ToList()).ToList();
    }
}