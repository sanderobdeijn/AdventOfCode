namespace AdventOfCode.Year2022.Day04;

public static class Solver
{
    public static object GetNumberOfContainedSections(string input)
    {
        var sectionPairs = GetSectionPairs(input);
        var numberOfContainedSections = 0;

        foreach (var sectionPair in sectionPairs)
        {
            if (sectionPair[0].Contains(sectionPair[1]) || sectionPair[1].Contains(sectionPair[0]))
            {
                numberOfContainedSections++;
            }
        }
        
        return numberOfContainedSections;
    }

    public static object GetNumberOfOverlappedSections(string input)
    {
        var sectionPairs = GetSectionPairs(input);
        var numberOfOverlappedSections = 0;

        foreach (var sectionPair in sectionPairs)
        {
            if (sectionPair[0].Overlaps(sectionPair[1]) || sectionPair[1].Overlaps(sectionPair[0]))
            {
                numberOfOverlappedSections++;
            }
        }
        
        return numberOfOverlappedSections;
    }
    
    private static List<Range[]> GetSectionPairs(string input)
    {
        return input.SplitLines().Select(x => x.Split(',').Select(ParseRange).ToArray()).ToList();
    }

    private static Range ParseRange(string range)
    {
        var rangeNumbers = range.Split('-').Select(int.Parse).ToArray();
        return new Range(rangeNumbers[0], rangeNumbers[1]);
    }
}