using Chilicki.Paint.Application.Managers;
using Chilicki.Paint.Domain.Services.Factories;
using Chilicki.Paint.UserInterface.ViewModel;
using Ninject;
using Ninject.Parameters;
using System;
using System.Diagnostics;
using System.Windows;

namespace Chilicki.Paint.UserInterface
{
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                IKernel _kernel = new StandardKernel();
                _kernel.Load(AppDomain.CurrentDomain.GetAssemblies());
                var app = new ApplicationView();
                var context = _kernel.Get<PaintViewModel>();
                app.Show();
                app.DataContext = context;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
