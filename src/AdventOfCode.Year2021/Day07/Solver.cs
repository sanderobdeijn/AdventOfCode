namespace AdventOfCode.Year2021.Day07;

public static class Solver
{
    public static int GetFuelCostForAlignment(string input, bool expensiveMode = false)
    {
        var crabs = GetCrabs(input);
        var range = GetStartingRange(crabs);

        while (range.Start.Value != range.End.Value)
        {
            range = ReduceRange(range, expensiveMode, crabs);
        }

        return CalculateFuelForMoveToPosition(range.Start.Value, expensiveMode, crabs);
    }

    private static Range GetStartingRange(List<Crab> crabs)
    {
        var minPosition = crabs.Min(x => x.Position);
        var maxPosition = crabs.Max(x => x.Position);

        var range = minPosition..maxPosition;
        return range;
    }

    private static List<Crab> GetCrabs(string input)
    {
        return input.Split(',').Select(x => int.Parse(x)).Select(x => new Crab(x)).OrderBy(x => x.Position).ToList();
    }
    
    private static IEnumerable<int> GetMeasurementPoints(Range range)
    {
        var measurementPoints = new List<int>();

        var minRange = range.Start.Value;
        var maxRange = range.End.Value;
        var length = maxRange - minRange;

        var measurementInterval = length / 4;
        if( measurementInterval == 0)
        {
            measurementInterval = 1;
        }

        for (var i = 0; true; i++)
        {
            var newMeasurementPoint = minRange + (i * measurementInterval);

            if (newMeasurementPoint >= maxRange)
            {
                measurementPoints.Add(maxRange);
                break;
            }

            measurementPoints.Add(newMeasurementPoint);
        }

        return measurementPoints.Distinct();
    }
    
    private static Range ReduceRange(Range range, bool expensiveMode, List<Crab> crabs)
    {
        var measumentPoints = GetMeasurementPoints(range);

        var measurements = measumentPoints.Select(x => (position: x, fuelConsuption: CalculateFuelForMoveToPosition(x, expensiveMode, crabs)));

        if(range.End.Value - range.Start.Value <= 5)
        {
            var lowestFuelConsumptionPosition = measurements.OrderBy(x => x.fuelConsuption).First().position;

            return lowestFuelConsumptionPosition..lowestFuelConsumptionPosition;
        }

        var positionsWithLowestFuelConsumption = measurements.OrderBy(x => x.fuelConsuption).Take(3).Select(x => x.position).ToList();

        return positionsWithLowestFuelConsumption.Min()..positionsWithLowestFuelConsumption.Max();
    }
    
    private static int CalculateFuelForMoveToPosition(int newPosition, bool expensiveMode, List<Crab> crabs)
    {
        if (expensiveMode)
        {
            return crabs.Select(x => x.CalculateFuelWithExpensiveModeForPosition(newPosition)).Sum();
        }

        return crabs.Select(x => x.CalculateFuelForPosition(newPosition)).Sum();
    }
}