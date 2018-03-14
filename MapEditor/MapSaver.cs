using System.IO;

namespace MapEditor
{
    internal static class MapSaver
    {
        internal static void Save(byte[] bytes)
        {
            File.WriteAllBytes("Map.txt", bytes);
        }
    }
}