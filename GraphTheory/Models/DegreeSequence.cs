using System;
using System.Linq;

namespace GraphTheory1.Models
{
    public class DegreeSequence
    {
        private int[] _degreeSequence { get; set; }

        public DegreeSequence(int graphOrder)
        {
            Generate(graphOrder);
        }

        public int[] GeneratedSequence => _degreeSequence;

        public bool IsGraphical => CheckIsGraphical(_degreeSequence, 0);

        private void Generate(int graphOrder)
        {
            var degreeSequence = new int[graphOrder];
            int maxPossibleEdges = graphOrder - 1;

            //This generates a graphical sequence at almost a 50% possibility.
            var rnd = new Random();
            for (int i = 0; i < graphOrder; i++)
            {
                int sequenceValue = rnd.Next((maxPossibleEdges*3)/4, maxPossibleEdges + 1);
                degreeSequence[i] = sequenceValue;

                if (sequenceValue < maxPossibleEdges)
                    maxPossibleEdges = sequenceValue;
            }

            _degreeSequence =  degreeSequence;
        }

        private bool CheckIsGraphical(int[] degreeSequence, int step)
        {
            Console.WriteLine($"D{step}: {string.Join(',', degreeSequence)}");

            //This algorithm is based on the slides. Nothing to explain I think.
            if (degreeSequence.All(gs => gs > degreeSequence.Length - 1))
                return false;

            if (degreeSequence.All(gs => gs == 0))
                return true;

            if (degreeSequence.Any(gs => gs < 0))
                return false;

            degreeSequence = degreeSequence.OrderByDescending(gs => gs).ToArray();
            Console.WriteLine($"O{step}: {string.Join(',', degreeSequence)}");

            int numberOfIndexesForReduction = degreeSequence.Take(1).Single();
            degreeSequence = degreeSequence.Skip(1).ToArray();

            for (int i = 0; i < numberOfIndexesForReduction; i++)
                degreeSequence[i]--;

            if (CheckIsGraphical(degreeSequence, ++step))
                return true;

            return false;
        }
    }
}
