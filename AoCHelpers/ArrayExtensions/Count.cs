namespace AoCHelpers.ArrayExtensions
{
    public static partial class ArrayExtensions
    {
        public static int Count<T>(this T[,] array, Predicate<T> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (func(array[i, j]))
                        count++;
                }
            }

            return count;
        }
    }
}