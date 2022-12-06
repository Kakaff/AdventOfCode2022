namespace AoCHelpers.IEnumerableExtensions
{
    public static partial class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var value in enumerable)
                action(value);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            int index = 0;
            foreach (var value in enumerable)
            {
                action(value, index);
                ++index;
            }
        }
    }
}
