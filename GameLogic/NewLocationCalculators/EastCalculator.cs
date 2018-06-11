namespace GameLogic.NewLocationCalculators
{
    internal class EastCalculator : INewLocationCalculator
    {
        public Point Calculate(Point location)
        {
            return Point.Create(location.X + 1, location.Y);
        }
    }
}