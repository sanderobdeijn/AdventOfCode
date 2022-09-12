namespace AdventOfCode.Year2021.Day06;

public class Challenge2 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2>()}/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfLanternFishAfterDay(input, 256);
    }
}