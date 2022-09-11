namespace AdventOfCode.Year2021.Day02;

public static class Solver
{
    private static List<MovementCommand> GetMovements(string input)
    {
        return input.Split("\r\n").Select(x => MovementCommand.FromString(x)).ToList();
    }

    public static int GetHorizontalAndDepthMultiplied(string input)
    {
        var movements = GetMovements(input);

        var totalForwardDistance = GetTotalDistanceForDirection(movements, MovementDirection.Forward);
        var totalDownDistance = GetTotalDistanceForDirection(movements, MovementDirection.Down);
        var totalUpDistance = GetTotalDistanceForDirection(movements, MovementDirection.Up);

        return (totalDownDistance - totalUpDistance) * totalForwardDistance;
    }

    private static int GetTotalDistanceForDirection(List<MovementCommand> movements,
        MovementDirection movementDirection)
    {
        return movements.Where(x => x.Direction == movementDirection).Sum(x => x.Distance);
    }

    public static int GetHorizontalAndDepthWithAimCalculationMultiplied(string input)
    {
        var movements = GetMovements(input);
        var totalForwardDistance = GetTotalDistanceForDirection(movements, MovementDirection.Forward);

        var totalDepth = GetDepthWithAimCalculation(movements);
        return totalDepth * totalForwardDistance;
    }

    private static int GetDepthWithAimCalculation(List<MovementCommand> movements)
    {
        var depth = 0;
        var aim = 0;

        foreach (var movement in movements)
            _ = movement.Direction switch
            {
                MovementDirection.Forward => depth += CalculateDepthMutation(movement.Distance, aim),
                MovementDirection.Down => aim += movement.Distance,
                MovementDirection.Up => aim -= movement.Distance,
                _ => throw new InvalidOperationException()
            };

        return depth;
    }

    public static int CalculateDepthMutation(int distance, int aim)
    {
        return distance * aim;
    }
}