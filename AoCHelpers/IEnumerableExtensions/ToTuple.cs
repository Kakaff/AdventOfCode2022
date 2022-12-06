namespace AoCHelpers.IEnumerableExtensions
{
    public static partial class IEnumerableExtensions
    {
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
