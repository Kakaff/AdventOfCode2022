using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCHelpers
{
    public static class ArrayExtensions
    {
        public static T[] Fill<T>(this T[] array, Func<T> sad)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sad();
            }

            return array;
        }
    }
}
