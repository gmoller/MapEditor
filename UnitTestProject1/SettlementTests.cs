﻿using GameLogic;
using GameMap;
using GeneralUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class SettlementTests
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            var terrain = new[,]
            {
                { 0, 0, 0, 0, 0}, // { 0,1,1,1,0 },
                { 0, 0, 0, 0, 0}, // { 1,1,1,1,1 },
                { 0, 0, 0, 0, 0}, // { 1,1,1,1,1 },
                { 0, 0, 0, 0, 0}, // { 1,1,1,1,1 },
                { 0, 0, 0, 0, 0}, // { 0,1,1,1,0 }
            };
            GameBoard gameBoard = GameBoard.Create(1, terrain, true);
            Globals.Instance.GameWorld.SetGameBoard(gameBoard);
            Globals.Instance.GameWorld.SetPlayer2(new Player2());
        }

        [TestMethod]
        public void Barbarian_settlement_of_1()
        {
            Player player = new Player();
            player.AddSettlement("Margeritaville", Point2.Create(2, 2), Globals.Instance.RaceTypes[0]); // Barbarians
            Globals.Instance.GameWorld.SetPlayer(player);

            Settlement settlement = Globals.Instance.GameWorld.GetPlayerSettlementOnCell(Point2.Create(2, 2));

            Assert.AreEqual(SettlementType.Hamlet, settlement.SettlementType, "SettlementType incorrect."); // Note: SettlementType could be de-hardcoded
            Assert.AreEqual("Margeritaville", settlement.Name, "Settlement Name incorrect.");
            Assert.AreEqual("Barbarians", settlement.RaceName, "Settlement RaceName incorrect.");
            Assert.AreEqual(1, settlement.SettlementSize, "Settlement SettlementSize incorrect.");
            Assert.AreEqual(1000, settlement.Population, "Settlement Population incorrect.");
            Assert.AreEqual(150, settlement.GrowthRate, "Settlement GrowthRate incorrect.");

            Assert.AreEqual(1, settlement.SubsistenceFarmers, "Settlement SubsistenceFarmers incorrect.");
            Assert.AreEqual(0, settlement.AdditionalFarmers, "Settlement AdditionalFarmers incorrect.");
            Assert.AreEqual(0, settlement.TotalWorkers, "Settlement Workers incorrect.");
            Assert.AreEqual(0, settlement.TotalRebels, "Settlement Rebels incorrect.");

            Assert.AreEqual(1, settlement.FoodConsumption, "Settlement FoodConsumption incorrect.");
            Assert.AreEqual(1, settlement.FoodSurplus, "Settlement FoodSurplus incorrect.");
            Assert.AreEqual(0, settlement.Production, "Settlement Production incorrect.");
            //settlement.GoldUpkeep
            //settlement.GoldSurplus
            //settlement.Power
            //settlement.Research

            //settlement.Enchantments
            //settlement.Buildings
            //settlement.Surroundings
            //settlement.Units
            //settlement.Producing
        }

        [TestMethod]
        public void Darkelf_settlement_of_1()
        {
            Player player = new Player();
            player.AddSettlement("Margeritaville", Point2.Create(2, 2), Globals.Instance.RaceTypes[2]); // Dark Elf
            Globals.Instance.GameWorld.SetPlayer(player);

            Settlement settlement = Globals.Instance.GameWorld.GetPlayerSettlementOnCell(Point2.Create(2, 2));

            Assert.AreEqual(SettlementType.Hamlet, settlement.SettlementType, "SettlementType incorrect."); // Note: SettlementType could be de-hardcoded
            Assert.AreEqual("Margeritaville", settlement.Name, "Settlement Name incorrect.");
            Assert.AreEqual("Dark Elves", settlement.RaceName, "Settlement RaceName incorrect.");
            Assert.AreEqual(1, settlement.SettlementSize, "Settlement SettlementSize incorrect.");
            Assert.AreEqual(1000, settlement.Population, "Settlement Population incorrect.");
            Assert.AreEqual(110, settlement.GrowthRate, "Settlement GrowthRate incorrect.");

            Assert.AreEqual(1, settlement.SubsistenceFarmers, "Settlement SubsistenceFarmers incorrect.");
            Assert.AreEqual(0, settlement.AdditionalFarmers, "Settlement AdditionalFarmers incorrect.");
            Assert.AreEqual(0, settlement.TotalWorkers, "Settlement Workers incorrect.");
            Assert.AreEqual(0, settlement.TotalRebels, "Settlement Rebels incorrect.");

            Assert.AreEqual(1, settlement.FoodConsumption, "Settlement FoodConsumption incorrect.");
            Assert.AreEqual(1, settlement.FoodSurplus, "Settlement FoodSurplus incorrect.");
            Assert.AreEqual(0, settlement.Production, "Settlement Production incorrect.");
            //settlement.GoldUpkeep
            //settlement.GoldSurplus
            //settlement.Power
            //settlement.Research

            //settlement.Enchantments
            //settlement.Buildings
            //settlement.Surroundings
            //settlement.Units
            //settlement.Producing
        }
    }
}