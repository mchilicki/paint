using System;
using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class CircleTool : IPainterTool
    {
        public List<DrawingItem> Draw(List<DrawingItem> drawingList, Point drawingStartPoint, Point drawingEndPoint)
        {
            double startingLocationX, startingLocationY;
            double circleHeight = Math.Abs(drawingStartPoint.Y - drawingEndPoint.Y);
            double circleWidth = Math.Abs(drawingStartPoint.X - drawingEndPoint.X);
            if (drawingStartPoint.X <= drawingEndPoint.X)
                startingLocationX = drawingStartPoint.X;
            else
                startingLocationX = drawingEndPoint.X;
            if (drawingStartPoint.Y <= drawingEndPoint.Y)
                startingLocationY = drawingStartPoint.Y;
            else
                startingLocationY = drawingEndPoint.Y;
            drawingList.Add(new CircleItem()
            {
                Height = circleHeight,
                Width = circleWidth,
                Margin = new System.Windows.Thickness(startingLocationX, startingLocationY, 0, 0),
            });
            return drawingList;            
        }
    }
}
