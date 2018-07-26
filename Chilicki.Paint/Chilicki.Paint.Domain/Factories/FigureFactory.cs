using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using System;
using System.Windows;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Factories
{
    public class FigureFactory
    {
        private readonly string ArgumentError = "No such figure";

        public DrawingItem Create(FigureType figure, double height, double width, double thickness, 
            Thickness margin, Brush brush)
        {
            switch (figure)
            {
                case FigureType.Rectangle:
                    return new RectangleItem(height, width, thickness, margin, brush);
                case FigureType.Circle:
                    return new CircleItem(height, width, thickness, margin, brush);
                default:
                    throw new ArgumentException(ArgumentError);
            }
        }
    }
}
