namespace AdventOfCode.Year2021.Day17;

public static class Solver
{
    public static int GetHighestYPositionForValidLaunch(string input)
    {
        var target = GetTarget(input);
        
        var minXVelocity = 1;
        var maxXVelocity = target.End.X;
        var minYVelocity = 1;
        var maxYVelocity = 250;

        var highestPoint = 0;

        foreach (var y in Enumerable.Range(minYVelocity, maxYVelocity))
        {
            foreach (var x in Enumerable.Range(minXVelocity, maxXVelocity))
            {
                (int X, int Y) position = (0, 0);
                (int X, int Y) velocity = (x, y);
                var maxY = 0;

                do
                {
                    position = (position.X + velocity.X, position.Y + velocity.Y);

                    maxY = Math.Max(maxY, position.Y);

                    if (target.Start.X <= position.X && position.X <= target.End.X && target.Start.Y <= position.Y && position.Y <= target.End.Y)
                    {
                        highestPoint = Math.Max(highestPoint, maxY);
                        break;
                    }

                    velocity = (X: Math.Max(0, Math.Abs(velocity.X) - 1), Y: velocity.Y - 1);
                } while (position.X <= target.End.X && position.Y >= target.Start.Y);
            }
        }

        return highestPoint;
    }

    private static ((int X, int Y) Start, (int X, int Y) End) GetTarget(string input)
    {
        var values = input[15..].Split(", y=").Select(x => x.Split("..").Select(int.Parse)).ToList();

        return ((values.First().First(), values.Last().First()), (values.First().Last(), values.Last().Last()));
    }

    public static int GetNumberOfDifferentVelocitiesWithValidLaunch(string input)
    {
        var target = GetTarget(input);
        
        var minXVelocity = 1;
        var maxXVelocity = target.End.X;
        var minYVelocity = -1000;
        var maxYVelocity = 1000;

        var succesfulLaunches = 0;

        foreach (var y in Enumerable.Range(minYVelocity, maxYVelocity * 2))
        {
            foreach (var x in Enumerable.Range(minXVelocity, maxXVelocity * 2))
            {
                (int X, int Y) position = (0, 0);
                (int X, int Y) velocity = (x, y);
                var maxY = 0;

                do
                {
                    position = (position.X + velocity.X, position.Y + velocity.Y);

                    maxY = Math.Max(maxY, position.Y);

                    if (target.Start.X <= position.X && position.X <= target.End.X && target.Start.Y <= position.Y && position.Y <= target.End.Y)
                    {
                        succesfulLaunches++;
                        break;
                    }

                    velocity = (X: Math.Max(0, Math.Abs(velocity.X) - 1), Y: velocity.Y - 1);
                } while (position.X <= target.End.X && position.Y >= target.Start.Y);
            }
        }

        return succesfulLaunches;
    }
}