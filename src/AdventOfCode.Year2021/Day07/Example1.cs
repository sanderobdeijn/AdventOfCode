namespace AdventOfCode.Year2021.Day07;

public class Example1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Example1>()}/Example1.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetFuelCostForAlignment(input);
    }
}