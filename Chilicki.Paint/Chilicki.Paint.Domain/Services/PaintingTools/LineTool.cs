using System.Collections.Generic;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using Chilicki.Paint.Domain.ValueObjects;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class LineTool : IPainterTool
    {
        public List<DrawingItem> Draw(List<DrawingItem> drawingList, Point drawingStartPoint, Point drawingEndPoint)
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
