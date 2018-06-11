using System.Collections.Generic;

namespace GameLogic
{
    public class GameWorld
    {
        public GameBoard Board { get; }
        public TerrainTypes TerrainTypes { get; }

        private GameWorld(int numberOfColumns, int numberOfRows, int[] terrainTypes, List<TerrainType> terrainTypeList)
        {
            Board = GameBoard.Create(numberOfColumns, numberOfRows, terrainTypes);
            TerrainTypes = TerrainTypes.Create(terrainTypeList);
        }

        public static GameWorld Create(int numberOfColumns, int numberOfRows, int[] terrainTypes, List<TerrainType> terrainTypeList)
        {
            return new GameWorld(numberOfColumns, numberOfRows, terrainTypes, terrainTypeList);
        }
    }
}