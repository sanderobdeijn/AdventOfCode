namespace AdventOfCode.Year2022.Day03;

public static class Solver
{
    public static object GetPriorityOfBadge(string input)
    {
        var rucksacks = GetRucksacks(input).Select(x => x.compartmentA.Concat(x.CompartmentB).Distinct().ToList()).ToList();
        var groupsOfRucksacks = rucksacks.Chunk(3).ToList();

        var badges = groupsOfRucksacks.Select(groupOfRucksacks => groupOfRucksacks.First().Intersect(groupOfRucksacks.ElementAt(1)).Intersect(groupOfRucksacks.Last()).First()).ToList();

        return badges.Sum(GetPriority);
    }
    
    public static object GetPriorityOfWrongItem(string input)
    {
        var rucksacks = GetRucksacks(input);

        var sum = 0;
        foreach (var rucksack in rucksacks)
        {
            var doubleItems = rucksack.compartmentA.Intersect(rucksack.CompartmentB);
            if (doubleItems.Count() != 1)
            {
            }
            var doubleItem = doubleItems.First();
            sum += GetPriority(doubleItem);
        }

        return sum;
    }

    private static int GetPriority(char doubleItem)
    {
        var charValue = (int)doubleItem;
        if ((int)'a' <= charValue)
        {
            return charValue - 96;
        }

        return charValue - 64 + 26;
    }

    private static List<(List<char> compartmentA, List<char> CompartmentB)> GetRucksacks(string input)
    {
        return input.SplitLines().Select(x => x.ToCharArray().ToList()).Select(SplitCompartments).ToList();
    }

    private static (List<char> compartmentA, List<char> CompartmentB) SplitCompartments(List<char> items)
    {
        var center = items.Count / 2;
        var rucksack = (items.GetRange(0,center).Distinct().ToList(), items.GetRange(center, items.Count-center).Distinct().ToList());
        return rucksack;
    }
}