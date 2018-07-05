using System;
using System.Collections.Generic;
using GameData;

namespace GameLogic
{
    public sealed class Globals
    {
        private static readonly Lazy<Globals> Lazy = new Lazy<Globals>(() => new Globals());

        public MovementTypes MovementTypes { get; }
        public TerrainTypes TerrainTypes { get; }
        public UnitTypes UnitTypes { get; }

        public static Globals Instance => Lazy.Value;

        private Globals()
        {
            MovementTypes = MovementTypes.Create(new List<MovementType> { MovementType.Create(1, "Ground") });
            TerrainTypes = TerrainTypes.Create(TerrainTypesLoader.GetTerrainTypes());
            UnitTypes = UnitTypes.Create(UnitTypesLoader.GetUnitTypes(MovementTypes));
        }
    }
}