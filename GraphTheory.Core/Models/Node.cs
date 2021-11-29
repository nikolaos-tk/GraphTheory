using System.Collections.Generic;
using System.Linq;

namespace GraphTheory.Core.Models
{
    public class Node
    {
        public Node()
        {
            Neighbors = new List<Node>();
            Distances = new List<Distance>();
        }

        public string Id { get; set; }

        public List<Node> Neighbors { get; set; }

        public List<Distance> Distances { get; set; }

        public int Degree { get; set; }

        public int Eccentricity { get => Distances.Max(d => d.Value); }

        public void AddNeighbor(Node node)
        {
            if (!Neighbors.Contains(node))
                Neighbors.Add(node);
        }

        public void CalculateDistances()
        {
            CalculateDistancesByDjikstra(Neighbors, new List<Node>(), this, 1);
        }

        private void CalculateDistancesByDjikstra(List<Node> unvisitedNodes, List<Node> visitedNodes, Node source, int length)
        {
            var nextUnivisitedNodes = new List<Node>();

            foreach (var node in unvisitedNodes)
            {
                if (!visitedNodes.Contains(node))
                {
                    source.Distances.Add(new Distance
                    {
                        Destination = node,
                        Value = length
                    });

                    visitedNodes.Add(node);
                    nextUnivisitedNodes.AddRange(node.Neighbors);
                }
            }

            if (nextUnivisitedNodes.Any())
                CalculateDistancesByDjikstra(nextUnivisitedNodes, visitedNodes, source, length + 1);
        }
    }
}
