namespace AdventOfCode.Year2021.Day06;

public class Example1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Example1>()}/Example1.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfLanternFishAfterDay(input, 80);
    }
}