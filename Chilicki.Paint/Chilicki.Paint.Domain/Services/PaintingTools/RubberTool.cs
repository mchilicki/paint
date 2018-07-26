using System;
using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class RubberTool : IPainterTool
    {
        private readonly double RubberSize = 12;

        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints)
        {
            foreach(var point in drawingPoints)
            {
                drawingList.Add(new RubberItem()
                {
                    Height = RubberSize,
                    Width = RubberSize,
                    Margin = new System.Windows.Thickness(point.X, point.Y, 0, 0),
                });
            }            
            return drawingList;
        }
    }
}
