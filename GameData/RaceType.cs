using System.Collections.Generic;
using System.Diagnostics;

namespace GameData
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public struct RaceType
    {
        public static readonly RaceType Invalid = new RaceType(-1, "None", 0, 0);

        public int Id { get; }
        public string Name { get; }
        public int FarmingRate { get; }
        public int GrowthRateModifier { get; }

        private RaceType(int id, string name, int farmingRate, int growthRateModifier)
        {
            Id = id;
            Name = name;
            FarmingRate = farmingRate;
            GrowthRateModifier = growthRateModifier;
        }

        public static RaceType Create(int id, string name, int farmingRate, int growthRateModifier)
        {
            return new RaceType(id, name, farmingRate, growthRateModifier);
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay => $"{{Id={Id},Name={Name}}}";
    }

    /// <summary>
    /// This class is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class RaceTypes
    {
        private readonly Dictionary<int, RaceType> _items;

        private RaceTypes(List<RaceType> items)
        {
            _items = new Dictionary<int, RaceType>();
            foreach (RaceType item in items)
            {
                _items.Add(item.Id, item);
            }
        }

        public static RaceTypes Create(List<RaceType> items)
        {
            return new RaceTypes(items);
        }

        public int Count => _items.Count;

        public RaceType this[int index]
        {
            get
            {
                if (index < 0 || index > _items.Count - 1)
                {
                    return RaceType.Invalid;
                }

                return _items[index];
            }
        }

        private string DebuggerDisplay => $"{{Count={_items.Count}}}";
    }
}