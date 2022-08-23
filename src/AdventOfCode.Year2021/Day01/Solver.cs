namespace AdventOfCode.Year2021.Day01;

public static class Solver
{
    private static List<int> GetDepths(string input)
    {
        return input.Split("\r\n").Select(x => int.Parse(x)).ToList();
    }

    public static int GetNumberOfIncreasedDepths(string input)
    {
        var depths = GetDepths(input);
        
        var numberOfIncreasedDepths = 0;

        for (var i = 0; i < depths.Count-1; i++)
        {
            var comparisonA = depths.ElementAt(i);
            var comparisonB = depths.ElementAt(i+1);

            if (IsDepthIncreasing(comparisonA, comparisonB))
            {
                numberOfIncreasedDepths++;
            }
        }

        return numberOfIncreasedDepths;
    }
    
    private static bool IsDepthIncreasing(int comparisonA, int comparisonB)
    {
        return comparisonA < comparisonB;
    }

    public static object GetNumberOfIncreasedDepthsWithSlidingWindow(string input)
    {
        var depths = GetDepths(input);
        
        var numberOfIncreasedDepths = 0;

        for (var i = 0; i < depths.Count-3; i++)
        {
            var comparisonA = depths.GetRange(i, 3).Sum();
            var comparisonB = depths.GetRange(i+1, 3).Sum();

            if (IsDepthIncreasing(comparisonA, comparisonB))
            {
                numberOfIncreasedDepths++;
            }
        }

        return numberOfIncreasedDepths;
    }
}