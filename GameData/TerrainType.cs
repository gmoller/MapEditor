﻿using System.Collections.Generic;
using System.Diagnostics;

namespace GameData
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public struct TerrainType
    {
        public static readonly TerrainType Invalid = new TerrainType(-1, "Invalid", -1);

        public int Id { get; }
        public string Name { get; }
        public int MovementCost { get; }

        private TerrainType(int id, string name, int movementCost)
        {
            Id = id;
            Name = name;
            MovementCost = movementCost;
        }

        public static TerrainType Create(int id, string name, int movementCost)
        {
            return new TerrainType(id, name, movementCost);
        }

        private string DebuggerDisplay => $"{{Id={Id},Name={Name}}}";
    }

    /// <summary>
    /// This class is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class TerrainTypes
    {
        private readonly Dictionary<int, TerrainType> _items;

        private TerrainTypes(List<TerrainType> items)
        {
            _items = new Dictionary<int, TerrainType>();
            foreach (TerrainType item in items)
            {
                _items.Add(item.Id, item);
            }
        }

        public static TerrainTypes Create(List<TerrainType> items)
        {
            return new TerrainTypes(items);
        }

        public int Count => _items.Count;

        public TerrainType this[int index]
        {
            get
            {
                if (index < 0 || index > _items.Count - 1)
                {
                    return TerrainType.Invalid;
                }

                return _items[index];
            }
        }

        private string DebuggerDisplay => $"{{Count={_items.Count}}}";
    }
}