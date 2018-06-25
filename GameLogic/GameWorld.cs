using System.Collections.Generic;

namespace GameLogic
{
    /// <summary>
    /// Contains accessors to the GameBoard, list of TerrainTypes and list of UnitTypes.
    /// This class is immutable.
    /// </summary>
    public class GameWorld
    {
        private Player Player { get; }

        public GameBoard GameBoard { get; }
        public TerrainTypes TerrainTypes { get; }
        public UnitTypes UnitTypes { get; }
        public IEnumerable<Unit> PlayerUnits => Player.Units;

        private GameWorld(GameBoard map, List<TerrainType> terrainTypeList, List<UnitType> unitTypeList)
        {
            GameBoard = map;
            Player = new Player(this);
            TerrainTypes = TerrainTypes.Create(terrainTypeList);
            UnitTypes = UnitTypes.Create(unitTypeList);
        }

        public static GameWorld Create(GameBoard gameBoard, List<TerrainType> terrainTypeList, List<UnitType> unitTypeList)
        {
            return new GameWorld(gameBoard, terrainTypeList, unitTypeList);
        }

        public string DoTurnForPlayer()
        {
            return Player.DoTurn();
        }

        public void EndTurnForPlayer()
        {
            Player.EndTurn();
        }

        public void AddUnitForPlayer(int unitType, Point startLocation, GameWorld gameWorld)
        {
            Player.AddUnit(unitType, startLocation, gameWorld);
        }

        public Cell GetCell(Point location)
        {
            return GameBoard.GetCell(location);
        }
    }
}