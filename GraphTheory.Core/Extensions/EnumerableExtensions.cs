using System.Collections.Generic;
using System.Linq;

namespace GraphTheory.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool SameAs<T>(this IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
            where T : class
        {
            if (firstCollection == null && secondCollection == null)
                return true;

            if (firstCollection == null || secondCollection == null)
                return false;

            var firstNotSecond = firstCollection.Except(secondCollection);
            var secondNotFirst = secondCollection.Except(firstCollection);

            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}
