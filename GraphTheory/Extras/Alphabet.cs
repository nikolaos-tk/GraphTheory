using System.Linq;

namespace GraphTheory1.Extras
{
    public static class Alphabet
    {
        private static char[] _alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();

        public static char GetLetter(int index)
        {
            return _alphabet[index];
        }
    }
}
