using GraphTheory.Core.Models;
using GraphTheory.Exercises.Interfaces;
using System;
using System.Linq;

namespace GraphTheory.Exercises
{
    public class Exercise4 : IExercise
    {
        const string _alpha = "Alpha";
        const string _bravo = "Bravo";
        const string _charlie = "Charlie";
        const string _delta = "Delta";
        const string _echo = "Echo";
        const string _fox = "Fox";
        const string _golf = "Golf";
        const string _hotel = "Hotel";

        public void Execute()
        {
            var graph = CreateGraph();

            foreach (var node in graph.Nodes)
                Console.WriteLine($"{node.Id} - {node.Degree}");
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
            graph.AddNode(_alpha);
            graph.AddNode(_bravo);
            graph.AddNode(_charlie);
            graph.AddNode(_delta);
            graph.AddNode(_echo);
            graph.AddNode(_fox);
            graph.AddNode(_golf);
            graph.AddNode(_hotel);
        }

        private void SetEdges(Graph graph)
        {
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _alpha), graph.Nodes.Single(n => n.Id == _charlie), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _alpha), graph.Nodes.Single(n => n.Id == _golf), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _bravo), graph.Nodes.Single(n => n.Id == _delta), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _delta), graph.Nodes.Single(n => n.Id == _alpha), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _delta), graph.Nodes.Single(n => n.Id == _echo), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _echo), graph.Nodes.Single(n => n.Id == _fox), 1);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _echo), graph.Nodes.Single(n => n.Id == _hotel), 1);
        }
    }
}
