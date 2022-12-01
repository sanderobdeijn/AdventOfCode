using System.Text.RegularExpressions;

namespace AdventOfCode.Year2021.Day18;

public static class Solver
{
    public static object GetMagnitudeOfInput(string input)
    {
        var snailFishNumbers = GetSnailFishNumbers(input);

        return CalculateMagnitude(Add(snailFishNumbers));
    }
    
    public static object GetLargestMagnitudeOfInput(string input)
    {
        var snailFishNumbers = GetSnailFishNumbers(input);
        
        int maxMagnitude = 0;

        for (int x = 0; x < snailFishNumbers.Count; x++)
        {
            for (int y = 0; y < snailFishNumbers.Count; y++)
            {
                var magnitude = CalculateMagnitude(Add(snailFishNumbers[x],snailFishNumbers[y]));
                maxMagnitude = Math.Max(magnitude, maxMagnitude);
            }
        }

        return maxMagnitude;
    }

    public static int CalculateMagnitude(string addedSnailFishNumbers)
    {
        var regex = new Regex(@"\[(?<left>\d+),(?<right>\d+)\]");
        do
        {
            var matches = regex.Matches(addedSnailFishNumbers);
            foreach (Match match in matches)
            {
                var magnitude = CalculateMagnitude(match);
                addedSnailFishNumbers = addedSnailFishNumbers.Replace(match.Value, magnitude.ToString());
            }

            if (matches.Count == 0)
            {
                break;
            }
        } while (true);

        return int.Parse(addedSnailFishNumbers);
    }

    private static int CalculateMagnitude(Match match)
    {
        int left = int.Parse(match.Groups["left"].Value);
        int right = int.Parse(match.Groups["right"].Value);

        return left * 3 + right * 2;
    }

    private static List<string> GetSnailFishNumbers(string input)
    {
        return input.SplitLines().ToList();
    }

    public static string Add(List<string> snailFishNumbers)
    {
        var addedSnailFishNumber = snailFishNumbers.First();
        for (int i = 1; i < snailFishNumbers.Count; i++)
        {
            addedSnailFishNumber = Add(addedSnailFishNumber, snailFishNumbers.ElementAt(i));
        }

        return addedSnailFishNumber;
    }

    public static string Add(string a, string b) => Reduce($"[{a},{b}]");

    private static string Reduce(string snailFishNumber)
    {
        do
        {
        } while (Explode(ref snailFishNumber) || Split(ref snailFishNumber));

        return snailFishNumber;
    }

    public static bool Split(ref string snailFishNumber)
    {
        var regex = new Regex(@"\d+");
        var matches = regex.Matches(snailFishNumber);
        var match = matches.FirstOrDefault(x => int.Parse(x.Value) >= 10);
        
        if (match == null)
        {
            return false;
        }
        else
        {
            var numberToSplit = int.Parse(match.Value);
            var leftnumber = Math.Floor(numberToSplit / 2.0);
            var rightnumber = Math.Ceiling(numberToSplit / 2.0);

            snailFishNumber = snailFishNumber.Remove(match.Index, match.Length);
            snailFishNumber = snailFishNumber.Insert(match.Index, $"[{leftnumber},{rightnumber}]");

            return true;
        }
    }

    public static bool Explode(ref string snailFishNumber)
    {
        var openBraces = 0;
        for (int i = 0; i < snailFishNumber.Length; i++)
        {
            openBraces += MutateBraceCount(snailFishNumber[i]);

            if (openBraces == 5)
            {
                var (leftExplodedNumber, rightExplodedNumber, numberPairToExplode) = GetExplodedNumbers(snailFishNumber, i);

                snailFishNumber = snailFishNumber.Remove(i, numberPairToExplode.Length);
                
                var regex = new Regex(@"\d+");
                var rightMatches = regex.Matches(snailFishNumber[i..]);
                if (rightMatches.Any())
                {
                    var match = rightMatches.First();
                    var newNumber = int.Parse(match.Value) + rightExplodedNumber;

                    snailFishNumber = snailFishNumber.Remove(i + match.Index, match.Length);
                    snailFishNumber = snailFishNumber.Insert(i + match.Index, newNumber.ToString());
                }
                
                var leftMatches = regex.Matches(snailFishNumber[..i]);
                if (leftMatches.Any())
                {
                    var match = leftMatches.Last();
                    var newNumber = int.Parse(match.Value) + leftExplodedNumber;

                    snailFishNumber = snailFishNumber.Remove(match.Index, match.Length);
                    snailFishNumber = snailFishNumber.Insert(match.Index, newNumber.ToString());
                }
                
                // set zero's
                snailFishNumber = snailFishNumber.Replace("[,", "[0,");
                snailFishNumber = snailFishNumber.Replace(",]", ",0]");
                
                return true;
            }
        }

        return false;
    }

    private static (int leftExplodedNumber, int rightExplodedNumber, string numberPairToExplode) GetExplodedNumbers(string snailFishNumber, int nestedBraceIndex)
    {
        var regex = new Regex(@"\[(?<left>\d+),(?<right>\d+)\]");
        var match = regex.Match(snailFishNumber, nestedBraceIndex);

        int left = int.Parse(match.Groups["left"].Value);
        int right = int.Parse(match.Groups["right"].Value);
        
        return (left, right, match.Value);
    }
    
    private static int MutateBraceCount(char c)
    {
        return c switch
        {
            '[' => 1,
            ']' => -1,
            _ => 0
        };
    }
}