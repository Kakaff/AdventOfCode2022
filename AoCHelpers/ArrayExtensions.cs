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

        public static T[,] Fill<T>(this T[,] array, Func<T> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = func();
                }
            }

            return array;
        }

        public static T[,] Fill<T>(this T[,] array, Func<int,int,T> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i,j] = func(i, j);
                }
            }

            return array;
        }
    }
}
