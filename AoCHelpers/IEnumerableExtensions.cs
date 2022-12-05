using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCHelpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Repeat<T>(this IEnumerable<T> enumerable, int count = 1)
        {
            for (int i = 0; i < count; i++)
                yield return enumerable;
        }
    }
}
