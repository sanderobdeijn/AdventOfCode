namespace AdventOfCode.Year2022.Day04;

public class Challenge2Example : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge2Example>()}/Example.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfOverlappedSections(input);
    }
}