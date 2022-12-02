﻿namespace AdventOfCode.Year2022.Day02;

public class Challenge1Example : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge1Example>()}/Example.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.CalculateGamepointFirstStrategy(input);
    }
}