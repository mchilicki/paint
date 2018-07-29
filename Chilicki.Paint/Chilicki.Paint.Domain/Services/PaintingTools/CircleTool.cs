using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.Aggregates;
using Chilicki.Paint.Domain.Services.PointAlgorithms;
using Chilicki.Paint.Common.Extensions.Lists;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    class CircleTool : IPainterTool
    {
        public PixelCollection Draw(PixelCollection pixels, IList<Point> drawingPoints,
            DrawingItemProperties properties)
        {
            Point center = PointCalculator.GetCenter(drawingPoints.First(), drawingPoints.Last());
            Point topCenter = new Point(center.X, drawingPoints.First().Y);
            Point bottomCenter = new Point(center.X, drawingPoints.Last().Y);
            double radius = PointCalculator.GetLenght(topCenter, bottomCenter) / 2;
            return BresenhamCircle(pixels, center, radius, properties.Color);
        }

        public PixelCollection BresenhamCircle(PixelCollection pixels, Point center,
            double radius, Color colour)
        {
            double x = radius;
            double y = 0;
            double decition = 0;

            while (x >= y)
            {
                if (decition <= 0)
                {
                    y++;
                    decition += 2 * y + 1;
                }

                if (decition > 0)
                {
                    x--;
                    decition -= 2 * x + 1;
                }
                pixels.SetPixel((int)(center.X + x), (int)(center.Y + y), colour);
                pixels.SetPixel((int)(center.X + y), (int)(center.Y + x), colour);
                pixels.SetPixel((int)(center.X - y), (int)(center.Y + x), colour);
                pixels.SetPixel((int)(center.X - x), (int)(center.Y + y), colour);
                pixels.SetPixel((int)(center.X - x), (int)(center.Y - y), colour);
                pixels.SetPixel((int)(center.X - y), (int)(center.Y - x), colour);
                pixels.SetPixel((int)(center.X + y), (int)(center.Y - x), colour);
                pixels.SetPixel((int)(center.X + x), (int)(center.Y - y), colour);
            }
            return pixels;
        }
    }
}
