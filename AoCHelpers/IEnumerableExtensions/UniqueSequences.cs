using AoCHelpers.ArrayExtensions;

namespace AoCHelpers.IEnumerableExtensions
{
    public static partial class IEnumerableExtensions
    {
        public static IEnumerable<T?[]> UniqueSequences<T>(this IEnumerable<T?> enumerable, int sequenceLength)
        {
            using var enumerator = enumerable.GetEnumerator();

            T?[] chunk = new T[sequenceLength].Fill(() =>
            {
                enumerator.MoveNext();
                var value = enumerator.Current;
                return value;
            });

            var curentIndex = sequenceLength - 1;

            do
            {
                bool isDistinctSequence = true;
                int shiftIndex = 1;

                for (int j = sequenceLength - 1; j > 0; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (chunk[j].Equals(chunk[k]))
                        {
                            shiftIndex = k + 1;
                            isDistinctSequence = false;
                            goto LoopEnd;
                        }
                    }
                }
            LoopEnd:

                if (isDistinctSequence)
                {
                    var result = new T[sequenceLength];
                    Array.Copy(chunk, 0, result, 0, sequenceLength);
                    yield return result;
                }

                int remainderCount = sequenceLength - shiftIndex;
                Array.Copy(chunk, shiftIndex, chunk, 0, remainderCount);

                for (int i = 0; i < shiftIndex; i++)
                {
                    if (!enumerator.MoveNext())
                        goto End;

                    chunk[remainderCount + i] = enumerator.Current;
                }

                curentIndex += shiftIndex;

            } while (true);

        End:;
        }
    }
}
