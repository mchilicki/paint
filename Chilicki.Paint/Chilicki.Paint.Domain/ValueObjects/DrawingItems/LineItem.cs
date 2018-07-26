using System.Windows;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.ValueObjects.DrawingItems
{
    public class LineItem : DrawingItem
    {
        public double StartPointX { get; set; }
        public double StartPointY { get; set; }
        public double EndPointX { get; set; }
        public double EndPointY { get; set; }

        public LineItem(Point startPoint, Point endPoint, double thickness, Brush brush)
            : base(thickness, brush)
        {
            StartPointX = startPoint.X;
            StartPointY = startPoint.Y;
            EndPointX = endPoint.X;
            EndPointY = endPoint.Y;
        }
    }
}
