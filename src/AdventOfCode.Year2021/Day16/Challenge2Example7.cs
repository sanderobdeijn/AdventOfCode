namespace AdventOfCode.Year2021.Day16;

public class Challenge2Example7 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2Example7>()}/Challenge2Example7.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.CalculateTransmissonExpression(input);
    }
}