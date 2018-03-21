using System.IO;

namespace MapEditor
{
    internal static class MapSaver
    {
        internal static void Save(string filename, byte[] bytes)
        {
            File.WriteAllBytes(filename, bytes);
        }
    }
}