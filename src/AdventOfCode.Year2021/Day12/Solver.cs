namespace AdventOfCode.Year2021.Day12;

public static class Solver
{
    public static int GetNumberOfPathsThatVisitSmallCavesMaxTimes(string input, int maxNumberOfVisitsInSmallCaves)
    {
        var nodes = GetNodes(input);

        return maxNumberOfVisitsInSmallCaves switch
        {
            1 => FindRoutesWhileVisitingASingleSmallCaveOnce(nodes),
            2 => FindRoutesWhileVisitingASingleSmallCaveTwice(nodes),
            _ => throw new ArgumentOutOfRangeException(nameof(maxNumberOfVisitsInSmallCaves), maxNumberOfVisitsInSmallCaves, null)
        };

    }
    
    private static int FindRoutesWhileVisitingASingleSmallCaveTwice(List<Node> nodes)
    {
        var startNode = nodes.First(x => x.Type == NodeType.Start);

        var endedRoutes = 0;
        var routes = new List<Route> { new Route(startNode) };

        //for (int i = 0; i < 50000; i++)
        while (routes.Any(x => x.ReachedEnd == false))
        {
            if(routes.All(x => x.ReachedEnd))
            {
                break;
            }

            var firstNotEndedRoute = routes.Last(x => x.ReachedEnd == false);
            var newRoutes = firstNotEndedRoute.GetNewRoutesWhileVisitingASingleSmallCaveTwice();
            if (newRoutes != null)
            {
                if (newRoutes.Count == 0)
                {
                    routes.Remove(firstNotEndedRoute);
                }
                else
                {
                    routes.Remove(firstNotEndedRoute);

                    routes.AddRange(newRoutes.Except(routes));
                }
            }

            var newEndedRoutes = routes.Where(x=> x.ReachedEnd).ToList();
            endedRoutes += newEndedRoutes.Count;

            for (var y = 0; y < newEndedRoutes.Count; y++)
            {
                routes.Remove(newEndedRoutes.ElementAt(y));
            }
        }

        return endedRoutes;
    }
    
    private static int FindRoutesWhileVisitingASingleSmallCaveOnce(List<Node> nodes)
    {
        var startNode = nodes.First(x => x.Type == NodeType.Start);
        var routes = new List<Route> { new Route(startNode) };

        while(routes.Any(x => x.ReachedEnd == false))
        {
            var firstNotEndedRoute = routes.First(x => x.ReachedEnd == false);
            var newRoutes = firstNotEndedRoute.GetNewRoutes();
            if (newRoutes != null)
            {
                routes.Remove(firstNotEndedRoute);
                routes.AddRange(newRoutes);
            }
        }

        return routes.Count;
    }

    private static List<Node> GetNodes(string input)
    {
        var nodes = input.SplitLines().SelectMany(x => x.Split('-')).Distinct().Select(x => new Node(x)).ToList();
        var values = input.SplitLines().Select(x => x.Split('-')).ToList();

        foreach (var node in nodes)
        {
            var connectedNodeNames = values.Where(x => x.Contains(node.Name)).Select(x => x.First(y=> y != node.Name)).ToList();
            node.ConnectingNodes = nodes.Where(x => connectedNodeNames.Contains(x.Name)).ToList();  
        }

        return nodes;
    }
}