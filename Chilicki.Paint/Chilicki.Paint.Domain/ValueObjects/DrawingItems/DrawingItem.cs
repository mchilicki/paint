using System.Windows;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.ValueObjects.DrawingItems
{
    public abstract class DrawingItem
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Thickness { get; set; }
        public Brush Colour { get; set; }
    }
}
