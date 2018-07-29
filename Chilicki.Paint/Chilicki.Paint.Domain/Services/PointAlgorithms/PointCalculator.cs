using Chilicki.Paint.Common.Maths;
using Chilicki.Paint.Domain.ValueObjects;

namespace Chilicki.Paint.Domain.Services.PointAlgorithms
{
    public class PointCalculator
    {
        public static Point GetCenter(Point point1, Point point2)
        {
            return new Point(Math.Average(point1.X, point2.X), 
                             Math.Average(point1.Y, point2.Y));
        }

        public static double GetLenght(Point point1, Point point2)
        {
            return System.Math.Sqrt(
                System.Math.Pow(point2.X - point1.X, 2) + 
                System.Math.Pow(point2.Y - point1.Y, 2));
        }
    }
}
