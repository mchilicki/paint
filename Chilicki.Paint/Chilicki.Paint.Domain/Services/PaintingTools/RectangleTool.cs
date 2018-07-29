using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.Aggregates;
using Chilicki.Paint.Common.Extensions.Lists;
using Chilicki.Paint.Common.Swappers;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    class RectangleTool : IPainterTool
    {
        public PixelCollection Draw(PixelCollection pixels, IList<Point> drawingPoints, 
            DrawingItemProperties properties)
        {
            return Draw(pixels, drawingPoints.First(), drawingPoints.Last(), properties);
        }

        public PixelCollection Draw(PixelCollection pixels, Point startPoint, Point endPoint,
            DrawingItemProperties properties)
        {
            if (startPoint.X > endPoint.X)
                Swapper.Swap(ref startPoint, ref endPoint);
            for (int i = (int)startPoint.X; i < endPoint.X; i++)
            {
                pixels.SetPixel(i, (int)startPoint.Y, properties.Color);
                pixels.SetPixel(i, (int)endPoint.Y, properties.Color);
            }
            if (startPoint.Y > endPoint.Y)
                Swapper.Swap(ref startPoint, ref endPoint);
            for (int i = (int)startPoint.Y; i < endPoint.Y; i++)
            {
                pixels.SetPixel((int)startPoint.X, i, properties.Color);
                pixels.SetPixel((int)endPoint.X, i, properties.Color);
            }
            return pixels;
        }
    }
}