using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using System.Windows.Media;
using Chilicki.Paint.Domain.Factories;
using Chilicki.Paint.Domain.Enums;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class PathTool : IPainterTool
    {
        PathColorFactory _pathFactory;
        PathType _path;

        public PathTool(PathColorFactory pathFactory, PathType path)
        {
            _pathFactory = pathFactory;
            _path = path;
        }
        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints,
            DrawingItemProperties properties)
        {
            Brush brush = _pathFactory.Create(_path, properties.Brush);
            PointCollection points = new PointCollection();
            foreach (var point in drawingPoints)
            {
                points.Add(new System.Windows.Point(point.X, point.Y));                
            }
            drawingList.Add(new PathItem(properties.Thickness, brush, points));
            return drawingList;
        }
    }
}
