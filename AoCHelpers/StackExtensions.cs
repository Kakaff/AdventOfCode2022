using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCHelpers
{
    public static class StackExtensions
    {
        public static Stack<T?> PushRange<T>(this Stack<T?> stack, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                stack.Push(value);
            }

            return stack;
        }

        public static IEnumerable<T?> Pop<T>(this Stack<T?> stack, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return stack.Pop();
            }
        }
    }
}
