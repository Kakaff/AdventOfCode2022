string inputText;

using (var file = File.OpenRead("./input.txt"))
using (var streamReader = new StreamReader(file))
    inputText = streamReader.ReadToEnd();

var rucksacks = inputText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

var part1DuplicatedTypesPerRucksack = rucksacks.Select(x => (FirstCompartment: x[..(x.Length / 2)], SecondCompartment: x[(x.Length / 2)..]))
                     .Select(x => x.FirstCompartment.Intersect(x.SecondCompartment).Distinct())
                     .Select(x => x.Select(p => GetItemPriority(p)));

var part2GroupBadges = rucksacks.Cast<IEnumerable<char>>().Chunk(3)
    .Select(x => x.Aggregate(x.First(), (a,b) => a.Intersect(b)))
    .Select(x => x.Distinct().Single());

var sumPart1 = part1DuplicatedTypesPerRucksack.Sum(x => x.Sum());
var sumPart2 = part2GroupBadges.Sum(x => GetItemPriority(x));

Console.WriteLine($"Part1: The sum of the duplicated itemtypes is {sumPart1}");
Console.WriteLine($"Part2: The sum of the group badges is {sumPart2}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

int GetItemPriority(char c) => char.IsUpper(c) ? c - 38 : c - 96;