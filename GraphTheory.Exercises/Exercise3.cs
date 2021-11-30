using GraphTheory.Core.Extensions;
using GraphTheory.Core.Models;
using GraphTheory.Exercises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheory.Exercises
{
    public sealed class Exercise3 : IExercise
    {
        const string _university = "UNIVERSITY";
        const string _anatoli = "ANATOLI";
        const string _perama = "PERAMA";
        const string _center = "CENTER";
        const string _paralimnio = "PARALIMNIO";
        const string _neaZoi = "NEA ZOI";

        public void Execute()
        {
            var graph = CreateGraph();

            graph.PrintDetailedEdges();

            Console.WriteLine("Please select the initial area:");
            Console.WriteLine($"\t 1. {_university}");
            Console.WriteLine($"\t 2. {_anatoli}");
            Console.WriteLine($"\t 3. {_perama}");
            Console.WriteLine($"\t 4. {_center}");
            Console.WriteLine($"\t 5. {_paralimnio}");
            Console.WriteLine($"\t 6. {_neaZoi}");

            string initialNodeId = ConvertInputChoice(Console.ReadLine());

            FindShortestPath(graph, graph.Nodes.Single(n => n.Id == initialNodeId));
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
            graph.AddNode(_university);
            graph.AddNode(_anatoli);
            graph.AddNode(_perama);
            graph.AddNode(_center);
            graph.AddNode(_paralimnio);
            graph.AddNode(_neaZoi);
        }

        private void SetEdges(Graph graph)
        {
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _university), graph.Nodes.Single(n => n.Id == _anatoli), 13);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _university), graph.Nodes.Single(n => n.Id == _perama), 51);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _university), graph.Nodes.Single(n => n.Id == _center), 70);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _university), graph.Nodes.Single(n => n.Id == _paralimnio), 68);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _university), graph.Nodes.Single(n => n.Id == _neaZoi), 51);

            graph.AddEdge(graph.Nodes.Single(n => n.Id == _anatoli), graph.Nodes.Single(n => n.Id == _university), 13);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _anatoli), graph.Nodes.Single(n => n.Id == _perama), 60);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _anatoli), graph.Nodes.Single(n => n.Id == _center), 70);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _anatoli), graph.Nodes.Single(n => n.Id == _paralimnio), 68);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _anatoli), graph.Nodes.Single(n => n.Id == _neaZoi), 61);

            graph.AddEdge(graph.Nodes.Single(n => n.Id == _perama), graph.Nodes.Single(n => n.Id == _university), 51);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _perama), graph.Nodes.Single(n => n.Id == _anatoli), 60);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _perama), graph.Nodes.Single(n => n.Id == _center), 56);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _perama), graph.Nodes.Single(n => n.Id == _paralimnio), 35);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _perama), graph.Nodes.Single(n => n.Id == _neaZoi), 2);

            graph.AddEdge(graph.Nodes.Single(n => n.Id == _center), graph.Nodes.Single(n => n.Id == _university), 70);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _center), graph.Nodes.Single(n => n.Id == _anatoli), 70);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _center), graph.Nodes.Single(n => n.Id == _perama), 56);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _center), graph.Nodes.Single(n => n.Id == _paralimnio), 21);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _center), graph.Nodes.Single(n => n.Id == _neaZoi), 57);

            graph.AddEdge(graph.Nodes.Single(n => n.Id == _paralimnio), graph.Nodes.Single(n => n.Id == _university), 68);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _paralimnio), graph.Nodes.Single(n => n.Id == _anatoli), 68);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _paralimnio), graph.Nodes.Single(n => n.Id == _perama), 35);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _paralimnio), graph.Nodes.Single(n => n.Id == _center), 21);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _paralimnio), graph.Nodes.Single(n => n.Id == _neaZoi), 36);

            graph.AddEdge(graph.Nodes.Single(n => n.Id == _neaZoi), graph.Nodes.Single(n => n.Id == _university), 51);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _neaZoi), graph.Nodes.Single(n => n.Id == _anatoli), 61);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _neaZoi), graph.Nodes.Single(n => n.Id == _perama), 2);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _neaZoi), graph.Nodes.Single(n => n.Id == _center), 57);
            graph.AddEdge(graph.Nodes.Single(n => n.Id == _neaZoi), graph.Nodes.Single(n => n.Id == _paralimnio), 36);
        }

        private string ConvertInputChoice(string inputChoice)
        {
            int initialNodeId = int.Parse(inputChoice);

            switch (initialNodeId)
            {
                case 1:
                    return _university;

                case 2:
                    return _anatoli;

                case 3:
                    return _perama;

                case 4:
                    return _center;

                case 5:
                    return _paralimnio;

                case 6:
                    return _neaZoi;

                default:
                    throw new Exception();
            }
        }

        private void FindShortestPath(Graph graph, Node initialNode)
        {
            var path = new List<Node> { initialNode };

            int totalCost = 0;
            while (!path.SameAs(graph.Nodes))
            {
                var neighborConnections = graph.Edges.Where(e => e.Source == initialNode).OrderBy(e => e.Weight);

                var firstUnvisitedNode = 0;
                var currentConnection = neighborConnections.ElementAt(firstUnvisitedNode);
                while (path.Contains(currentConnection.Destination))
                {
                    if (firstUnvisitedNode >= neighborConnections.Count())
                    {
                        Console.WriteLine("Something went wrong!");
                        return;
                    }

                    firstUnvisitedNode++;
                    currentConnection = neighborConnections.ElementAt(firstUnvisitedNode);
                }

                path.Add(currentConnection.Destination);

                initialNode = currentConnection.Destination;
                totalCost += currentConnection.Weight;
            }

            
            totalCost += graph.Edges.Single(e => e.Source == path.Last() && e.Destination == path.First()).Weight;
            path.Add(path.ElementAt(0));

            Console.WriteLine($"A hamiltonian cycle for the graph is: {string.Join(" -> ", path.Select(p => p.Id))} - Cost: {totalCost}");
        }
    }
}
