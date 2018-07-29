using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Services.PaintingTools;

namespace Chilicki.Paint.Domain.Factories
{
    public class ToolFactory
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
                case ToolType.Pencil:
                    return new PencilTool(new LineTool());
                case ToolType.Rubber:
                    return new RubberTool(new PencilTool(new LineTool()));
                case ToolType.Fill:
                    return new FillTool();
                default:
                    return new EmptyTool();
            }
        }
    }
}
