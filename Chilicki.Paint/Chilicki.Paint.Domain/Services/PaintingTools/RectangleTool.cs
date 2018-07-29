using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.Aggregates;
using Chilicki.Paint.Common.Extensions.Lists;
using Chilicki.Paint.Common.Swappers;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    class RectangleTool : IPainterTool
    {
        public PixelCollection Draw(PixelCollection pixels, IList<Point> drawingPoints, 
            DrawingItemProperties properties)
        {
            return Rectangle(pixels, drawingPoints.First(), drawingPoints.Last(), properties.Color);
        }

        public PixelCollection Rectangle(PixelCollection pixels, Point startPoint, Point endPoint,
            Color colour)
        {
            if (startPoint.X > endPoint.X)
                Swapper.Swap(ref startPoint, ref endPoint);
            for (int i = (int)startPoint.X; i < endPoint.X; i++)
            {
                pixels.SetPixel(i, (int)startPoint.Y, colour);
                pixels.SetPixel(i, (int)endPoint.Y, colour);
            }
            if (startPoint.Y > endPoint.Y)
                Swapper.Swap(ref startPoint, ref endPoint);
            for (int i = (int)startPoint.Y; i < endPoint.Y; i++)
            {
                pixels.SetPixel((int)startPoint.X, i, colour);
                pixels.SetPixel((int)endPoint.X, i, colour);
            }
            return pixels;
        }
    }
}