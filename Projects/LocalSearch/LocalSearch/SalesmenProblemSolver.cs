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
        
        public List<int> GetRandomRoute() => _vertices.OrderBy(Random.Next).ToList();

        public (int minWeight, List<int> minRoute, string log) PerformSearch(List<int> startRoute)
        {
            var logBuilder = new StringBuilder();
            logBuilder
                .Append($"Current route is {RouteToString(startRoute)}\n")
                .Append($"With weight – {GetRouteWeight(startRoute)}\n")
                .Append("-----\n");
            
            var minRoute = startRoute;
            var minWeight = GetRouteWeight(minRoute);
            var neighborhood = GetNeighborhood(minRoute);
            foreach (var neighbor in neighborhood)
            {
                var neighborWeight = GetRouteWeight(neighbor);
                
                logBuilder
                    .Append($"Neighbor route is {RouteToString(neighbor)}\n")
                    .Append($"With weight – {neighborWeight}\n")
                    .Append("-----\n");

                if (neighborWeight < minWeight)
                {
                    minWeight = neighborWeight;
                    minRoute = neighbor;
                }
            }

            logBuilder
            .Append($"\nMin route is {RouteToString(minRoute)}\n")
            .Append($"With weight – {minWeight}\n");

            return (minWeight, minRoute, logBuilder.ToString());
        }
        
        public static string RouteToString(List<int> route)
        {
            var builder = new StringBuilder("[ ");
            foreach (var vertex in route)
                builder.Append(vertex).Append(' ');
            return builder.Append(']').ToString();
        }

        private int GetRouteWeight(List<int> route)
        {
            var weight = 0;

            var n = route.Count;
            for (var i = 0; i < route.Count; i++)
            {
                weight += _weights[route[i % n]][route[(i + 1) % n]];
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
    }
}