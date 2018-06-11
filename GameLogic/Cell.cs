﻿using System.Diagnostics;

namespace GameLogic
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public struct Cell
    {
        public static readonly Cell Null = new Cell(-1);

        public int TerrainTypeId { get; }

        private Cell(int terrainTypeId)
        {
            TerrainTypeId = terrainTypeId;
        }

        public static Cell Create(int terrainTypeId)
        {
            return new Cell(terrainTypeId);
        }

        private string DebuggerDisplay => $"{{TerrainTypeId={TerrainTypeId}}}";
    }
}