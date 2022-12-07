namespace Day7_NoSpaceLeftOnDevice
{
    internal class DeviceDirectoryFile
    {
        public DeviceDirectory Directory { get; }
        public long Size { get; }
        public string Name { get; }

        public DeviceDirectoryFile(DeviceDirectory directory, long size, string name)
        {
            Directory = directory;
            Size = size;
            Name = name;
        }
    }
}
