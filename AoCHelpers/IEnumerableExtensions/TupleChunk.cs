namespace AoCHelpers.IEnumerableExtensions
{
    public static partial class IEnumerableExtensions
    {
        public static IEnumerable<Tuple<T>> TupleChunk<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Select(x => Tuple.Create(x));
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
    }
}
