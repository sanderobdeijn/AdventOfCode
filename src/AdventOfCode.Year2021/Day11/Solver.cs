namespace AdventOfCode.Year2021.Day11;

public static class Solver
{
    public static int GetTotalFlashesAfter100Steps(string input)
    {
        var startCavern = GetStartCavern(input);

        return GetTotalFlashesForSteps(startCavern, 100);
    }

    public static int GetFirstStepWhereAllOctopusesFlash(string input)
    {
        var startCavern = GetStartCavern(input);

        return GetStepWhereAllOctopiAreSynchronized(startCavern);
    }
    
    private static Cavern GetStartCavern(string input)
    {
        var values = input.SplitLines().Select(x => x.Chunk(1).Select(y => int.Parse(y)).ToList()).ToList();

        var octipi = new List<Octopus>();

        for (var y = 0; y < values.Count; y++)
        {
            var row = values.ElementAt(y);
            for (var x = 0; x < row.Count; x++)
            {
                octipi.Add(new Octopus(x, y, row[x]));
            }
        }

        return new Cavern(octipi);
    }
    
    private static int GetTotalFlashesForSteps(Cavern startCavern, int steps)
    {
        var cavern = startCavern;

        for (var i = 0; i < steps; i++)
        {
            cavern.NextStep();
        }

        return cavern.TotalFlashes;
    }
    
    public static int GetStepWhereAllOctopiAreSynchronized(Cavern startCavern)
    {
        var cavern = startCavern;

        var previousFlashes = 0;

        var step = 0;

        for (; true; step++)
        {
            cavern.NextStep();

            if(cavern.TotalFlashes - previousFlashes == 100)
            {
                step++;
                break;
            }

            previousFlashes = cavern.TotalFlashes;
        }

        return step;
    }
}