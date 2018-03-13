using System.IO;

namespace MapEditor
{
    internal static class MapSaver
    {
        internal static void Save(Cell[] mapState)
        {
            byte[] bytes = new byte[mapState.Length * 2];

            int i = 0;
            foreach (Cell cell in mapState)
            {
                bytes[i++] = (byte)cell.PaletteId;
                bytes[i++] = (byte)cell.TileId;
            }

            File.WriteAllBytes("Map.txt", bytes);
        }
    }
}