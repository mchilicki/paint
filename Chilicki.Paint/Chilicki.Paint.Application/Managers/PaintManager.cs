using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Factories;
using Chilicki.Paint.Domain.Services.PaintingTools;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using System.Collections.Generic;

namespace Chilicki.Paint.Application.Managers
{
    public class PaintManager
    {
        private ToolFactory _toolFactory;
        private FileManager _fileManager;

        public PaintManager(ToolFactory toolFactory, FileManager fileManager)
        {
            _toolFactory = toolFactory;
            _fileManager = fileManager;
        }

        public IList<DrawingItem> Draw(IList<DrawingItem> drawingList, ToolType toolType, 
            IList<Point> drawingPoints, DrawingItemProperties properties)
        {
            IPainterTool painterTool = _toolFactory.Create(toolType);
            return painterTool.Draw(drawingList, drawingPoints, properties);        
        }
    }
}
