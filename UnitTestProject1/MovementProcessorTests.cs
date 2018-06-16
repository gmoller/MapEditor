using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameLogic;
using GameLogic.Loaders;
using GameLogic.NewLocationCalculators;
using GameLogic.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MovementProcessorTests
    {
        private static GameWorld _gameWorld;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            List<TerrainType> terrainTypes = TerrainTypesLoader.GetTerrainTypes();
            List<UnitType> unitTypes = UnitTypesLoader.GetUnitTypes();
            _gameWorld = GameWorld.Create(3, 3, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, terrainTypes, unitTypes);
        }

        [TestMethod]
        public void Unit_can_move_east()
        {
            var movementProcessor = new MovementProcessor(_gameWorld);

            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(CompassDirection.East);

            Stopwatch sw = Stopwatch.StartNew();
            ProcessResponse response = movementProcessor.Process(new ProcessRequest(Point.Empty, 2.0f), newLocationCalculator);
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            Unit unit = Unit.Create(0, response.NewLocation, response.NewMovementPoints, _gameWorld);

            Assert.AreEqual(Point.Create(1, 0), unit.Location, "Location incorrect.");
            Assert.AreEqual(1.0f, unit.MovementPoints, "MovementPoints incorrect.");
        }

        [TestMethod]
        public void Multiple_units_can_move_east_single_threaded()
        {
            var movementProcessor = new MovementProcessor(_gameWorld);

            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(CompassDirection.East);

            const int repetitions = 1000;

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < repetitions; i++)
            {
                movementProcessor.Process(new ProcessRequest(Point.Empty, 2.0f), newLocationCalculator);
            }
            sw.Stop();

            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms for {repetitions}.");
        }

        [TestMethod]
        public void Unit_can_move_east_in_parallel()
        {
            var movementProcessor = new MovementProcessor(_gameWorld);

            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(CompassDirection.East);

            ProcessRequest[] requests = { new ProcessRequest(Point.Empty, 2.0f) };

            Stopwatch sw = Stopwatch.StartNew();
            ProcessResponse[] response = movementProcessor.Process(requests, newLocationCalculator);
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            Assert.AreEqual(Point.Create(1, 0), response[0].NewLocation, "NewLocation incorrect.");
            Assert.AreEqual(1.0f, response[0].NewMovementPoints, "NewMovementPoints incorrect.");
        }

        [TestMethod]
        public void Multiple_units_can_move_east_in_parallel()
        {
            const int repetitions = 1;

            var movementProcessor = new MovementProcessor(_gameWorld);

            INewLocationCalculator newLocationCalculator = NewLocationCalculatorFactory.GetNewLocationCalculator(CompassDirection.East);

            var requests = new ProcessRequest[repetitions];

            for (int i = 0; i < repetitions; i++)
            {
                requests[i] = new ProcessRequest(Point.Empty, 2.0f + i);
            }

            Stopwatch sw = Stopwatch.StartNew();
            ProcessResponse[] response = movementProcessor.Process(requests, newLocationCalculator);
            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");

            int cnt = 0;
            foreach (ProcessResponse item in response)
            {
                Assert.AreEqual(1.0f + cnt, item.NewMovementPoints, "NewMovementPoints incorrect.");
                cnt++;
            }
        }
    }
}