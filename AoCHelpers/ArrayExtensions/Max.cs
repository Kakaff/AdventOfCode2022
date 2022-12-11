namespace AoCHelpers.ArrayExtensions
{
    public static partial class ArrayExtensions
    {
        public static byte Max<T>(this T[,] array, Func<T, byte> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            byte max = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    max = Math.Max(func(array[i, j]), max);
                }
            }

            return max;
        }

        public static short Max<T>(this T[,] array, Func<T, short> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            short max = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    max = Math.Max(func(array[i, j]), max);
                }
            }

            return max;
        }

        public static int Max<T>(this T[,] array, Func<T, int> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            int max = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    max = Math.Max(func(array[i,j]), max);
                }
            }

            return max;
        }

        public static long Max<T>(this T[,] array, Func<T, long> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            long max = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    max = Math.Max(func(array[i, j]), max);
                }
            }

            return max;
        }

        public static float Max<T>(this T[,] array, Func<T, float> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            float max = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    max = Math.Max(func(array[i, j]), max);
                }
            }

            return max;
        }

        public static double Max<T>(this T[,] array, Func<T, double> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            double max = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    max = Math.Max(func(array[i, j]), max);
                }
            }

            return max;
        }
    }
}
