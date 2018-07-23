using Chilicki.Paint.UserInterface.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;

namespace Chilicki.Paint.UserInterface
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                var app = new ApplicationView();
                var context = new PaintViewModel();
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
