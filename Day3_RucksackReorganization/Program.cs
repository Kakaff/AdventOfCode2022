string inputText;

using (var file = File.OpenRead("./input.txt"))
using (var streamReader = new StreamReader(file))
    inputText = streamReader.ReadToEnd();

var rucksacks = inputText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

var part1DuplicatedTypesPerRucksack = rucksacks.Select(x => (FirstCompartment: x[..(x.Length / 2)], SecondCompartment: x[(x.Length / 2)..]))
                     .Select(x => (from item1 in x.FirstCompartment
                                   join item2 in x.SecondCompartment on item1 equals item2
                                   select item1))
                     .Select(x => x.Distinct())
                     .Select(x => x.Select(p => GetItemPriority(p)));

var part2GroupBadges = rucksacks.Select((x, i) => (RucksackContents: x, Index: i))
    .GroupBy(x => x.Index / 3)
    .Select(x =>
    {
        return (from itemInRucksack1 in x.First().RucksackContents
                join itemInRucksack2 in x.Skip(1).First().RucksackContents on itemInRucksack1 equals itemInRucksack2
                join itemInRucksack3 in x.Skip(2).First().RucksackContents on itemInRucksack1 equals itemInRucksack3
                select itemInRucksack1);
    }).Select(x => x.Distinct().Single());

var sumPart1 = part1DuplicatedTypesPerRucksack.Sum(x => x.Sum());
var sumPart2 = part2GroupBadges.Sum(x => GetItemPriority(x));

Console.WriteLine($"Part1: The sum of the duplicated itemtypes is {sumPart1}");
Console.WriteLine($"Part2: The sum of the group badges is {sumPart2}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

int GetItemPriority(char c) => char.IsUpper(c) ? c - 38 : c - 96;