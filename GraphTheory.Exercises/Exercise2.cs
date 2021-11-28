using GraphTheory.Core.Extras;
using GraphTheory.Core.Models;
using GraphTheory.Exercises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory.Exercises
{
    public sealed class Exercise2 : IExercise
    {
        public void Execute()
        {
            var graph = CreateGraph();

            graph.PrintEdges();

            foreach (var node in graph.Nodes)
                node.CalculateDistances();

            var center = graph.FindCenter();
            Console.WriteLine($"The center of the graph is the sub-graph of the {string.Join(",", center.Select(c => c.Id))} nodes.");

            var median = graph.FindMedian();
            Console.WriteLine($"The median of the graph is the sub-graph of the {string.Join(",", median.Select(c => c.Id))} nodes.");
        }

        private Graph CreateGraph()
        {
            var graph = new Graph();
            SetNodes(graph);
            SetEdges(graph);

            return graph;
        }

        private void SetNodes(Graph graph)
        {   
            for (int i = 0; i < 8; i++)
                graph.AddNode();
        }

        private void SetEdges(Graph graph)
        {
            graph.AddEdge(graph.Nodes.Single(n => n.Id == 'A'), graph.Nodes.Single(n => n.Id == 'D'), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == 'D'), graph.Nodes.Single(n => n.Id == 'C'), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == 'D'), graph.Nodes.Single(n => n.Id == 'E'), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == 'D'), graph.Nodes.Single(n => n.Id == 'F'), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == 'D'), graph.Nodes.Single(n => n.Id == 'G'), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == 'G'), graph.Nodes.Single(n => n.Id == 'H'), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == 'H'), graph.Nodes.Single(n => n.Id == 'B'), 1);
        }
    }
}
