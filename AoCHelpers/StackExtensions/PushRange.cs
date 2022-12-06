namespace AoCHelpers.StackExtensions
{
    public static partial class StackExtensions
    {
        public static Stack<T?> PushRange<T>(this Stack<T?> stack, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                stack.Push(value);
            }

            return stack;
        }
    }
}
