using Chilicki.Paint.Application.Managers;
using Chilicki.Paint.Domain.Services.Factories;
using Chilicki.Paint.Domain.Services.PaintingTools;
using Chilicki.Paint.UserInterface.ViewModel;
using Ninject.Modules;

namespace Chilicki.Paint.UserInterface.Config
{
    class DependencyInjectionBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<PaintViewModel>().ToSelf();

            Bind<PaintManager>().ToSelf();

            Bind<FileManager>().ToSelf();            

            Bind<IPainterTool>().To<CircleTool>().Named(nameof(CircleTool));
            Bind<IPainterTool>().To<EmptyTool>().Named(nameof(EmptyTool));
            Bind<IPainterTool>().To<LineTool>().Named(nameof(LineTool));
            Bind<IPainterTool>().To<PencilTool>().Named(nameof(PencilTool));
            Bind<IPainterTool>().To<RectangleTool>().Named(nameof(RectangleTool));
            Bind<IPainterTool>().To<RubberTool>().Named(nameof(RubberTool));

            Bind<IToolFactory>().To<ToolFactory>();

            // TODO Bind all image loaders and savers in infrastructure
        }
    }
}
