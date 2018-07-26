using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Services.PaintingTools;

namespace Chilicki.Paint.Domain.Factories
{
    public class ToolFactory : IToolFactory
    {
        public IPainterTool Create(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Rectangle:
                    return new RectangleTool();
                case ToolType.Circle:
                    return new CircleTool();
                case ToolType.Line:
                    return new LineTool();
                
                case ToolType.Rubber:
                    return new RubberTool();
                case ToolType.Pencil:
                    return new PencilTool();
                default:
                    return new EmptyTool();
            }
        }
    }
}
