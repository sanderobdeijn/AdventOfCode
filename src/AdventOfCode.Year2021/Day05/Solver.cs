namespace AdventOfCode.Year2021.Day05;

public static class Solver
{
    public static int GetNumberOfOverlappingPointsForOrthogonalClouds(string input)
    {
        List<Line2D> clouds = GetClouds(input);

        List<Line2D> orthogonalClouds = GetOrthogonalClouds(clouds);
        
        List<Point2D> orthogonalPoints = GetAllPointsIncludingIntermediateForClouds(orthogonalClouds);

        return GetOverlappingPoints(orthogonalPoints).Count();
    }
    
    public static int GetNumberOfOverlappingPoints(string input)
    {
        List<Line2D> clouds = GetClouds(input);

        List<Point2D> points = GetAllPointsIncludingIntermediateForClouds(clouds);

        return GetOverlappingPoints(points).Count();
    }

    private static List<Point2D> GetOverlappingPoints(List<Point2D> points)
    {
        var groupedPoints = points.GroupBy(x => x);
        var overlappingPoints = groupedPoints.Where(x => x.Count() > 1);

        return overlappingPoints.Select(x => x.Key).ToList();
    }

    private static List<Point2D> GetAllPointsIncludingIntermediateForClouds(List<Line2D> clouds)
    {
        return clouds.SelectMany(x => x.GetAllPointsIncludingIntermediates()).ToList();
    }

    private static List<Line2D> GetOrthogonalClouds(List<Line2D> clouds)
    {
        return clouds.Where(x => x.IsHorizontal || x.IsVertical).ToList();
    }
    
    private static List<Line2D> GetClouds(string input)
    {
        return input.Split("\r\n").Select(x => ParseStringToLine(x)).ToList();
    }
    
    private static Line2D ParseStringToLine(string lineCoordidateString)
    {
        var points = lineCoordidateString.Split(" -> ").Select(x => PointFromString(x));

        return new Line2D(points.First(), points.Last());
    }
    
    private static Point2D PointFromString(string point)
    {
        var coordinates = point.Split(',').Select(x => int.Parse(x));

        return new Point2D(coordinates.First(), coordinates.Last());
    }
}