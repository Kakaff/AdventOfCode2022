using AoCHelpers;
using AoCHelpers.ArrayExtensions;
using AoCHelpers.IEnumerableExtensions;

var input = InputHelper.ReadInputFromFile("./input.txt");

var part1 = GetFirstDistinctSequence(input, 4);
var part2 = GetFirstDistinctSequence(input, 14);

Console.WriteLine($"The first start of packet marker {part1.Sequence} was found after {part1.ProcessedCount} characters had been processed");
Console.WriteLine($"The first start of message marker {part2.Sequence} was found after {part2.ProcessedCount} characters had been processed");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

(string? Sequence, int ProcessedCount) GetFirstDistinctSequence(string input, int sequenceLength)
{
    if (input.Length < sequenceLength)
        throw new ArgumentOutOfRangeException($"{nameof(sequenceLength)} is greater than {nameof(input.Length)}");

    var chunk = new char[sequenceLength].Fill(i => input[i]);
    var curentIndex = sequenceLength - 1;

    do
    {
        bool isDistinctSequence = true;
        int shiftIndex = 1;

        for (int j = sequenceLength - 1; j > 0; j--)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                if (chunk[j] == chunk[k])
                {
                    shiftIndex = k + 1;
                    isDistinctSequence = false;
                    goto LoopEnd;
                }
            }
        }
    LoopEnd:

        if (isDistinctSequence)
            return (string.Concat(chunk), curentIndex + 1);

        if (curentIndex + shiftIndex > input.Length)
            break;

        int remainderCount = sequenceLength - shiftIndex;
        Array.Copy(chunk, shiftIndex, chunk, 0, remainderCount);

        for (int i = 0; i < shiftIndex; i++)
        {
            chunk[remainderCount + i] = input[curentIndex + i + 1];
        }

        curentIndex += shiftIndex;

    } while (curentIndex + 1 < input.Length);

    return (null, curentIndex);
}