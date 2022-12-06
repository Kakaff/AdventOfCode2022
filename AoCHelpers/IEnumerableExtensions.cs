using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var value in enumerable)
                action(value);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T,int> action)
        {
            int index = 0;
            foreach (var value in enumerable) {
                action(value, index);
                ++index;
            }
        }

        public static IEnumerable<Tuple<T>> TupleChunk<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Select(x => Tuple.Create<T>(x));
        }

        public static IEnumerable<Tuple<T1, T2>> TupleChunk<T1, T2>(this IEnumerable<T1> enumerable) where T1 : T2
        {
            return enumerable.Chunk(2).Select(x => x.ToTuple<T1, T2>());
        }

        public static IEnumerable<Tuple<T1, T2, T3>> TupleChunk<T1, T2, T3>(this IEnumerable<T1> enumerable) where T1 : T2 where T2 : T3
        {
            return enumerable.Chunk(3).Select(x => x.ToTuple<T1, T2, T3>());
        }

        public static IEnumerable<Tuple<T1, T2, T3, T4>> TupleChunk<T1, T2, T3, T4>(this IEnumerable<T1> enumerable) where T1 : T2 where T2 : T3 where T3 : T4
        {
            return enumerable.Chunk(4).Select(x => x.ToTuple<T1, T2, T3, T4>());
        }

        public static Tuple<T> ToTuple<T>(this IEnumerable<T> enumerable)
        {
            return Tuple.Create(enumerable.First());
        }

        public static Tuple<T1, T2> ToTuple<T1, T2>(this IEnumerable<T1> enumerable) where T1 : T2
        {
            return Tuple.Create<T1, T2>(enumerable.First(), enumerable.Skip(1).First());
        }

        public static Tuple<T1, T2> ToTuple<T1, T2>(this T1[] array) where T1 : T2
        {
            return Tuple.Create<T1, T2>(array[0], array[1]);
        }

        public static Tuple<T1, T2, T3> ToTuple<T1, T2, T3>(this IEnumerable<T1> enumerable) where T1 : T2 where T2 : T3
        {
            return Tuple.Create<T1, T2, T3>(enumerable.First(), enumerable.Skip(1).First(), enumerable.Skip(2).First());
        }

        public static Tuple<T1, T2, T3, T4> ToTuple<T1, T2, T3, T4>(this IEnumerable<T1> enumerable) where T1 : T2 where T2 : T3 where T3 : T4
        {
            return Tuple.Create<T1, T2, T3, T4>(enumerable.First(), enumerable.Skip(1).First(), enumerable.Skip(2).First(), enumerable.Skip(2).First());
        }
    }
}
