using System.Collections.Generic;
using GameLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        private static readonly List<TerrainType> TerrainTypeList = new List<TerrainType>
            {
                TerrainType.Create(0, "Grassland", 1),
                TerrainType.Create(1, "Forest", 2),
                TerrainType.Create(2, "Desert", 1),
                TerrainType.Create(3, "Swamp", 3),
                TerrainType.Create(4, "River", 2),
                TerrainType.Create(5, "River Mouth", 2),
                TerrainType.Create(6, "Hills", 3),
                TerrainType.Create(7, "Mountain", 4),
                TerrainType.Create(8, "Volcano", 4),
                TerrainType.Create(9, "Tundra", 2),
                TerrainType.Create(10, "Shore", -1),
                TerrainType.Create(11, "Ocean", -1)
            };

        private static GameWorld _gameWorld;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _gameWorld = GameWorld.Create(3, 3, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, TerrainTypeList);
        }

        [TestMethod]
        public void Unit_can_move_north()
        {
            Unit unit = CreateUnit(Point.Create(1, 1));
            MoveUnit(unit, CompassDirection.North, Point.Create(1, 2));
        }

        [TestMethod]
        public void Unit_can_move_northeast()
        {
            Unit unit = CreateUnit(Point.Create(1, 1));
            MoveUnit(unit, CompassDirection.NorthEast, Point.Create(2, 2));
        }

        [TestMethod]
        public void Unit_can_move_east()
        {
            Unit unit = CreateUnit(Point.Create(1, 1));
            MoveUnit(unit, CompassDirection.East, Point.Create(2, 1));
        }

        [TestMethod]
        public void Unit_can_move_southeast()
        {
            Unit unit = CreateUnit(Point.Create(1, 1));
            MoveUnit(unit, CompassDirection.SouthEast, Point.Create(2, 0));
        }

        [TestMethod]
        public void Unit_can_move_south()
        {
            Unit unit = CreateUnit(Point.Create(1, 1));
            MoveUnit(unit, CompassDirection.South, Point.Create(1, 0));
        }

        [TestMethod]
        public void Unit_can_move_southwest()
        {
            Unit unit = CreateUnit(Point.Create(1, 1));
            MoveUnit(unit, CompassDirection.SouthWest, Point.Create(0, 0));
        }

        [TestMethod]
        public void Unit_can_move_west()
        {
            Unit unit = CreateUnit(Point.Create(1, 1));
            MoveUnit(unit, CompassDirection.West, Point.Create(0, 1));
        }

        [TestMethod]
        public void Unit_can_move_northwest()
        {
            Unit unit = CreateUnit(Point.Create(1, 1));
            MoveUnit(unit, CompassDirection.NorthWest, Point.Create(0, 2));
        }

        [TestMethod]
        public void Unit_can_move_east_twice_in_one_turn()
        {
            Unit unit = CreateUnit(Point.Empty);
            unit = MoveUnit(unit, CompassDirection.East, Point.Create(1, 0));
            MoveUnit(unit, CompassDirection.East, Point.Create(2, 0), 0.0f);
        }

        [TestMethod]
        public void Unit_can_not_move_east_three_times_in_one_turn()
        {
            Unit unit = CreateUnit(Point.Empty);
            unit = MoveUnit(unit, CompassDirection.East, Point.Create(1, 0));
            unit = MoveUnit(unit, CompassDirection.East, Point.Create(2, 0), 0.0f);
            MoveUnit(unit, CompassDirection.East, Point.Create(2, 0), 0.0f);
        }

        private Unit CreateUnit(Point startLocation)
        {
            var unit = Unit.Create(_gameWorld, startLocation, 2.0f);

            return unit;
        }

        private Unit MoveUnit(Unit unit, CompassDirection compassDirection, Point expectedLocation, float expectedMovementPoints = 1.0f)
        {
            unit = unit.Move(compassDirection);

            Assert.AreEqual(expectedLocation, unit.Location);
            Assert.AreEqual(unit.Location.X, expectedLocation.X);
            Assert.AreEqual(unit.Location.Y, expectedLocation.Y);
            Assert.AreEqual(expectedMovementPoints, unit.MovementPoints);

            return unit;
        }
    }
}