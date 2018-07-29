using System.Windows.Media;

namespace Chilicki.Paint.Domain.ValueObjects.DrawingItems
{
    public class PathItem : DrawingItem
    {
        public PointCollection Points { get; set; }

        public PathItem(double thickness, Brush colour, PointCollection points) 
            : base(thickness, colour)
        {
            Points = points;
        }
    }
}
