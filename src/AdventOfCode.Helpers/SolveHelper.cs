namespace AdventOfCode.Helpers;

public static class SolveHelper
{
    public static string GetYear(Type type)
    {
        return type.FullName?.Split('.')[1].Replace("Year", "") ?? "No year found";
    }
    public static string GetYear<T>()
    {
        return GetYear(typeof(T));
    }

    public static string GetDay(Type type)
    {
        return type.FullName?.Split('.')[2].Replace("Day", "") ?? "No day found";
    }
    
    public static string GetDay<T>()
    {
        return GetDay(typeof(T));
    }
}