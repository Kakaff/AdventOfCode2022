using AoCHelpers.IEnumerableExtensions;

namespace Day7_NoSpaceLeftOnDevice
{
    public record class ExecutedCommand(string Command, string? Parameters, string[] Output);

    internal class DeviceTerminal
    {
        public DeviceDirectory WorkingDirectory { get; private set; }

        public DeviceTerminal(DeviceDirectory workingDirectory)
        {
            WorkingDirectory = workingDirectory;
        }

        public void ParseExecutedCommand(ExecutedCommand command)
        {
            switch (command.Command)
            {
                case "cd": ChangeWorkingDirectory(command.Parameters!); break;
                case "ls": ParseDirectoryContents(command.Output); break;
                default: throw new ArgumentException(null, nameof(command));
            }
        }

        void ParseDirectoryContents(string[] directoryContents)
        {
            directoryContents.GroupBy(x => long.TryParse(x.Split(' ').First(), out _)).ForEach(group =>
            {
                if (group.Key)
                    AddFilesToWorkingDirectory(group.AsEnumerable());
                else
                    AddDirectoriesToWorkingDirectory(group.AsEnumerable());
            });

            WorkingDirectory.RecalculateSize();
        }

        void AddFilesToWorkingDirectory(IEnumerable<string> files)
        {
            files.Select(x => x.Split(' ').ToTuple<string, string>())
                .Where(file => !WorkingDirectory.Files.Contains(file.Item2))
                .ForEach(file => 
                WorkingDirectory.Files
                .Add(new DeviceDirectoryFile(WorkingDirectory, long.Parse(file.Item1), file.Item2)));
        }

        void AddDirectoriesToWorkingDirectory(IEnumerable<string> directories)
        {
            directories.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Last())
                .Where(directoryName => !WorkingDirectory.SubDirectories.Contains(directoryName))
                .ForEach(directoryName => 
                WorkingDirectory.SubDirectories
                .Add(new DeviceDirectory(directoryName, WorkingDirectory)));
        }

        void ChangeWorkingDirectory(string path)
        {
            if (path == "..")
            {
                SetParentDirectoryAsWorkingDirectory();
                return;
            }

            if (path.StartsWith("/"))
                SetRootDirectoryAsWorkingDirectory();

            if (WorkingDirectory.Name == path)
                return;

            NavigateToTargetDirectory(path);
        }

        void NavigateToTargetDirectory(string path)
        {
            var pathParts = path.Split('/', '\\', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            pathParts.ForEach((value) =>
            {
                if (WorkingDirectory.Name == value)
                    return;

                if (!WorkingDirectory.SubDirectories.TryGetValue(value, out var newWorkingDirectory))
                {
                    newWorkingDirectory = new DeviceDirectory(value, WorkingDirectory);
                    WorkingDirectory.SubDirectories.Add(newWorkingDirectory);
                }

                WorkingDirectory = newWorkingDirectory;
            });
        }

        void SetRootDirectoryAsWorkingDirectory()
        {
            while (WorkingDirectory.Parent != null)
            {
                WorkingDirectory = WorkingDirectory.Parent;
            }
        }

        void SetParentDirectoryAsWorkingDirectory()
        {
            if (WorkingDirectory.Parent == null)
                throw new DirectoryNotFoundException(nameof(WorkingDirectory));
                WorkingDirectory = WorkingDirectory.Parent;
                return;
        }
    }
}
