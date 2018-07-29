using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Common.Extensions.Lists;
using Chilicki.Paint.Domain.Aggregates;
using System;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class LineTool : IPainterTool
    {
        public PixelCollection Draw(PixelCollection pixels, IList<Point> drawingPoints,
            DrawingItemProperties properties)
        {
            return BresenhamLine(pixels, drawingPoints.First(), drawingPoints.Last(), properties.Color);
        }

        public PixelCollection BresenhamLine(PixelCollection pixels, Point drawingStartPoint, 
            Point drawingEndPoint, Color colour)
        {
            int lineWidth = (int)drawingEndPoint.X - (int)drawingStartPoint.X;
            int lineHeight = (int)drawingEndPoint.Y - (int)drawingStartPoint.Y;
            int widthDifference1 = 0, heightDifference1 = 0, widthDifference2 = 0, heightDifference2 = 0;
            if (lineWidth < 0) widthDifference1 = -1; else if (lineWidth > 0) widthDifference1 = 1;
            if (lineHeight < 0) heightDifference1 = -1; else if (lineHeight > 0) heightDifference1 = 1;
            if (lineWidth < 0) widthDifference2 = -1; else if (lineWidth > 0) widthDifference2 = 1;
            int longest = Math.Abs(lineWidth);
            int shortest = Math.Abs(lineHeight);
            if (!(longest > shortest))
            {
                longest = Math.Abs(lineHeight);
                shortest = Math.Abs(lineWidth);
                if (lineHeight < 0) heightDifference2 = -1; else if (lineHeight > 0) heightDifference2 = 1;
                widthDifference2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                pixels.SetPixel((int)drawingStartPoint.X, (int)drawingStartPoint.Y, colour);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    drawingStartPoint.X += widthDifference1;
                    drawingStartPoint.Y += heightDifference1;
                }
                else
                {
                    drawingStartPoint.X += widthDifference2;
                    drawingStartPoint.Y += heightDifference2;
                }
            }
            return pixels;
        }
    }
}
