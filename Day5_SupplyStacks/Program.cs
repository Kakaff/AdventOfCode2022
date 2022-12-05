using System.Text.RegularExpressions;

string inputText;

using (var file = File.OpenRead("./input.txt"))
using (var streamReader = new StreamReader(file))
    inputText = streamReader.ReadToEnd();

var input = inputText.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);

var stackInputRows = input.First()
    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
    .Select(x => x.Chunk(4).Select((x, index) => (Value: x.Skip(1).First(), StackIndex: index)))
    .SkipLast(1);

var part1Stacks = new Stack<char>[stackInputRows.First().Count()];
var part2Stacks = new Stack<char>[part1Stacks.Length];

for (int i = 0; i < part1Stacks.Length; i++)
{
    part1Stacks[i] = new Stack<char>();
    part2Stacks[i] = new Stack<char>();
}

foreach (var (Value, StackIndex) in stackInputRows.Reverse().SelectMany(row => row.Where(column => column.Value != ' ')))
{
    part1Stacks[StackIndex].Push(Value);
    part2Stacks[StackIndex].Push(Value);
}

var commands = Regex.Matches(input.Last(), @"move ([0-9]+) from ([0-9]+) to ([0-9]+)", RegexOptions.IgnoreCase)
    .Select(x => x.Groups.Values.Skip(1).Select(x => int.Parse(x.Value)))
    .Select(x => (Quantity: x.First(), From: x.Skip(1).First(), To: x.Skip(2).First()));

foreach (var command in commands)
{
    var part2CratesToMove = new List<char>();

    for (int i = 0; i < command.Quantity; i++)
    {
        part1Stacks[command.To - 1].Push(part1Stacks[command.From - 1].Pop());
        part2CratesToMove.Add(part2Stacks[command.From - 1].Pop());
    }

    part2CratesToMove.Reverse();
    part2CratesToMove.ForEach(part2Stacks[command.To - 1].Push);
}

var part1TopMessage = string.Concat(part1Stacks.Select(x => x.Peek()));
var part2TopMessage = string.Concat(part2Stacks.Select(x => x.Peek()));

Console.WriteLine($"Part 1: The characters at the top of each stack are {part1TopMessage}");
Console.WriteLine($"Part 2: The characters at the top of each stack are {part2TopMessage}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();