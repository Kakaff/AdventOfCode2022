using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day7_NoSpaceLeftOnDevice
{
    internal class DeviceDirectory
    {
        public int Level { get; }
        public string Name { get; }
        public DeviceDirectory? Parent { get; }

        /// <summary>
        /// The size of the files in this directory and all subdirectories
        /// </summary>
        public long TotalSize { get; private set; } = 0;

        /// <summary>
        /// The size of all the files in this directory
        /// </summary>
        public long Size { get; private set; } = 0;

        public DeviceDirectoryCollection SubDirectories { get; } = new DeviceDirectoryCollection();
        public DeviceDirectoryFileCollection Files { get; } = new DeviceDirectoryFileCollection();

        public DeviceDirectory(int level, string name)
        {
            Level = level;
            Name = name;
        }

        public DeviceDirectory(string name) : this(0, name) { }
        public DeviceDirectory(string name, DeviceDirectory parent) : this(parent.Level + 1, name)
        {
            Parent = parent;
        }

        public void RecalculateSize()
        {
            Size = Files.Sum(x => x.Size);
            var sizeOfSubdirectories = SubDirectories.Sum(x => x.TotalSize);
            TotalSize = sizeOfSubdirectories + Size;

            Parent?.RecalculateSize();
        }

        public string GetFullPath()
        {
            var nameParts = new List<IEnumerable<char>> { Name };
            DeviceDirectory? current = this;

            do
            {
                current = current.Parent;

                if (current != null)
                    nameParts.Add(current.Name.SkipWhile(x => x == '/'));

            } while (current != null);

            nameParts.Reverse();
            return string.Join("/", nameParts.Select(x => string.Concat(x)));
        }

        public IEnumerable<DeviceDirectoryFile> GetAllFiles()
        {
            return SubDirectories.Aggregate(Files.AsEnumerable(),
                (files, directory) => files.Concat(directory.GetAllFiles()));
        }

        public IEnumerable<DeviceDirectory> GetAllSubDirectories()
        {
            return SubDirectories.Aggregate(SubDirectories.AsEnumerable(),
                (directories, directory) => directories.Concat(directory.GetAllSubDirectories()));
        }

        public IEnumerable<DeviceDirectory> AsEnumerable()
        {
            yield return this;
        }
    }
}
