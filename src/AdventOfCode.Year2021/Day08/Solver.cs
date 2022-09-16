namespace AdventOfCode.Year2021.Day08;

public static class Solver
{
    public static int TotalNumberOf1_4_7_8(string input)
    {
        var decoders = input.Split("\r\n").Select(x => new Decoder(x.Split('|').First().Trim().Split(' ').ToList(), x.Split('|').Last().Trim().Split(' ').ToList())).ToList();
        
        var allDecodedSignals = GetDecodedSignals(decoders);

        return allDecodedSignals.Count(x => x == "1" | x == "4" | x == "7" | x == "8");
    }
    
    private static List<string> GetDecodedSignals(List<Decoder> decoders)
    {
        return decoders.SelectMany(x => x.GetDecodedSignals()).ToList();
    }

    public static int SumOfAllDecodedValues(string input)
    {
        var decoders = input.Split("\r\n").Select(x => new Decoder(x.Split('|').First().Trim().Split(' ').ToList(), x.Split('|').Last().Trim().Split(' ').ToList())).ToList();
        
        return decoders.Sum(x => x.GetOutputValue());
    }
}