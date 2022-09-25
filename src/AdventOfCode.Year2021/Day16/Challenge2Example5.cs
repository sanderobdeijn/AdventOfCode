namespace AdventOfCode.Year2021.Day16;

public class Challenge2Example5 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2Example5>()}/Challenge2Example5.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.CalculateTransmissonExpression(input);
    }
}