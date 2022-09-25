namespace AdventOfCode.Year2021.Day17;

public class Challenge2Example : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2Example>()}/Example.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfDifferentVelocitiesWithValidLaunch(input);
    }
}