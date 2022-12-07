using System.Collections.ObjectModel;

namespace Day7_NoSpaceLeftOnDevice
{
    internal class DeviceDirectoryFileCollection : KeyedCollection<string, DeviceDirectoryFile>
    {
        protected override string GetKeyForItem(DeviceDirectoryFile item) => item.Name;
    }
}
