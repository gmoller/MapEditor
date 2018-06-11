﻿namespace GameLogic.NewLocationCalculators
{
    internal class SouthCalculator : INewLocationCalculator
    {
        public Point Calculate(Point location)
        {
            return Point.Create(location.X, location.Y - 1);
        }
    }
}