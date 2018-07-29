using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.Aggregates;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public interface IPainterTool
    {
        PixelCollection Draw(PixelCollection pixels, IList<Point> drawingPoints, 
            DrawingItemProperties properties);
    }
}
