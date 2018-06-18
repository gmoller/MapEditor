using System.Collections.Generic;

namespace GameLogic
{
    /// <summary>
    /// Contains accessors to the GameBoard, list of TerrainTypes and list of UnitTypes.
    /// This class is immutable.
    /// </summary>
    public class GameWorld
    {
        public GameBoard Board { get; }
        public Player Player { get; }
        public TerrainTypes TerrainTypes { get; }
        public UnitTypes UnitTypes { get; }

        private GameWorld(int numberOfColumns, int numberOfRows, int[] terrainTypes, List<TerrainType> terrainTypeList, List<UnitType> unitTypeList)
        {
            Board = GameBoard.Create(numberOfColumns, numberOfRows, terrainTypes);
            Player = new Player(this);
            TerrainTypes = TerrainTypes.Create(terrainTypeList);
            UnitTypes = UnitTypes.Create(unitTypeList);
        }

        public static GameWorld Create(int numberOfColumns, int numberOfRows, int[] terrainTypes, List<TerrainType> terrainTypeList, List<UnitType> unitTypeList)
        {
            return new GameWorld(numberOfColumns, numberOfRows, terrainTypes, terrainTypeList, unitTypeList);
        }
    }
}