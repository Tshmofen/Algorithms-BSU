using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalSearch
{
    public class SalesmenProblemSolver
    {
        private static readonly Random Random = new();

        private readonly List<List<int>> _weights;
        private readonly List<int> _vertices;

        public SalesmenProblemSolver(List<List<int>> weights)
        {
            _weights = weights;
            _vertices = new List<int>();
            for (var i = 0; i < weights.Count; i++)
                _vertices.Add(i);
        }

        public (int minWeight, List<int> minRoute, string log) PerformSearch(List<int> startRoute = null)
        {
            var logBuilder = new StringBuilder();
            var iteration = 0;
            
            var minRoute = startRoute ?? _vertices.OrderBy(Random.Next).ToList();
            var minWeight = GetRouteWeight(minRoute, _weights);
            var isMinFound = false;
            
            while (!isMinFound && iteration++ < 100) 
            {
                logBuilder
                    .Append($"Current route is {PrintRoute(minRoute)}\n")
                    .Append($"With weight – {minWeight}\n")
                    .Append("-----\n");
                
                var neighborhood = GetNeighborhood(minRoute);
                foreach (var neighbor in neighborhood)
                {
                    var neighborWeight = GetRouteWeight(neighbor, _weights);
                    
                    logBuilder
                        .Append($"Current route is {PrintRoute(neighbor)}\n")
                        .Append($"With weight – {neighborWeight}\n")
                        .Append("-----\n");

                    if (neighborWeight < minWeight)
                    {
                        minWeight = neighborWeight;
                        minRoute = neighbor;
                        isMinFound = true;
                    }
                }
            }

            logBuilder
                .Append($"\nMin route is {PrintRoute(minRoute)}\n")
                .Append($"With weight – {minWeight}\n");

            return (minWeight, minRoute, logBuilder.ToString());
        }

        private static int GetRouteWeight(List<int> route, List<List<int>> weights)
        {
            var weight = 0;

            var n = route.Count;
            for (var i = 0; i < route.Count; i++)
            {
                weight += weights[route[i % n]][route[(i + 1) % n]];
            }

            return weight;
        }
        
        private static List<List<int>> GetNeighborhood(List<int> route)
        {
            var neighborhood = new List<List<int>>();

            for (var i = 0; i < route.Count - 2; i++)
            {
                for (var j = i + 2; j < route.Count; j++)
                {
                    var neighbor = new List<int>(route);
                    (neighbor[i], neighbor[j]) = (neighbor[j], neighbor[i]);
                    neighborhood.Add(neighbor);
                }
            }

            return neighborhood;
        }

        private static string PrintRoute(List<int> route)
        {
            var builder = new StringBuilder("[ ");
            foreach (var vertex in route)
                builder.Append(vertex).Append(' ');
            return builder.Append(']').ToString();
        }
    }
}