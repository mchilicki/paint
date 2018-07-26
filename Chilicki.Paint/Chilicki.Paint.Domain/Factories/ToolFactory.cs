using Chilicki.Paint.Domain.Enums;
using Chilicki.Paint.Domain.Services.PaintingTools;

namespace Chilicki.Paint.Domain.Factories
{
    public class ToolFactory : IToolFactory
    {
        FigureFactory _figureFactory;
        PathColorFactory _pathColorFactory;

        public ToolFactory(FigureFactory figureFactory, PathColorFactory pathColorFactory)
        {
            _figureFactory = figureFactory;
            _pathColorFactory = pathColorFactory;
        }

        public IPainterTool Create(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Rectangle:
                    return new FigureTool(_figureFactory, FigureType.Rectangle);
                case ToolType.Circle:
                    return new FigureTool(_figureFactory, FigureType.Circle);
                case ToolType.Line:
                    return new LineTool();             
                case ToolType.Pencil:
                    return new PathTool(_pathColorFactory, PathType.Pencil);
                case ToolType.Rubber:
                    return new PathTool(_pathColorFactory, PathType.Rubber);
                default:
                    return new EmptyTool();
            }
        }
    }
}
