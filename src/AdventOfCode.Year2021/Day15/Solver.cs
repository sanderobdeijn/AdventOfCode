﻿using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace AdventOfCode.Year2021.Day15;

public static class Solver
{
    public static int GetLowestRiskForAnyPathInSmallMap(string input)
    {
        var riskLevels = GetRiskLevels(input);
        
        var graph = LoadDijkstraGraph(riskLevels);
        
        var result = graph.Dijkstra(1, (uint)riskLevels.Length * (uint)riskLevels[0].Length);

        return result.Distance;
    }

    private static int[][] GetRiskLevels(string input)
    {
        return input.SplitLines().Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
    }

    private static Graph<Point, int> LoadDijkstraGraph(int[][] riskLevels)
    {
        var graph = new Graph<Point, int>();

        var maxX = riskLevels[0].Length;
        var maxY = riskLevels.Length;

        for (var row = 0; row < maxX; row++)
        {
            for (var col = 0; col < maxY; col++)
            {
                graph.AddNode(new Point(col, row));
            }
        }

        for (var row = 0; row < maxX; row++)
        {
            for (var col = 0; col < maxY; col++)
            {
                var current = NodeNumber(row, col, maxX);

                foreach (var n in Neighbors(row, col, maxX))
                {
                    var neighbor = NodeNumber(n.Y, n.X, maxX);

                    // the cost of the edge to a neighbouring cell is the risk level
                    // of the neighbouring cell
                    var cost = riskLevels[n.Y][n.X];

                    graph.Connect(current, neighbor, cost, 0);
                }

            }
        }

        return graph;
    }
    
    private static uint NodeNumber(int row, int col, int maxSize)
    {
        return (uint)(row * maxSize + col + 1);
    }
    
    private static IEnumerable<Point> Neighbors(int row, int col, int maxsize)
    {
        List<Point> neighbours = new()
        {
            new Point(col,row - 1),
            new Point(col + 1, row),
            new Point(col,row + 1),
            new Point(col - 1, row)
        };

        // exclude coordinates that are off the map
        return neighbours
            .Where(n => n.X >= 0 && n.X < maxsize
                                 && n.Y >= 0 && n.Y < maxsize)
            .ToList();
    }
    
    public static int GetLowestRiskForAnyPathInLargeMap(string input)
    {
        var riskLevels = GetRiskLevels(input);
        
        var expandedRiskLevels = GetExpandedRiskLevels(riskLevels);

        var graph = LoadDijkstraGraph(expandedRiskLevels);

        var result = graph.Dijkstra(1, (uint)expandedRiskLevels.Length * (uint)expandedRiskLevels[0].Length);

        return result.Distance;
    }
    
    public static int[][] GetExpandedRiskLevels(int[][] riskLevels)
    {
        var maxX = riskLevels[0].Length;
        var newMaxX = maxX * 5;
        var maxY = riskLevels.Length;
        var newMaxY = maxY * 5;

        var expandedRiskLevels = new int[newMaxY][];

        for (var y = 0; y < newMaxY; y++)
        {
            var originalY = y % maxY;
            var yRiskIncreasor = y / maxY;
            expandedRiskLevels[y] = new int[newMaxX];

            for (var x = 0; x < newMaxX; x++)
            {
                var originalX = x % maxX;
                var xRiskIncreasor = x / maxX;

                var originalValue = riskLevels[originalY][originalX];

                var newValue = (originalValue + xRiskIncreasor + yRiskIncreasor);
                if (newValue > 9)
                {
                    newValue %= 9;
                }

                expandedRiskLevels[y][x] = newValue;
            }
        }

        return expandedRiskLevels;
    }
}