﻿namespace AdventOfCode.Year2021.Day03;

public class Challenge1 : ISolve
{
    public string Input => TextFileReader.ReadFileAsPasteableString($"Day{SolveHelper.GetDay<Challenge1>()}/Input.txt");

    public object Solve()
    {
        var input = Input;
        return Solver.GetPowerConsumption(input);
    }
}