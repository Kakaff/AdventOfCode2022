using AoCHelpers;

var caloriesPerElf = InputHelper.ReadInputFromFile("./input.txt")
    .Split($"{Environment.NewLine}{Environment.NewLine}")
    .Select(x => x.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
    .Select(x => x.Sum(y => int.Parse(y)))
    .OrderDescending();

Console.WriteLine($"The elf carrying the most calories is carrying {caloriesPerElf.First()}");
Console.WriteLine($"The top 3 elves are carrying a total of {caloriesPerElf.Take(3).Sum()}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();