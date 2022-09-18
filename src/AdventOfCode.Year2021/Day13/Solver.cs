using System.Text;

namespace AdventOfCode.Year2021.Day13;

public static class Solver
{
    public static int GetNumberOfDotsAfterFirstFold(string input)
    {
        Sheet sheet = GetSheet(input);
        List<string> foldInstructions = GetFoldInstructions(input);
        
        var foldedSheet = FoldSheetAccordingToInstruction(sheet, foldInstructions.First());

        return foldedSheet.NumberOfDots;
    }

    public static string GetCodeAfterAllFolds(string input)
    {
        Sheet sheet = GetSheet(input);
        List<string> foldInstructions = GetFoldInstructions(input);
        
        var foldedSheet = sheet;
        foreach(var foldInstruction in foldInstructions)
        {
            foldedSheet = FoldSheetAccordingToInstruction(foldedSheet, foldInstruction);
        }

        var sb = new StringBuilder();
        sb.AppendLine();

        for (var i = 0; i < foldedSheet.Dots.GetColumn(0).Count(); i++)
        {
            sb.AppendLine(string.Join(string.Empty, foldedSheet.Dots.GetRow(i).Select(x => x ? "X" : " ")));
        }

        return sb.ToString();
    }
    
    private static Sheet FoldSheetAccordingToInstruction(Sheet sheet, string foldingInstruction)
    {
        var direction = foldingInstruction.Split('=').First();
        var position = int.Parse(foldingInstruction.Split('=').Last());

        if(direction.Contains('x'))
        {
            return sheet.FoldHorizontal(position);
        }
        return sheet.FoldVertical(position);
    }

    private static List<string> GetFoldInstructions(string input)
    {
        return input.SplitLines().Where(x => x.Contains('f')).ToList();
    }

    private static Sheet GetSheet(string input)
    {
        return new Sheet(input.SplitLines().Where(x => x.Contains(',')).ToList());
    }
}