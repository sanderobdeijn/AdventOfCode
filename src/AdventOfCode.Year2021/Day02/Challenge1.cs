namespace AdventOfCode.Year2021.Day02;

public class Challenge1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString("Day02/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetHorizontalAndDepthMultiplied(input);
    }
}