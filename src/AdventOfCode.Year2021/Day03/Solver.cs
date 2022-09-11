namespace AdventOfCode.Year2021.Day03;

public static class Solver
{
    public static int GetPowerConsumption(string input)
    {
        var diagnosticReports = GetDiagnosticReports(input);

        var bitsGroupedByPosition = GetBitsGroupedByPosition(diagnosticReports);

        var mostCommonBits = GetMostCommonBits(bitsGroupedByPosition);
        var leastCommonBits = GetLeastCommonBits(bitsGroupedByPosition);

        return GetEpsilonRate(bitsGroupedByPosition, leastCommonBits) *
               GetGammaRate(bitsGroupedByPosition, mostCommonBits);
    }

    private static int GetEpsilonRate(IEnumerable<IEnumerable<char>> bitsGroupedByPosition, string leastCommonBits)
    {
        return Convert.ToInt32(leastCommonBits, 2);
    }

    private static int GetGammaRate(IEnumerable<IEnumerable<char>> bitsGroupedByPosition, string mostCommonBits)
    {
        return Convert.ToInt32(mostCommonBits, 2);
    }

    private static string GetMostCommonBits(IEnumerable<IEnumerable<char>> bitsGroupedByPosition)
    {
        var mostCommonBits = new List<string>();

        foreach (var bits in bitsGroupedByPosition) mostCommonBits.Add(GetMostCommonBit(bits));

        return string.Join("", mostCommonBits);
    }

    private static string GetMostCommonBit(IEnumerable<char> bits)
    {
        return bits.Where(x => x == '0').Count() > bits.Where(x => x == '1').Count() ? "0" : "1";
    }

    private static string GetLeastCommonBits(IEnumerable<IEnumerable<char>> bitsGroupedByPosition)
    {
        var mostCommonBits = new List<string>();

        foreach (var bits in bitsGroupedByPosition) mostCommonBits.Add(GetLeastCommonBit(bits));

        return string.Join("", mostCommonBits);
    }

    private static string GetLeastCommonBit(IEnumerable<char> bits)
    {
        return bits.Where(x => x == '0').Count() <= bits.Where(x => x == '1').Count() ? "0" : "1";
    }

    private static List<List<char>> GetBitsGroupedByPosition(List<string> diagnosticReports)
    {
        var bitsMatrix = new List<char>[diagnosticReports.First().Length];

        for (var i = 0; i < bitsMatrix.Length; i++) bitsMatrix[i] = new List<char>();

        foreach (var diagnosticReport in diagnosticReports)
        {
            var diagnosticReportArray = diagnosticReport.ToArray();

            for (var i = 0; i < diagnosticReport.Length; i++) bitsMatrix[i].Add(diagnosticReportArray[i]);
        }

        return bitsMatrix.ToList();
    }

    private static List<string> GetDiagnosticReports(string input)
    {
        return input.Split("\r\n").ToList();
    }

    public static int GetLifeSupportRating(string input)
    {
        var diagnosticReports = GetDiagnosticReports(input);

        var bitsGroupedByPosition = GetBitsGroupedByPosition(diagnosticReports);

        var mostCommonBits = GetMostCommonBits(bitsGroupedByPosition);
        var leastCommonBits = GetLeastCommonBits(bitsGroupedByPosition);

        return GetOxygenGeneratorRating(diagnosticReports) * GetCO2ScrubberRating(diagnosticReports);
    }

    private static int GetCO2ScrubberRating(List<string> diagnosticReports)
    {
        var oxygenDiagnosticReports = diagnosticReports;

        for (var i = 0; i < diagnosticReports.First().Length; i++)
        {
            var bitsGroupedByPosition = GetBitsGroupedByPosition(oxygenDiagnosticReports);
            var leastCommonBits = GetLeastCommonBits(bitsGroupedByPosition);

            var leastCommonBit = leastCommonBits[i];
            oxygenDiagnosticReports = oxygenDiagnosticReports.Where(x => x[i] == leastCommonBit).ToList();

            if (oxygenDiagnosticReports.Count == 1) break;
        }

        return Convert.ToInt32(oxygenDiagnosticReports.First(), 2);
    }

    private static int GetOxygenGeneratorRating(List<string> diagnosticReports)
    {
        var oxygenDiagnosticReports = diagnosticReports;

        for (var i = 0; i < diagnosticReports.First().Length; i++)
        {
            var bitsGroupedByPosition = GetBitsGroupedByPosition(oxygenDiagnosticReports);
            var mostCommonBits = GetMostCommonBits(bitsGroupedByPosition);

            var mostCommonBit = mostCommonBits[i];
            oxygenDiagnosticReports = oxygenDiagnosticReports.Where(x => x[i] == mostCommonBit).ToList();

            if (oxygenDiagnosticReports.Count == 1) break;
        }

        return Convert.ToInt32(oxygenDiagnosticReports.First(), 2);
    }
}