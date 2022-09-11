namespace AdventOfCode.Year2021.Day04;

public class Challenge1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString("Day04/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetSumOfUnmarkedNumbersMultipliedWithLastNumberForWinningBoard(input);
    }
}