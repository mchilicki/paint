using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Services.PaintingTools;

namespace Chilicki.Paint.Domain.Services.Factories
{
    public class ToolFactory
    {
        public PainterTool Create(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Circle:
                    return new CircleTool();
                case ToolType.Line:
                    return new LineTool();
                case ToolType.Pencil:
                    return new PencilTool();
                case ToolType.Rectangle:
                    return new RectangleTool();
                case ToolType.Rubber:
                    return new RubberTool();
                default:
                    return new EmptyTool();
            }
        }
    }
}
