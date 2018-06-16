using System.Collections.Generic;
using System.Diagnostics;

namespace GameLogic
{
    /// <summary>
    /// This class is immutable.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class TerrainTypes
    {
        private readonly Dictionary<int, TerrainType> _terrainTypes;

        private TerrainTypes(List<TerrainType> terrainTypes)
        {
            _terrainTypes = new Dictionary<int, TerrainType>();
            foreach (TerrainType item in terrainTypes)
            {
                _terrainTypes.Add(item.Id, item);
            }
        }

        public static TerrainTypes Create(List<TerrainType> terrainTypes)
        {
            return new TerrainTypes(terrainTypes);
        }

        public TerrainType this[int index]
        {
            get
            {
                if (index < 0 || index > _terrainTypes.Count - 1)
                {
                    return TerrainType.Invalid;
                }

                return _terrainTypes[index];
            }
        }

        private string DebuggerDisplay => $"{{Count={_terrainTypes.Count}}}";
    }
}