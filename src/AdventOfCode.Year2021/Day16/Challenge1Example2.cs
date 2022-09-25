namespace AdventOfCode.Year2021.Day16;

public class Challenge1Example2 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge1Example2>()}/Challenge1Example2.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetSumOfAllVersions(input);
    }
}