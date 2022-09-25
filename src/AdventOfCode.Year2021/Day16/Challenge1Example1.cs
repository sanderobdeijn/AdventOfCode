namespace AdventOfCode.Year2021.Day16;

public class Challenge1Example1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge1Example1>()}/Challenge1Example1.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetSumOfAllVersions(input);
    }
}