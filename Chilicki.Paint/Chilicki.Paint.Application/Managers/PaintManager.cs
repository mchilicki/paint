using Chilicki.Paint.Application.Converters;
using Chilicki.Paint.Domain.Aggregates;
using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Factories;
using Chilicki.Paint.Domain.Services.PaintingTools;
using Chilicki.Paint.Domain.ValueObjects;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Chilicki.Paint.Application.Managers
{
    public class PaintManager
    {
        private ToolFactory _toolFactory;
        private FileManager _fileManager;
        private PixelCollection _pixelCollection;

        public PaintManager(ToolFactory toolFactory, FileManager fileManager)
        {
            _toolFactory = toolFactory;
            _fileManager = fileManager;
        }

        public BitmapSource Draw(BitmapSource currentBitmap, ToolType toolType, 
            IList<Point> drawingPoints, DrawingItemProperties properties)
        {
            IPainterTool painterTool = _toolFactory.Create(toolType);
            if (_pixelCollection == null)
                _pixelCollection = BitmapConverter.ToPixelCollection(currentBitmap);
            var newPixels = painterTool.Draw(_pixelCollection, drawingPoints, properties);
            // TODO Add to undo operations here
            _pixelCollection = newPixels;
            return BitmapConverter.ToBitmap(newPixels);        
        }
    }
}
