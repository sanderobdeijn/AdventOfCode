using System.Text;

namespace AdventOfCode.Year2022.Day05;

public static class Solver
{
    public static object SolveWithSingleCrateMovement(string input)
    {
        var stacks = GetStacks(input);
        var instructions = GetInstructions(input);

        foreach (var instruction in instructions)
        {
            for (var i = 0; i < instruction.repeats; i++)
            {
                stacks[instruction.to].Push(stacks[instruction.from].Pop());
            }
        }

        var sb = new StringBuilder();
        foreach (var stack in stacks)
        {
            sb.Append(stack.Peek());
        }

        return sb.ToString();
    }

    public static object SolveWithMultipleCrateMovement(string input)
    {
        var stacks = GetStacks(input);
        var instructions = GetInstructions(input);

        foreach (var instruction in instructions)
        {
            var cratesToMove = new List<char>();
            for (var i = 0; i < instruction.repeats; i++)
            {
                cratesToMove.Add(stacks[instruction.from].Pop());
            }

            cratesToMove.Reverse();

            foreach (var crateToMove in cratesToMove)
            {
                stacks[instruction.to].Push(crateToMove);
            }
        }

        var sb = new StringBuilder();
        foreach (var stack in stacks)
        {
            sb.Append(stack.Peek());
        }

        return sb.ToString();
    }

    
    private static List<(int repeats, int from, int to)> GetInstructions(string input)
    {
        return input.SplitLines().Where(x => x.Contains("move")).Select(x => x.Split(" from ")).Select(x=> (int.Parse(x.First()[5..]), int.Parse(x.Last()[..1])-1, int.Parse(x.Last()[5..])-1)).ToList();
    }

    private static Stack<char>[] GetStacks(string input)
    {
        var stacksPerLayer = input.SplitLines().Where(x => x.Contains('[')).Select(x => x.Chunk(4).Select(x => string.Join("",x).Substring(1,1)).ToArray()).Reverse().ToArray();

        var stacks = new Stack<char>[stacksPerLayer[0].Length];
        foreach (var stackLayer in stacksPerLayer)
        {
            for (var s = 0; s < stackLayer.Length; s++)
            {
                stacks[s] ??= new Stack<char>();
                
                var possibleCrates = stackLayer[s].ToCharArray().First();
                if (possibleCrates != ' ')
                {
                    stacks[s].Push(possibleCrates);
                }
            }
        }

        return stacks;
    }
}