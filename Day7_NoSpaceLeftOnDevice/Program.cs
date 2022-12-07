using AoCHelpers;
using AoCHelpers.IEnumerableExtensions;
using Day7_NoSpaceLeftOnDevice;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

var input = InputHelper.ReadInputFromFile("./input.txt");

var executedCommands = input.Split('$', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(x =>
    {
        var commandWithParamAndOutput = x.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var commandAndParam = commandWithParamAndOutput.First().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        return new ExecutedCommand(commandAndParam.First(), commandAndParam.Skip(1).FirstOrDefault(), commandWithParamAndOutput.Skip(1).ToArray());
    });

var terminal = new DeviceTerminal(new DeviceDirectory(0, "/"));

executedCommands.ForEach(terminal.ParseExecutedCommand);

terminal.ParseExecutedCommand(new ExecutedCommand("cd", "/", Array.Empty<string>()));

var part1Result = (terminal.WorkingDirectory.AsEnumerable()
                    .Concat(terminal.WorkingDirectory.GetAllSubDirectories()))
                    .Where(x => x.TotalSize <= 100000)
                    .Sum(x => x.TotalSize);

var usedSpace = 70000000 - terminal.WorkingDirectory.TotalSize;
var requiredSpace = 30000000 - usedSpace;

var part2Result = (terminal.WorkingDirectory.AsEnumerable()
    .Concat(terminal.WorkingDirectory.GetAllSubDirectories()))
    .Where(x => x.TotalSize >= requiredSpace)
    .OrderBy(x => x.TotalSize)
    .First();

Console.WriteLine($"Part 1: the directories with a totalsize under {1000001} units have a total combined size of {part1Result} units.");
Console.WriteLine($"Part 2: to install the update, the directory at {part2Result.GetFullPath()} should be deleted to free up {part2Result.TotalSize} units.");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();