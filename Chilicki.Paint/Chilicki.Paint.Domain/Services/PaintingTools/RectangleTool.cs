using System;
using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    class RectangleTool : IPainterTool
    {
        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints, 
            DrawingItemProperties properties)
        {
            throw new NotImplementedException();
        }
    }
}
