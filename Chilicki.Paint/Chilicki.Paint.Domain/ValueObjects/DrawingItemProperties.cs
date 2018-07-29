using System.Windows.Media;

namespace Chilicki.Paint.Domain.ValueObjects
{
    public class DrawingItemProperties
    {
        public Color Color { get; set; }

        public DrawingItemProperties(Color color)
        {
            Color = color;
        }
    }
}
