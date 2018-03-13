namespace MapEditor
{
    internal struct Cell
    {
        private readonly byte[] _data;

        internal int PaletteId
        {
            get
            {
                int high = _data[0];

                return high;
            }
            set
            {
                _data[0] = (byte)value;
            }
        }

        internal int TileId
        {
            get
            {
                int low = _data[1];

                return low;
            }
            set
            {
                _data[1] = (byte)value;
            }
        }

        private Cell(byte paletteId, byte tileId)
        {
            _data = new [] { paletteId , tileId};
        }

        internal static Cell EmptyCell()
        {
            return new Cell(255, 255);
        }

        internal static Cell NewCell(byte paletteId, byte tileId)
        {
            return new Cell(paletteId, tileId);
        }

        internal bool IsNull()
        {
            bool isNull = PaletteId == 255 && TileId == 255;

            return isNull;
        }
    }
}