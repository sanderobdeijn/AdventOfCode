namespace AdventOfCode.Year2021.Day16;

public class Challenge2Example8 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2Example8>()}/Challenge2Example8.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.CalculateTransmissonExpression(input);
    }
}