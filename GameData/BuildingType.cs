using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameData
{
    /// <summary>
    /// This struct is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public struct BuildingType
    {
        public static readonly BuildingType Invalid = new BuildingType(-1, "None", 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, new List<int>(), new List<int>());

        public int Id { get; }
        public string Name { get; }
        public float ConstructionCost { get; }
        public float UpkeepGold { get; }
        public float UpkeepMana { get; }
        public float FoodProduced { get; }
        public float GrowthRateIncrease { get; }
        public List<int> DependentBuildings { get; }
        public List<int> Races { get; }

        private BuildingType(int id, string name, float constructionCost, float upkeepGold, float upkeepMana, float foodProduced, float growthRateIncrease, List<int> dependentBuildings, List<int> races)
        {
            Id = id;
            Name = name;
            ConstructionCost = constructionCost;
            UpkeepGold = upkeepGold;
            UpkeepMana = upkeepMana;
            FoodProduced = foodProduced;
            GrowthRateIncrease = growthRateIncrease;
            DependentBuildings = dependentBuildings;
            Races = races;
        }

        public static BuildingType Create(int id, string name, float constructionCost, float upkeepGold, float upkeepMana, float foodProduced, float growthRateIncrease, List<int> dependentBuildings, List<int> races)
        {
            return new BuildingType(id, name, constructionCost, upkeepGold, upkeepMana, foodProduced, growthRateIncrease, dependentBuildings, races);
        }

        private string DebuggerDisplay => $"{{Id={Id},Name={Name}}}";
    }

    /// <summary>
    /// This class is immutable.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class BuildingTypes : IEnumerable<BuildingType>
    {
        private readonly Dictionary<int, BuildingType> _items;

        private BuildingTypes(List<BuildingType> items)
        {
            _items = new Dictionary<int, BuildingType>();
            foreach (BuildingType item in items)
            {
                _items.Add(item.Id, item);
            }
        }

        public static BuildingTypes Create(List<BuildingType> items)
        {
            return new BuildingTypes(items);
        }

        public int Count => _items.Count;

        public BuildingType this[int index]
        {
            get
            {
                if (index < 0 || index > _items.Count - 1)
                {
                    return BuildingType.Invalid;
                }

                return _items[index];
            }
        }

        public IEnumerator<BuildingType> GetEnumerator()
        {
            foreach (KeyValuePair<int, BuildingType> item in _items)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private string DebuggerDisplay => $"{{Count={_items.Count}}}";
    }
}