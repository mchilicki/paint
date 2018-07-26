using Chilicki.Paint.Application.Managers;
using Chilicki.Paint.Domain.Factories;
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

            Bind<ToolFactory>().ToSelf();

            Bind<FigureFactory>().ToSelf();

            Bind<PathColorFactory>().ToSelf();         

            // TODO Bind all image loaders and savers in infrastructure
        }
    }
}
