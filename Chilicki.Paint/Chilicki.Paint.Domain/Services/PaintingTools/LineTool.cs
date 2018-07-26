using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Common.Extensions.Lists;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class LineTool : IPainterTool
    {
        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, IList<Point> drawingPoints)
        {
            return Draw(drawingList, drawingPoints.First(), drawingPoints.Last());
        }

        private IList<DrawingItem> Draw(IList<DrawingItem> drawingList, Point drawingStartPoint, Point drawingEndPoint)
        {
            drawingList.Add(new LineItem()
            {
                StartPointX = drawingStartPoint.X,
                StartPointY = drawingStartPoint.Y,
                EndPointX = drawingEndPoint.X,
                EndPointY = drawingEndPoint.Y
            });
            return drawingList;
        }
    }
}
