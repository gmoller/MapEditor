namespace GameLogic.NewLocationCalculators
{
    internal class NorthCalculator : INewLocationCalculator
    {
        public Point Calculate(Point location)
        {
            return Point.Create(location.X, location.Y + 1);
        }
    }
}