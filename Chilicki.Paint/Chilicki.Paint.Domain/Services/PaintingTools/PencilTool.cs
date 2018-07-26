using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class PencilTool : IPainterTool
    {
        private readonly double PencilSize = 3;

        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints,
            DrawingItemProperties properties)
        {
            foreach (var point in drawingPoints)
            {
                drawingList.Add(new PencilItem()
                {
                    Height = PencilSize * properties.Thickness,
                    Width = PencilSize * properties.Thickness,
                    Margin = new System.Windows.Thickness(point.X, point.Y, 0, 0),
                    Colour = new SolidColorBrush(properties.Colour),
                });
            }
            return drawingList;
        }
    }
}
