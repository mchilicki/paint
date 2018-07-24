using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Services.PaintingTools;

namespace Chilicki.Paint.Domain.Services.Factories
{
    public interface IToolFactory
    {
        IPainterTool Create(ToolType toolType);
    }
}
