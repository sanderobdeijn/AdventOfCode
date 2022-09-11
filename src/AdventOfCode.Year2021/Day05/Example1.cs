namespace AdventOfCode.Year2021.Day05;

public class Example1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2>()}/Example1.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfOverlappingPointsForOrthogonalClouds(input);
    }
}