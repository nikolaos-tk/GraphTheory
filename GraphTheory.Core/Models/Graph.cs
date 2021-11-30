using GraphTheory.Core.Extras;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory.Core.Models
{
    public class Graph
    {
        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        public Graph(int order)
        {
            Order = order;
            Nodes = new List<Node>(order);
            Edges = new List<Edge>(order*(order - 1) / 2);
        }

        public int Order { get; set; }

        public int Size { get; set; }

        public List<Node> Nodes { get; set; }

        public List<Edge> Edges { get; set; }

        public DegreeSequence DegreeSequence { get; set; }

        public void AddNode()
        {
            var identifier = Nodes.Count();

            Nodes.Add(new Node
            {
                Id = Alphabet.GetCapitalLetter(identifier)
            });
        }

        public void AddNode(string identifier)
        {
            Nodes.Add(new Node
            {
                Id = identifier
            });
        }

        public void AddEdge(Node source, Node destination, int weight)
        {
            var edge = new Edge
            {
                Source = source,
                Destination = destination,
                Weight = weight
            };

            if (!Edges.Any(e => e.Equals(edge)))
            {

                Edges.Add(edge);

                source.AddNeighbor(destination);
                destination.AddNeighbor(source);
            }
        }

        public IEnumerable<Node> FindCenter()
        {
            return Nodes.Where(n => n.Eccentricity == Nodes.Min(n => n.Eccentricity));
        }

        public IEnumerable<Node> FindMedian()
        {
            return Nodes.Where(n => n.Distances.Select(d => d.Value).Sum() == Nodes.Min(n => n.Distances.Select(d => d.Value).Sum()));
        }

        public void GenerateRandomDegreeSequence()
        {
            DegreeSequence = new DegreeSequence(Order);            
        }

        public void CreateNodesBasedOnTheDegreeSequence()
        {
            if (DegreeSequence == null)
            {
                Console.WriteLine("There is no Degree Sequence defined for the Graph.");
                return;
            }

            if (Nodes.Any())
                Nodes.Clear();

            for (int i = 0; i < Order; i++)
            {
                Nodes.Add(new Node
                {
                    Id = Alphabet.GetLetter(i),
                    Degree = DegreeSequence.Sequence[i]
                });
            }
        }

        public void CreateSimpleConnectedGraph()
        {
            if (Nodes.Count() < 2)
            {
                Console.WriteLine("There have to be at least 2 Nodes defined for a simple connected Graph to be created.");
                return;
            }

            var nodes = Nodes.OrderByDescending(n => n.Degree).ToList();

            while (nodes.Any())
            {
                var initialNode = nodes.First();
                nodes = nodes.Skip(1).ToList();

                if (initialNode.Degree > nodes.Count())
                {
                    Console.WriteLine("The creation of the Graph failed.");
                    Edges.Clear();
                    return;
                }

                for (int i = 0; i < initialNode.Degree; i++)
                {
                    Edges.Add(new Edge
                    {
                        Source = initialNode,
                        Destination = nodes[i]
                    });

                    nodes[i].Degree--;
                }

                nodes.RemoveAll(n => n.Degree == 0);

                nodes = nodes.OrderByDescending(n => n.Degree).ToList();
            }
        }

        public void PrintNodes()
        {
            Console.WriteLine(string.Join(',', Nodes.Select(n => n.Id)));
        }

        public void PrintEdges()
        {
            Console.Write("The edges of the simple graph are the following: {");

            foreach (var edge in Edges)
                Console.Write("{" + $"{edge.Source.Id},{edge.Destination.Id}" + "}");

            Console.WriteLine("}");
        }

        public void PrintDetailedEdges()
        {
            foreach (var edge in Edges)
                Console.WriteLine($"\t{edge.Source.Id}  \t  {edge.Destination.Id}   \t Cost: {edge.Weight}");
        }
    }
}
