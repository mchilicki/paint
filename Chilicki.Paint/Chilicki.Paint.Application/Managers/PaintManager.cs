using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Services.Factories;
using Chilicki.Paint.Domain.Services.PaintingTools;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using System.Collections.Generic;

namespace Chilicki.Paint.Application.Managers
{
    public class PaintManager
    {
        private ToolFactory _toolFactory;

        public PaintManager(ToolFactory toolFactory)
        {
            _toolFactory = toolFactory;
        }

        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, ToolType toolType, 
            IList<Point> drawingPoints)
        {
            IPainterTool painterTool = _toolFactory.Create(toolType);
            return painterTool.Draw(drawingList, drawingPoints);        
        }
    }
}
