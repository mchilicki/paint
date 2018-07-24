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

            Bind<PainterTool>().To<CircleTool>().Named(nameof(CircleTool));
            Bind<PainterTool>().To<EmptyTool>().Named(nameof(EmptyTool));
            Bind<PainterTool>().To<LineTool>().Named(nameof(LineTool));
            Bind<PainterTool>().To<PencilTool>().Named(nameof(PencilTool));
            Bind<PainterTool>().To<RectangleTool>().Named(nameof(RectangleTool));
            Bind<PainterTool>().To<RubberTool>().Named(nameof(RubberTool));

            Bind<ToolFactory>().ToSelf();

            // TODO Bind all image loaders and savers in infrastructure
        }
    }
}
