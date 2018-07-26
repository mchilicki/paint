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
        public Brush Brush { get; set; }
        public Thickness Margin { get; set; }

        public DrawingItem(double thickness, Brush brush)
        {
            Thickness = thickness;
            Brush = brush;
        }

        public DrawingItem(double height, double width, double thickness, Thickness margin, Brush brush)
        {
            Height = height;
            Width = width;
            Margin = margin;
            Brush = brush;
            Thickness = thickness;
        }
    }
}
