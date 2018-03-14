using System.IO;

namespace MapEditor
{
    internal static class MapLoader
    {
        internal static Map Load()
        {
            byte[] bytes = File.ReadAllBytes("Map.txt");
            var map = new Map(0, 0, 0, 64, 64);
            map.SetState(bytes);

            return map;
        }
    }
}