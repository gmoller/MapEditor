namespace GameLogic.NewLocationCalculators
{
    public class SouthEastCalculator : INewLocationCalculator
    {
        public Point Calculate(Point location)
        {
            return Point.Create(location.X + 1, location.Y - 1);
        }
    }
}