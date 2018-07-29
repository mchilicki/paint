using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.Aggregates;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class PencilTool : IPainterTool
    {
        private LineTool _lineTool;

        public PencilTool(LineTool lineTool)
        {
            _lineTool = lineTool;
        }

        public PixelCollection Draw(PixelCollection pixels, IList<Point> drawingPoints,
            DrawingItemProperties properties)
        {
            for (int i = 0; i < drawingPoints.Count - 1; i++)
            {
                pixels = _lineTool.BresenhamLine(pixels, drawingPoints[i], drawingPoints[i + 1], properties.Color);
            }
            return pixels;
        }
    }
}
