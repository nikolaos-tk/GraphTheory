using GraphTheory1.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory1.Exercises
{
    public class Exercise2 : IExercise
    {
        public void Execute()
        {
            var graph = CreateGraph();

            graph.PrintEdges();
        }

        private Graph CreateGraph()
        {
            var graph = new Graph(8);
            graph.Nodes = CreateNodes();
            graph.Edges = CreateEdges(graph.Nodes);

            return graph;
        }

        private List<Edge> CreateEdges(List<Node> nodes)
        {
            return new List<Edge>
            {
                new Edge { NodeFrom = nodes.Single(n => n.Name == 'A'), NodeTo = nodes.Single(n => n.Name == 'D') },
                new Edge { NodeFrom = nodes.Single(n => n.Name == 'D'), NodeTo = nodes.Single(n => n.Name == 'C') },
                new Edge { NodeFrom = nodes.Single(n => n.Name == 'D'), NodeTo = nodes.Single(n => n.Name == 'E') },
                new Edge { NodeFrom = nodes.Single(n => n.Name == 'D'), NodeTo = nodes.Single(n => n.Name == 'F') },
                new Edge { NodeFrom = nodes.Single(n => n.Name == 'D'), NodeTo = nodes.Single(n => n.Name == 'G') },
                new Edge { NodeFrom = nodes.Single(n => n.Name == 'G'), NodeTo = nodes.Single(n => n.Name == 'H') },
                new Edge { NodeFrom = nodes.Single(n => n.Name == 'H'), NodeTo = nodes.Single(n => n.Name == 'B') }
            };
        }

        private List<Node> CreateNodes()
        {
            return new List<Node>
            {
                new Node { Name = 'A', Degree = 1 },
                new Node { Name = 'B', Degree = 1 },
                new Node { Name = 'C', Degree = 1 },
                new Node { Name = 'D', Degree = 5 },
                new Node { Name = 'E', Degree = 1 },
                new Node { Name = 'F', Degree = 1 },
                new Node { Name = 'G', Degree = 2 },
                new Node { Name = 'H', Degree = 2 }
            };
        }
    }
}
