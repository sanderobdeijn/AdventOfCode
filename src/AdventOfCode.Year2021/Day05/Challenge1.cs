namespace AdventOfCode.Year2021.Day05;

public class Challenge1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2>()}/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfOverlappingPointsForOrthogonalClouds(input);
    }
}