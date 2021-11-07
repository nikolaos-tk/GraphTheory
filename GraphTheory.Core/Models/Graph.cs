using GraphTheory.Core.Extras;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory.Core.Models
{
    public class Graph
    {
        public Graph(int order)
        {
            Order = order;
            Nodes = new List<Node>(8);
            Edges = new List<Edge>();
        }

        public int Order { get; set; }

        public int Size { get; set; }

        public List<Node> Nodes { get; set; }

        public List<Edge> Edges { get; set; }

        public DegreeSequence DegreeSequence { get; set; }

        public void GenerateDegreeSequence()
        {
            DegreeSequence = new DegreeSequence(Order);
            for (int i = 0; i < Order; i++)
            {
                Nodes.Add(new Node
                {
                    Name = Alphabet.GetLetter(i),
                    Degree = DegreeSequence.GeneratedSequence[i]
                });
            }
        }

        public void CreateSimpleGraph()
        {
            var nodes = Nodes.OrderByDescending(n => n.Degree).ToList();

            while (nodes.Any())
            {
                var initialNode = nodes.First();
                nodes = nodes.Skip(1).ToList();

                for (int i = 0; i < initialNode.Degree; i++)
                {
                    Edges.Add(new Edge
                    {
                        NodeFrom = initialNode,
                        NodeTo = nodes[i]
                    });

                    nodes[i].Degree--;
                }

                nodes.RemoveAll(n => n.Degree == 0);

                nodes = nodes.OrderByDescending(n => n.Degree).ToList();
            }
        }

        public void PrintEdges()
        {
            Console.Write("The edges of the simple graph are the following: {");

            foreach (var edge in Edges)
                Console.Write("{" + $"{edge.NodeFrom.Name},{edge.NodeTo.Name}" + "}");

            Console.WriteLine("}");
        }

    }
}
