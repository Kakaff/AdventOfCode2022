using AoCHelpers;
using System.Text.RegularExpressions;

var input = InputHelper.ReadInputFromFile("./input.txt")
    .Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);

var stackInputRows = input.First()
    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
    .Select(x => x.Chunk(4).Select((x, index) => (Value: x.Skip(1).First(), StackIndex: index)))
    .SkipLast(1);

var part1Stacks = new Stack<char>[stackInputRows.First().Count()].Fill(() => new Stack<char>());
var part2Stacks = new Stack<char>[part1Stacks.Length].Fill(() => new Stack<char>());

stackInputRows.Reverse()
    .SelectMany(row => row.Where(column => column.Value != ' '))
    .ForEach(crate =>
    {
        part1Stacks[crate.StackIndex].Push(crate.Value);
        part2Stacks[crate.StackIndex].Push(crate.Value);
    });

Regex.Matches(input.Last(), @"move ([0-9]+) from ([0-9]+) to ([0-9]+)", RegexOptions.IgnoreCase)
    .Select(x => x.Groups.Values.Skip(1).Select(x => int.Parse(x.Value)))
    .Select(x => (Quantity: x.First(), From: x.Skip(1).First(), To: x.Skip(2).First()))
    .ForEach(x =>
    {
        part1Stacks[x.To - 1].PushRange(part1Stacks[x.From - 1].Pop(x.Quantity));
        part2Stacks[x.To - 1].PushRange(part2Stacks[x.From - 1].Pop(x.Quantity).Reverse());
    });

Console.WriteLine($"Part 1: The characters at the top of each stack are {string.Concat(part1Stacks.Select(x => x.Peek()))}");
Console.WriteLine($"Part 2: The characters at the top of each stack are {string.Concat(part2Stacks.Select(x => x.Peek()))}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();