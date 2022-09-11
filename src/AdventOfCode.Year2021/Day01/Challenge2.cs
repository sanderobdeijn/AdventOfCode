namespace AdventOfCode.Year2021.Day01;

public class Challenge2 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString("Day01/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfIncreasedDepthsWithSlidingWindow(input);
    }
}