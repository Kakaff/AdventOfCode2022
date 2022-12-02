using System.Text.RegularExpressions;

string inputText;

using (var file = File.OpenRead("./input.txt"))
using (var streamReader = new StreamReader(file))
    inputText = streamReader.ReadToEnd();

var groupedCalories = Regex.Matches(inputText, @"((?:[0-9]+(?:\r\n|\r|\n|$))+)")
    .Where(x => x.Success)
    .Select(x => x.Value.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
    .ToArray();

var maxCalories = groupedCalories.Max(x => x.Sum(y => int.Parse(y)));

Console.WriteLine($"The elf carrying the most calories is carrying {maxCalories}");