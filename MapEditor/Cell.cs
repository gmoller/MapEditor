namespace MapEditor
{
    internal struct Cell
    {
        private readonly byte _data;

        internal int PaletteId
        {
            get
            {
                //int high = _data >> 4;
                int high = _data >> 6;

                return high;
            }
        }

        internal int TileId
        {
            get
            {
                //int low = _data & 0x80F;
                int low = _data & 0x83F;

                return low;
            }
        }

        private Cell(byte data)
        {
            _data = data;
        }

        internal static Cell EmptyCell()
        {
            return new Cell(255);
        }

        internal static Cell NewCell(byte paletteId, byte tileId)
        {
            //int data = paletteId * 16 + tileId;
            int data = paletteId * 64 + tileId;

            return new Cell((byte)data);
        }

        internal bool IsNull()
        {
            bool isNull = PaletteId == 3 && TileId == 63;

            return isNull;
        }
    }
}