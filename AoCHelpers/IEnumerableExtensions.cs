using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCHelpers
{
    public static class IEnumerableExtensions
    {
        //public static IEnumerable<T?> ForEach<T>(this IEnumerable<T?> enumerable, Action<T?,int> action)
        //{
        //    int index = 0;
        //    var current = default(T);

        //    foreach (var item in enumerable)
        //    {
        //        current = enumerable.ElementAt(index);
        //        action(current, index);
        //        index++;

        //        yield return current;
        //    }

        //    yield return current;
        //}

        //public static IEnumerable<T?> ForEach<T>(this IEnumerable<T?> enumerable, Action<T?> action)
        //{
        //    int index = 0;
        //    T? current;

        //    foreach (var item in enumerable)
        //    {
        //        current = enumerable.ElementAt(index);
        //        action(current);
        //        index++;

        //        yield return current;
        //    }
        //}
    }
}
