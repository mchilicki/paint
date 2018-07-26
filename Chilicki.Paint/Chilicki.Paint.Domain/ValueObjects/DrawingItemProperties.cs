using System.Windows;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.ValueObjects
{
    public class DrawingItemProperties
    {
        public double Thickness { get; set; }
        public Color Colour { get; set; }

        public DrawingItemProperties(double thickness, Color colour)
        {
            Thickness = thickness;
            Colour = colour;
        }
    }
}
