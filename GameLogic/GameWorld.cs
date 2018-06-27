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
        internal TerrainTypes TerrainTypes { get; }
        internal UnitTypes UnitTypes { get; }
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

        internal List<Point> GetCellNeighbors(Point location)
        {
            return GameBoard.GetCellNeighbors(location);
        }

        public bool IsCellVisible(Point location)
        {
            return GameBoard.IsCellVisible(location);
        }

        internal void SetCellVisible(Point location)
        {
            if (location.X < 0 || location.X > 31) return;
            if (location.Y < 0 || location.Y > 31) return;

            GameBoard.SetCellVisible(location);
        }

        internal void SetAllCellsInvisible()
        {
            GameBoard.SetAllCellsInvisible();
        }
    }
}