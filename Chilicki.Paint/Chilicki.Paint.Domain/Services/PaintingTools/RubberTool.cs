using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class RubberTool : IPainterTool
    {
        private readonly double RubberScalerSize = 3;

        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints, 
            DrawingItemProperties properties)
        {
            foreach(var point in drawingPoints)
            {
                drawingList.Add(new RubberItem()
                {
                    Height = RubberScalerSize * properties.Thickness,
                    Width = RubberScalerSize * properties.Thickness,
                    Margin = new System.Windows.Thickness(point.X, point.Y, 0, 0),
                    Colour = new SolidColorBrush(Colors.White),
                });
            }            
            return drawingList;
        }
    }
}
