using System.Collections.ObjectModel;

namespace Day7_NoSpaceLeftOnDevice
{
    internal class DeviceDirectoryCollection : KeyedCollection<string, DeviceDirectory>
    {
        protected override string GetKeyForItem(DeviceDirectory item) => item.Name;
    }
}
