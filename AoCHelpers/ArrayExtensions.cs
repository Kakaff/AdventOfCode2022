namespace AoCHelpers
{
    public static class ArrayExtensions
    {
        public static T[] Fill<T>(this T[] array, Func<T> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func();
            }

            return array;
        }

        public static T[] Fill<T>(this T[] array, Func<int,T> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(i);
            }

            return array;
        }
    }
}
