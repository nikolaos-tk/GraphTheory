using System;
using System.Linq;

namespace GraphTheory.Core.Models
{
    public class DegreeSequence
    {
        private int[] _degreeSequence { get; set; }
        private bool _isGraphical { get; set; }

        public DegreeSequence(int[] sequence)
        {
            _degreeSequence = sequence;
            _isGraphical = CheckIsGraphical(_degreeSequence, 0);
        }

        public DegreeSequence(int graphOrder)
        {
            GenerateRandomSequence(graphOrder);
            _isGraphical = CheckIsGraphical(_degreeSequence, 0);
        }

        public int[] Sequence => _degreeSequence;

        public bool IsGraphical => _isGraphical;

        private void GenerateRandomSequence(int graphOrder)
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
