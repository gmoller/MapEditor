using System.Collections.Generic;
using System.Linq;
using GameData;

namespace GameLogic
{
    public class SettlementBuildings
    {
        private readonly List<BuildingType> _buildings;

        public SettlementBuildings()
        {
            _buildings = new List<BuildingType>();
        }

        public void AddBuilding(BuildingType building)
        {
            _buildings.Add(building);
        }

        public bool HasBuilding(string buildingName)
        {
            foreach (var item in _buildings)
            {
                if (item.Name == buildingName) return true;
            }

            return false;
            //return _buildings.FirstOrDefault(item => item.Name == buildingName);
        }

        public List<BuildingType> CanBuild()
        {
            return null;
        }
    }
}