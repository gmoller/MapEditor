using System;
using System.Collections.Generic;
using GameData;
using GameMap;
using GeneralUtilities;

namespace GameLogic
{
    /// <summary>
    /// A settlement is an immovable game entity that can be controlled by the
    /// player/AI to do things such as build new units and add buildings to
    /// improve the city.
    /// </summary>
    public class Settlement
    {
        private const int MAXIMUM_POPULATION_CAP = 25;

        private readonly RaceType _race;

        public string Name { get; }
        public Point2 Location { get; }
        public int Residents { get; private set; } // every 1 population is 1,000 residents
        public Population Population { get; private set; }
        public string RaceName => _race.Name;
        public int GrowthRate => DetermineGrowthRate();
        public int FoodConsumption => Population.Total;
        public int FoodSurplus => DetermineFoodProductionPerTurn() - Population.Total;

        public SettlementType SettlementType
        {
            get
            {
                if (Population.Total <= 4)
                    return SettlementType.Hamlet;
                if (Population.Total >= 5 && Population.Total <= 8)
                    return SettlementType.Village;
                if (Population.Total >= 9 && Population.Total <= 12)
                    return SettlementType.Town;
                if (Population.Total >= 13 && Population.Total <= 16)
                    return SettlementType.City;
                if (Population.Total >= 17)
                    return SettlementType.Capital;

                throw new Exception("Unknown settlement type.");
            }
        }

        private Settlement(string name, RaceType raceType, Point2 location, int population)
        {
            Name = name;
            _race = raceType;
            Location = location;
            Residents = population * 1000;

            int farmersSubsistence = CalculateSubsistenceFarmers(population, 0);
            Population = new Population(farmersSubsistence, population - farmersSubsistence, 0, 0); // defaults to all farmers
        }

        public static Settlement CreateNew(string name, RaceType raceType, Point2 location, int population)
        {
            var settlement = new Settlement(name, raceType, location, population);

            return settlement;
        }

        private int DetermineFoodProductionPerTurn() // FoodProduction
        {
            int farmingRate = _race.FarmingRate; // SettlementHasAnimistsGuild ? 3 : RaceType.FarmingRate;
            int fromFarmers = Population.TotalFarmers * farmingRate;
            /////int fromForestersGuild = SettlementHasForestersGuild ? 2 : 0;
            int foodProductionPerTurn = fromFarmers + 0; //fromForestersGuild
            ////foodProductionPerTurn = IsCityEnchantmentFamineActive ? foodProductionPerTurn / 2 : foodProductionPerTurn;

            int baseFoodLevel = DetermineBaseFoodLevel();
            if (foodProductionPerTurn > baseFoodLevel)
            {
                int excess = (foodProductionPerTurn - baseFoodLevel) / 2;
                foodProductionPerTurn = baseFoodLevel + excess;
            }

            /////foodProductionPerTurn = SettlementHasGranary ? foodProductionPerTurn + 2 : foodProductionPerTurn;
            /////foodProductionPerTurn = SettlementHasFarmersMarket ? foodProductionPerTurn + 3 : foodProductionPerTurn;
            foodProductionPerTurn += GetMineralFoodModifierFromTerrain(Location);
            //foodProductionPerTurn += NumberOfSharedWildGameTiles;

            return foodProductionPerTurn;
        }

        private int CalculateSubsistenceFarmers(int totalPopulation, int rebelPopulation)
        {
            int foodNeeded = totalPopulation;
            // subtract food from granary, farmers market, foresters guild

            float farmersSubsistenceFloat = foodNeeded / (float)_race.FarmingRate;
            int farmersSubsistence = (int)Math.Ceiling(farmersSubsistenceFloat);

            if (totalPopulation - rebelPopulation >= farmersSubsistence)
            {
                return farmersSubsistence;
            }

            return totalPopulation - rebelPopulation;
        }

        private int DetermineGrowthRate()
        {
            int maxSettlementSize = DetermineMaximumSettlementSize();
            if (Population.Total >= maxSettlementSize) return 0;

            float baseGrowthRate = (maxSettlementSize - Population.Total + 1) / 2.0f;
            int baseGrowthRateRoundedUp = (int)Math.Ceiling(baseGrowthRate);

            var adjustedGrowthRate = baseGrowthRateRoundedUp * 10 + _race.GrowthRateModifier;

            //// stream of life (+100%)
            //// housing project (0-125%)
            //// dark rituals (-25%)

            return adjustedGrowthRate;
        }

        private int DetermineMaximumSettlementSize() // MaximumPopulation
        {
            int baseFoodLevel = DetermineBaseFoodLevel();
            ////baseFoodLevel = IsCityEnchantmentFamineActive ? baseFoodLevel / 2 : baseFoodLevel;
            /////baseFoodLevel = SettlementHasGranary ? baseFoodLevel + 2 : baseFoodLevel;
            /////baseFoodLevel = SettlementHasFarmersMarket ? baseFoodLevel + 3 : baseFoodLevel;
            baseFoodLevel += GetMineralFoodModifierFromTerrain(Location);
            //baseFoodLevel += NumberOfSharedWildGameTiles;

            return baseFoodLevel > MAXIMUM_POPULATION_CAP ? MAXIMUM_POPULATION_CAP : baseFoodLevel;
        }

        private int DetermineBaseFoodLevel() // BaseFoodLevel (used by Surveyor before creating a settlement)
        {
            // Each city has a base food level of Food it can produce
            int baseFoodLevel = GetBaseFoodLevelFromTerrain(Location);

            ////baseFoodLevel = IsCityEnchantmentGaiasBlessingActive ? baseFoodLevel * 1.5f : baseFoodLevel;

            return baseFoodLevel;
        }

        private int GetBaseFoodLevelFromTerrain(Point2 location)
        {
            float baseFoodLevelFromTerrain = 0.0f;

            List<Cell> cells = GetSettlementCells(location);
            foreach (Cell item in cells)
            {
                baseFoodLevelFromTerrain += Globals.Instance.TerrainTypes[item.TerrainTypeId].FoodOutput;
            }

            return (int)baseFoodLevelFromTerrain;
        }

        private int GetMineralFoodModifierFromTerrain(Point2 location)
        {
            float wildGameFromTerrain = 0.0f;

            List<Cell> cells = GetSettlementCells(location);
            foreach (Cell item in cells)
            {
                wildGameFromTerrain += Globals.Instance.MineralTypes[item.MineralTypeId].FoodModifier;
            }

            return (int)wildGameFromTerrain;
        }

        private List<Cell> GetSettlementCells(Point2 location)
        {
            var cells = new List<Cell>
            {
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X - 1, location.Y - 2)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X, location.Y - 2)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X + 1, location.Y - 2)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X - 2, location.Y - 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X - 1, location.Y - 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X, location.Y - 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X + 1, location.Y - 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X + 2, location.Y - 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X - 2, location.Y)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X - 1, location.Y)),
                Globals.Instance.GameWorld.GetCell(location),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X + 1, location.Y)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X + 2, location.Y)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X - 2, location.Y + 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X - 1, location.Y + 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X, location.Y + 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X + 1, location.Y + 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X + 2, location.Y + 1)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X - 1, location.Y + 2)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X, location.Y + 2)),
                Globals.Instance.GameWorld.GetCell(Point2.Create(location.X + 1, location.Y + 2))
            };

            return cells;
        }
    }
}