using System.Windows;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.ValueObjects
{
    public class DrawingItemProperties
    {
        public double Thickness { get; set; }
        public Brush Brush { get; set; }

        public DrawingItemProperties(double thickness, Brush brush)
        {
            Thickness = thickness;
            Brush = brush;
        }
    }
}
