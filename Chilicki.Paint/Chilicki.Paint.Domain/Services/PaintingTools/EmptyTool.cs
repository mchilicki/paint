using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class EmptyTool : IPainterTool
    {
        public List<DrawingItem> Draw(List<DrawingItem> drawingList, Point drawingStartPoint, Point drawingEndPoint)
        {
            return drawingList;
        }
    }
}
