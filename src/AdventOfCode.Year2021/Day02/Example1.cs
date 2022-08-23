namespace AdventOfCode.Year2021.Day02;

public class Example1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString("Day02/Example1.txt");
    
    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfIncreasedDepths(input);
    }
}