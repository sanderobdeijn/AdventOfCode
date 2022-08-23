using AdventOfCode.Core;

namespace AdventOfCode.ConsoleRunner;

static class Program
{
    public static void Main()
    {
        // this is needed to load the assembly in memory so reflection can detect it.
        Console.WriteLine($"Load different year assemblies");
        Console.WriteLine($"Loaded year {Year2021.Config.Year}");
        Console.WriteLine();
        
        HiPerfTimer timer = new HiPerfTimer();

        var solvesGroupedPerYear = GetAllSolves()
            .GroupBy(GetYear)
            .OrderByDescending(x => x.Key)
            .ToList();

        // replace by choosing year later
        var solvesForYear = solvesGroupedPerYear.First();
        var solvesGroupedPerDay = solvesForYear.GroupBy(GetDay)
            .OrderBy(x => x.Key);
        
        var solvesForDayToRun = ShowAndSelectDayToRun(solvesGroupedPerDay);
        
        List<Type> solvesToRun = ShowAndSelectSolvesToRun(solvesForDayToRun);

        foreach (Type solve in solvesToRun)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine($"Solving {solve.Name} for Day {GetDay(solve)} Year {GetYear(solve)}");
            Console.WriteLine("=======================================");
            
            var puzzle = Activator.CreateInstance(solve) as ISolve;

            if (puzzle == null)
            {
                Console.WriteLine("Solve can't be instantiated");
                break;
            }
            
            timer.Start();
            object solution = puzzle.Solve();
            timer.Stop();

            var solutionText = solution.ToString() ?? "Solution can't be converted to text.";
            
            // TextCopy.ClipboardService.SetText(solutionText);

            Console.WriteLine("Solution: " + solutionText);
            Console.WriteLine("Duration: " + timer.DurationFormatted);
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    private static List<Type> ShowAndSelectSolvesToRun(IEnumerable<Type> solvesForDay)
    {
        var orderedSolvesForDay = solvesForDay.OrderBy(x => x.Name).ToList();
        List<Type> selectedSolves;
        
        while (true)
        {
            ShowSolves(orderedSolvesForDay);
            var selectedSolvesValue = Console.ReadLine();
            
            if (selectedSolvesValue == String.Empty)
            {
                selectedSolves = orderedSolvesForDay.ToList();
                Console.WriteLine($"Running all solves for day: Day { GetDay(selectedSolves.First()) }");
                break;
            }

            if (int.TryParse(selectedSolvesValue, out int parsedSelectedSolvesValue))
            {
                var selectedSolve = orderedSolvesForDay.ElementAtOrDefault(parsedSelectedSolvesValue - 1);

                if (selectedSolve is not null)
                {
                    selectedSolves = new List<Type> { selectedSolve };
                    Console.WriteLine($"Running solve: { selectedSolves.First().Name }");
                    break;
                }
            }
            Console.WriteLine($"Solve not found");
        }

        Console.WriteLine(selectedSolves.Count());
        return selectedSolves;
    }

    private static void ShowSolves(IEnumerable<Type> solvesForDay)
    {
        var enumeratedSolvesForDay = solvesForDay.ToList();
        
        Console.WriteLine($"Showing solves for day {GetYear(enumeratedSolvesForDay.First())}");

        for (int i = 1; i <= enumeratedSolvesForDay.Count(); i++)
        {
            Console.WriteLine($"{ i }: {enumeratedSolvesForDay.ElementAt(i - 1).Name}");
        }
        
        Console.WriteLine($"Select which solve to run. (empty means all)");
    }

    private static List<Type> ShowAndSelectDayToRun(IEnumerable<IGrouping<string, Type>> solvesGroupedPerDay)
    { 
        var enumeratedSolvesGroupedPerDay = solvesGroupedPerDay.ToList();
        
        IGrouping<string, Type>? solvesForSelectedDay;
        
        while (true)
        {
            ShowDaysForYear(enumeratedSolvesGroupedPerDay);

            Console.WriteLine($"Select which day to run. (empty means latest)");

            var selectedDayValue = Console.ReadLine();

            if (selectedDayValue == String.Empty)
            {
                solvesForSelectedDay = enumeratedSolvesGroupedPerDay.Last();
                Console.WriteLine($"Running latest day: Day {solvesForSelectedDay.Key}");
                break;
            }

            solvesForSelectedDay = enumeratedSolvesGroupedPerDay.FirstOrDefault(x => x.Key == selectedDayValue);

            if (solvesForSelectedDay is not null)
            {
                Console.WriteLine($"Running day {solvesForSelectedDay.Key}");
                break;
            }

            Console.WriteLine($"Day not found. Please try again.");
        }

        return solvesForSelectedDay.ToList();
    }

    private static void ShowDaysForYear(IEnumerable<IGrouping<string, Type>> solvesGroupedPerDay)
    {
        var enumeratedSolvesGroupedPerDay = solvesGroupedPerDay.ToList();
        
        Console.WriteLine($"Showing days for year {GetYear(enumeratedSolvesGroupedPerDay.First().First())}");

        foreach (var solvesForDay in enumeratedSolvesGroupedPerDay)
        {
            Console.WriteLine($"Day {solvesForDay.Key}");
        }
    }

    private static string GetYear(Type type)
    {
        return type.FullName?.Split('.')[1].Replace("Year","") ?? "No year found"; 
    }
    
    private static string GetDay(Type type)
    {
        return type.FullName?.Split('.')[2].Replace("Day","") ?? "No day found"; 
    }
    
    private static List<Type> GetAllSolves()
    {
        var solves = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            .Where(x => x.IsInterface is false && typeof(ISolve).IsAssignableFrom(x)).ToList();
        return solves;
    }
}