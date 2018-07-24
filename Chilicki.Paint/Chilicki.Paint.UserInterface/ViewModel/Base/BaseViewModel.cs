using System.ComponentModel;

namespace Chilicki.Paint.UserInterface.ViewModel.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
