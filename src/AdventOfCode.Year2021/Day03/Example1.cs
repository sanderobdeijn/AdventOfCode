namespace AdventOfCode.Year2021.Day03;

public class Example1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString("Day03/Example1.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetPowerConsumption(input);
    }
}