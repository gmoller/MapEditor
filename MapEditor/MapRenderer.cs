using System.Drawing;

namespace MapEditor
{
    internal static class MapRenderer
    {
        internal static Bitmap Render(Map map, PaletteList palettes)
        {
            int width = map.NumberOfColumns * map.CellSize.X;
            int height = map.NumberOfRows * map.CellSize.Y;
            var image = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.BlanchedAlmond);
            }

            DrawTiles(image, map, palettes);
            DrawGrid(image, map);

            return image;
        }

        private static void DrawTiles(Bitmap destinationImage, Map map, PaletteList palettes)
        {
            using (Graphics g = Graphics.FromImage(destinationImage))
            {
                for (int layer = 0; layer < map.NumberOfLayers; ++layer)
                {
                    if (!map.Layers[layer].Visible) continue;

                    for (int row = 0; row < map.NumberOfRows; ++row)
                    {
                        for (int column = 0; column < map.NumberOfColumns; ++column)
                        {
                            // determine where to draw
                            //var rect = new Rectangle(column * map.CellSize.X, row * map.CellSize.Y, map.CellSize.X, map.CellSize.Y);
                            var rect = new Rectangle(column * map.CellSize.X, map.NumberOfRows * map.CellSize.Y - row * map.CellSize.Y - map.CellSize.Y, map.CellSize.X, map.CellSize.Y);

                            // get image
                            Cell cell = map.GetCell(layer, column, row);

                            if (!cell.IsNull())
                            {
                                int paletteId = cell.PaletteId;
                                int tileId = cell.TileId;
                                Palette palette = palettes[paletteId];
                                Bitmap sourceImage = palette.Images[tileId].Bitmap;

                                // draw image
                                g.DrawImage(sourceImage, rect);
                            }
                        }
                    }
                }
            }
        }

        private static void DrawGrid(Bitmap image, Map map)
        {
            int width = map.NumberOfColumns * map.CellSize.X;
            int height = map.NumberOfRows * map.CellSize.Y;

            Pen pen = new Pen(Color.Gray, 1);
            using (Graphics g = Graphics.FromImage(image))
            {
                for (int i = 1; i < map.NumberOfRows; ++i)
                {
                    g.DrawLine(pen, 0, i * map.CellSize.X, width - 1, i * map.CellSize.X);
                }

                for (int j = 1; j < map.NumberOfColumns; ++j)
                {
                    g.DrawLine(pen, j * map.CellSize.Y, 0, j * map.CellSize.Y, height - 1);
                }
            }
        }
    }
}