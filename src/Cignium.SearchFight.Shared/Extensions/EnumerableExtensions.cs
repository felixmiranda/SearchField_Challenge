using System;
using System.Collections.Generic;

namespace App.SearchFight.Shared
{
    public static class EnumerableExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> source, Func<T, long> func)
        {
            if (source == null)
                throw new ArgumentException("The specified parameter cannot be null.", nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    throw new ArgumentException("Cannot get next enumerator from specified parameter.", nameof(source));

                var currentMax = func(enumerator.Current);
                var maxItem = enumerator.Current;

                while (enumerator.MoveNext())
                {
                    var possible = func(enumerator.Current);

                    if (currentMax >= possible) continue;
                    currentMax = possible;
                    maxItem = enumerator.Current;
                }
                return maxItem;
            }
        }
    }
}
