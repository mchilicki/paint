using System;
using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class PencilTool : IPainterTool
    {
        private readonly double PencilSize = 15;

        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints)
        {
            foreach (var point in drawingPoints)
            {
                drawingList.Add(new PencilItem()
                {
                    Height = PencilSize,
                    Width = PencilSize,
                    Margin = new System.Windows.Thickness(point.X, point.Y, 0, 0),
                });
            }
            return drawingList;
        }
    }
}
