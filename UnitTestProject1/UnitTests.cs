using System.Collections.Generic;
using GameLogic;
using GameLogic.Loaders;
using GameLogic.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        private static GameWorld _gameWorld;
        private static MovementProcessor _movementProcessor;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            List<TerrainType> terrainTypes = TerrainTypesLoader.GetTerrainTypes();
            List<UnitType> unitTypes = UnitTypesLoader.GetUnitTypes();
            _gameWorld = GameWorld.Create(3, 3, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, terrainTypes, unitTypes);
            _movementProcessor = new MovementProcessor(_gameWorld);
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
            var unit = Unit.CreateNew(4, startLocation, _gameWorld);

            return unit;
        }

        private Unit MoveUnit(Unit unit, CompassDirection compassDirection, Point expectedLocation, float expectedMovementPoints = 1.0f)
        {
            unit = unit.Move(_movementProcessor, compassDirection);

            Assert.AreEqual(expectedLocation, unit.Location, "Location incorrect.");
            Assert.AreEqual(expectedLocation.X, unit.Location.X, "Location.X incorrect.");
            Assert.AreEqual(expectedLocation.Y, unit.Location.Y, "Location.Y inocrrect.");
            Assert.AreEqual(expectedMovementPoints, unit.MovementPoints, "MovementPoints incorrect.");

            return unit;
        }
    }
}