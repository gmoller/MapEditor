using System.Collections.Generic;
using System.IO;
using GeneralUtilities;

namespace GameData.Loaders
{
    public static class BuildingTypesLoader
    {
        public static List<BuildingType> GetBuildingTypes()
        {
            var buildingTypes = new List<BuildingType>();

            IEnumerable<string> lines = File.ReadLines("BuildingTypes.txt");

            foreach (string line in lines)
            {
                if (line.StartsWith("--")) continue;
                string[] splitLine = line.Split(',');
                int id = splitLine[0].ToInt32();
                string name = splitLine[1];
                float productionCost = splitLine[2].ToFloat();
                float upkeepGold = splitLine[3].ToFloat();
                float upkeepMana = splitLine[4].ToFloat();
                float foodProduced = splitLine[5].ToFloat();
                float growthRateIncrease = splitLine[6].ToFloat();

                BuildingType mineralType = BuildingType.Create(id, name, productionCost, upkeepGold, upkeepMana, foodProduced, growthRateIncrease);
                buildingTypes.Add(mineralType);
            }

            return buildingTypes;
        }
    }
}