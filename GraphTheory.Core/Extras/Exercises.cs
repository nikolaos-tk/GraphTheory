using System;
using System.Linq;

namespace GraphTheory.Core.Extras
{
    public static class Exercises
    {
        private static byte[] _exercises = { 1, 2, 3 };

        public static bool IsAvailable(byte exerciseNumber)
        {
            return _exercises.Contains(exerciseNumber);
        }
    }
}
