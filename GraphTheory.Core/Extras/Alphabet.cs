using System.Linq;

namespace GraphTheory.Core.Extras
{
    public static class Alphabet
    {
        private static char[] _alphabetLowerCase = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
        private static char[] _alphabetUpperCase = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();

        public static char GetLetter(int index)
        {
            return _alphabetLowerCase[index];
        }

        public static char GetCapitalLetter(int index)
        {
            return _alphabetUpperCase[index];
        }
    }
}
