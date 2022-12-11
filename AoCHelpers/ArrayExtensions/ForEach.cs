namespace AoCHelpers.ArrayExtensions
{
    public static partial class ArrayExtensions
    {
        public static T[,] ForEach<T>(this T[,] array, Action<T> func)
        {
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    func(array[i, j]);
                }
            }

            return array;
        }
    }
}
