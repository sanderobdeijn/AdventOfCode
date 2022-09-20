namespace AdventOfCode.Year2021.Day14;

public class Challenge1Example : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge1Example>()}/Example.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfMostCommonElementMinusNumberOfLeastCommonElementsAfterNumberOfSteps(input, 10);
    }
}