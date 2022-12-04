namespace AdventOfCode.Year2022.Day03;

public class Challenge2Input : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2Input>()}/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetPriorityOfBadge(input);
    }
}