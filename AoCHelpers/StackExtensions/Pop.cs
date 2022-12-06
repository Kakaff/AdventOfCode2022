namespace AoCHelpers.StackExtensions
{
    public static partial class StackExtensions
    {
        public static IEnumerable<T?> Pop<T>(this Stack<T?> stack, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return stack.Pop();
            }
        }
    }
}
