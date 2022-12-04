
string inputText;

using (var file = File.OpenRead("./input.txt"))
using (var streamReader = new StreamReader(file))
    inputText = streamReader.ReadToEnd();

var pairs = inputText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
    .Select(pair => pair.Split(',', StringSplitOptions.RemoveEmptyEntries)
        .Select(range =>
        {
            var rangeValues = range.Split('-', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(num => int.Parse(num));

            return (Start: rangeValues.Min(), End: rangeValues.Max());
        }))
    .Select(x => (First: x.First(), Second: x.Last()));

var part1FullyOverlappingPairs = pairs.Count(x => (x.First.Start <= x.Second.Start && x.First.End >= x.Second.End)
                                               || (x.Second.Start <= x.First.Start && x.Second.End >= x.First.End));

var part2OverlappingPairs = pairs.Count(x => (x.First.Start <= x.Second.End && x.First.End >= x.Second.Start)
                                          || (x.Second.Start <= x.First.End && x.Second.End >= x.First.Start));

Console.WriteLine($"Part1: The number of fully overlapping pairs is {part1FullyOverlappingPairs}");
Console.WriteLine($"Part2: The number of overlapping pairs is {part2OverlappingPairs}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();