﻿using System.Collections.Generic;
using System.IO;

namespace GameLogic.Loaders
{
    public static class TerrainTypesLoader
    {
        public static List<TerrainType> GetTerrainTypes()
        {
            var terrainTypes = new List<TerrainType>();

            IEnumerable<string> lines = File.ReadLines("TerrainTypes.txt");

            foreach (string line in lines)
            {
                if (line.StartsWith("--")) continue;
                string[] splitLine = line.Split(',');
                int id = splitLine[0].ToInt32();
                string name = splitLine[1];
                int movementCost = splitLine[2].ToInt32();
                TerrainType terrainType = TerrainType.Create(id, name, movementCost);
                terrainTypes.Add(terrainType);
            }

            return terrainTypes;
        }
    }
}