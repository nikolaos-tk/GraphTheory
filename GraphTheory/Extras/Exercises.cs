using System;
using System.Linq;

namespace GraphTheory1.Extras
{
    public static class Exercises
    {
        private static byte[] _exercises = { 1, 2 };

        public static bool IsAvailable(byte exerciseNumber)
        {
            return _exercises.Contains(exerciseNumber);
        }
    }
}
