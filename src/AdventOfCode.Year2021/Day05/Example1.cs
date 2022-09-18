namespace AdventOfCode.Year2021.Day05;

public class Example1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Example1>()}/Example.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfOverlappingPointsForOrthogonalClouds(input);
    }
}