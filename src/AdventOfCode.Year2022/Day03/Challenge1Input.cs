namespace AdventOfCode.Year2022.Day03;

public class Challenge1Input : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge1Input>()}/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetPriorityOfWrongItem(input);
    }
}
