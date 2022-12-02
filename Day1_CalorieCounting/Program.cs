using System.Text.RegularExpressions;

string inputText;

using (var file = File.OpenRead("./input.txt"))
using (var streamReader = new StreamReader(file))
    inputText = streamReader.ReadToEnd();

var caloriesPerElf = Regex.Matches(inputText, @"((?:[0-9]+(?:\r\n|\r|\n|$))+)")
    .Where(x => x.Success)
    .Select(x => x.Value.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
    .Select(x => x.Sum(y => int.Parse(y)))
    .OrderDescending();

Console.WriteLine($"The elf carrying the most calories is carrying {caloriesPerElf.First()}");
Console.WriteLine($"The top 3 elves are carrying a total of {caloriesPerElf.Take(3).Sum()}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();