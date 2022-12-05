using AoCHelpers;

var rucksacks = InputHelper.ReadInputLinesFromFile("./input.txt");

var part1DuplicatedTypesSum = rucksacks.Select(x => (FirstCompartment: x[..(x.Length / 2)], SecondCompartment: x[(x.Length / 2)..]))
                     .Select(x => x.FirstCompartment.Intersect(x.SecondCompartment).Distinct())
                     .Select(x => x.Select(p => GetItemPriority(p)))
                     .Sum(x => x.Sum());

var part2GroupBadgesSum = rucksacks.Cast<IEnumerable<char>>()
    .Chunk(3)
    .Select(x => x.Aggregate(x.First(), (a, b) => a.Intersect(b)))
    .Select(x => GetItemPriority(x.Distinct().Single()))
    .Sum();

Console.WriteLine($"Part1: The sum of the duplicated itemtypes is {part1DuplicatedTypesSum}");
Console.WriteLine($"Part2: The sum of the group badges is {part2GroupBadgesSum}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

int GetItemPriority(char c) => char.IsUpper(c) ? c - 38 : c - 96;