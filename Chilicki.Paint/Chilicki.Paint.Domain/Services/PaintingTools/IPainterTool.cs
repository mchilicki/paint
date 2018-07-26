using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public interface IPainterTool
    {
        IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints);
    }
}
