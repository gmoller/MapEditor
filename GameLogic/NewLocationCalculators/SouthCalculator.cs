namespace GameLogic.NewLocationCalculators
{
    public class SouthCalculator : INewLocationCalculator
    {
        public Point Calculate(Point location)
        {
            return Point.Create(location.X, location.Y - 1);
        }
    }
}