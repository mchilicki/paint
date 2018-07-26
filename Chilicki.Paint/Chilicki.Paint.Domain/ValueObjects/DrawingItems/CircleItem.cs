using System.Windows;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.ValueObjects.DrawingItems
{
    public class CircleItem : DrawingItem
    {
        public CircleItem(double height, double width, double thickness, Thickness margin, Brush colour) 
            : base(height, width, thickness, margin, colour)
        {
        }
    }
}
