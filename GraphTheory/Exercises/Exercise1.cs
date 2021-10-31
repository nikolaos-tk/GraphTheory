using GraphTheory1.Models;
using System;

namespace GraphTheory1.Exercises
{
    public class Exercise1 : IExercise
    {
        public void Execute()
        {
            Console.Write("Please define the order of the graph (number of vertices): ");

            int graphOrder;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out graphOrder) || graphOrder <= 1)
            {
                Console.WriteLine("The graph order must a positive integer greater than or equal to 2.");
                Console.Write("Please define the order of the graph (number of vertices): ");
                input = Console.ReadLine();
            }

            var graph = new Graph(graphOrder);
            if (graph.DegreeSequence == null)
                graph.GenerateDegreeSequence();

            if (graph.DegreeSequence.IsGraphical)
            {
                Console.WriteLine("The graph sequence is graphical.");
                graph.CreateSimpleGraph();
                graph.PrintEdges();
            }
            else
                Console.WriteLine("The graph sequence is not graphical.");
        }
    }
}
