using AoCHelpers;

var input = InputHelper.ReadInputFromFile("./input.txt");

var part1 = GetFirstDistinctSequence(input, 4);
var part2 = GetFirstDistinctSequence(input, 14);

Console.WriteLine($"The first start of packet marker is found after {part1.ProcessedCount} characters have been processed");
Console.WriteLine($"The first start of message marker is found after {part2.ProcessedCount} characters have been processed");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

(string? Sequence, int ProcessedCount) GetFirstDistinctSequence(string input, int sequenceLength)
{
    var chunk = new char[sequenceLength];

    for (int i = 0; i < input.Length; i++)
    {
        if (i > sequenceLength - 1)
        {
            Array.Copy(chunk, 1, chunk, 0, sequenceLength - 1);
        }
        else
        {
            chunk[i] = input[i];
            continue;
        }

        chunk[sequenceLength - 1] = input[i];
        bool isDistinctSequence = false;

        for (int j = sequenceLength - 1; j > 0; j--)
        {
            for (int k = 0; k < j; k++)
            {
                isDistinctSequence = chunk[j] != chunk[k];

                if (!isDistinctSequence)
                    goto LoopEnd;
            }
        }
        LoopEnd:

        if (isDistinctSequence)
            return (string.Concat(chunk), i + 1);
    }

    return (null, input.Length);
}