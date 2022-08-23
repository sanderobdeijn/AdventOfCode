namespace AdventOfCode.Year2021.Day01;

public class Example1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString("Day01/Example1.txt");
    
    public object Solve()
    {
        var input = Input;
        return Solver.GetNumberOfIncreasedDepths(input);
    }
}