using System.IO;

namespace MapEditor
{
    internal static class MapLoader
    {
        internal static Cell[] Load()
        {
            byte[] bytes = File.ReadAllBytes("Map.txt");

            Cell[] cells = new Cell[bytes.Length / 2];

            int j = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                if (i % 2 == 0)
                {
                    cells[j] = Cell.NewCell(bytes[i], 0);
                }
                else
                {
                    cells[j].TileId = bytes[i];
                    j++;
                }
            }

            return cells;
        }
    }
}