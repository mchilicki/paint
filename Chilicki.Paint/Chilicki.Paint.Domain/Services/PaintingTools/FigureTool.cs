using Chilicki.Paint.Common.Extensions.Lists;
using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Factories;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class FigureTool : IPainterTool
    {
        FigureFactory _figureFactory;
        FigureType _figure;

        public FigureTool(FigureFactory figureFactory, FigureType figure)
        {
            _figureFactory = figureFactory;
            _figure = figure;
        }

        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints, 
            DrawingItemProperties properties)
        {
            return Draw(drawingList, drawingPoints.First(), drawingPoints.Last(), properties);
        }

        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, Point drawingStartPoint, 
            Point drawingEndPoint, DrawingItemProperties properties)
        {
            double startingLocationX, startingLocationY;
            double height = Math.Abs(drawingStartPoint.Y - drawingEndPoint.Y);
            double width = Math.Abs(drawingStartPoint.X - drawingEndPoint.X);
            if (drawingStartPoint.X <= drawingEndPoint.X)
                startingLocationX = drawingStartPoint.X;
            else
                startingLocationX = drawingEndPoint.X;
            if (drawingStartPoint.Y <= drawingEndPoint.Y)
                startingLocationY = drawingStartPoint.Y;
            else
                startingLocationY = drawingEndPoint.Y;
            System.Windows.Thickness margin = new System.Windows.Thickness(startingLocationX, startingLocationY, 0, 0);
            drawingList.Add(_figureFactory.Create(_figure, height, width, properties.Thickness, margin, properties.Brush));
            return drawingList;
        }
    }
}
