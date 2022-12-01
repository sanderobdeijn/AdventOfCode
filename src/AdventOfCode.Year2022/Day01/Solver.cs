using System.Globalization;

namespace AdventOfCode.Year2022.Day01;

public static class Solver
{
    public static object GetMaxCalories(string input)
    {
        var foodPerElf = GetFoodPerElf(input);

        return foodPerElf.Max(x => x.Sum());
    }

    public static object GetTop3Calories(string input)
    {
        var foodPerElf = GetFoodPerElf(input);

        return foodPerElf.Select(x => x.Sum()).OrderDescending().Take(3).Sum();
    }
    
    private static List<List<int>> GetFoodPerElf(string input)
    {
        var foodPerElf = new List<List<int>>();
        var food = GetFood(input);
        for (int i = 0; i < food.Count;)
        {
            var indexNextElf = food.IndexOf("",i);
            if (indexNextElf == -1)
            {
                foodPerElf.Add(food.GetRange(i, food.Count - i).Select(x => int.Parse(x)).ToList());
                break;
            }
            
            foodPerElf.Add(food.GetRange(i, indexNextElf - i).Select(x => int.Parse(x)).ToList());
            
            i = indexNextElf + 1;
        }        
        return foodPerElf;
    }

    private static List<string> GetFood(string input)
    {
        return input.SplitLines().ToList();
    }
}