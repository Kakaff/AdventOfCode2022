
using AoCHelpers;

var pairs = InputHelper.ReadInputLinesFromFile("./input.txt")
    .Select(pair => pair.Split(',', StringSplitOptions.RemoveEmptyEntries)
        .Select(range => range.Split('-').Select(x => int.Parse(x)).Order().ToTuple<int, int>()))
    .Select(x => (First: x.First(), Second: x.Last()));

var part1FullyOverlappingPairs = pairs.Count(x => (x.First.Item1 <= x.Second.Item1 && x.First.Item2 >= x.Second.Item2)
                                                   || (x.Second.Item1 <= x.First.Item1 && x.Second.Item2 >= x.First.Item2));

var part2OverlappingPairs = pairs.Count(x => (x.First.Item1 <= x.Second.Item2 && x.First.Item2 >= x.Second.Item1)
                                          || (x.Second.Item1 <= x.First.Item2 && x.Second.Item2 >= x.First.Item1));

Console.WriteLine($"Part1: The number of fully overlapping pairs is {part1FullyOverlappingPairs}");
Console.WriteLine($"Part2: The number of overlapping pairs is {part2OverlappingPairs}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();