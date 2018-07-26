using System;
using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class EmptyTool : IPainterTool
    {
        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints)
        {
            return drawingList;
        }
    }
}
