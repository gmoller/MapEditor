namespace GameLogic.NewLocationCalculators
{
    public class WestCalculator : INewLocationCalculator
    {
        public Point Calculate(Point location)
        {
            return Point.Create(location.X - 1, location.Y);
        }
    }
}