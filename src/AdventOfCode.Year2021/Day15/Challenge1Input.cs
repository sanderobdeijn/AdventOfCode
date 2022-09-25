namespace AdventOfCode.Year2021.Day15;

public class Challenge1Input : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge1Input>()}/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetLowestRiskForAnyPathInSmallMap(input);
    }
}