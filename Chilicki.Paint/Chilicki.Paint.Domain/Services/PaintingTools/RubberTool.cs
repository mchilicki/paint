using System.Collections.Generic;
using Chilicki.Paint.Domain.Aggregates;
using Chilicki.Paint.Domain.ValueObjects;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class RubberTool : IPainterTool
    {
        private PencilTool _pencilTool;

        public RubberTool(PencilTool pencilTool)
        {
            _pencilTool = pencilTool;
        }

        public PixelCollection Draw(PixelCollection pixels, IList<Point> drawingPoints, 
            DrawingItemProperties properties)
        {
            return _pencilTool.Draw(pixels, drawingPoints, new DrawingItemProperties(Colors.White));
        }
    }
}
