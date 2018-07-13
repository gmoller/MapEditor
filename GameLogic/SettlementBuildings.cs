using System.Collections.Generic;
using GameData;

namespace GameLogic
{
    public class SettlementBuildings
    {
        private readonly Settlement _settlement;
        private readonly List<BuildingType> _buildings;

        public SettlementBuildings()
        {
            _buildings = new List<BuildingType>();
        }

        public void AddBuilding(BuildingType building)
        {
            _buildings.Add(building);
        }

        public bool HasBuilding(int buildingId)
        {
            foreach (var item in _buildings)
            {
                if (item.Id == buildingId) return true;
            }

            return false;
            //return _buildings.FirstOrDefault(item => item.Id == buildingId);
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

        public List<BuildingType> CanCurrentlyBuild()
        {
            List<BuildingType> canCurrentlyBuild = new List<BuildingType>();

            foreach (BuildingType item in Globals.Instance.BuildingTypes)
            {
                if (HasBuilding(item.Name)) continue; // already built - skip

                if (!item.Races.Contains(_settlement.RaceId)) continue; // race cannot build this - skip

                bool hasAllBuildings = true;
                foreach (int item2 in item.DependentBuildings)
                {
                    hasAllBuildings = HasBuilding(item2);
                }

                if (hasAllBuildings)
                {
                    canCurrentlyBuild.Add(item);
                }
            }

            return canCurrentlyBuild;
        }
    }
}