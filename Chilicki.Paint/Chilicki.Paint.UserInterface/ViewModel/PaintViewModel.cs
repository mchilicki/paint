using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.UserInterface.ViewModel.Base;
using System.Collections.ObjectModel;

using System.Windows.Input;

namespace Chilicki.Paint.UserInterface.ViewModel
{
    class PaintViewModel : BaseViewModel
    {
        private Point _drawingStartPoint;
        private Point _drawingEndPoint;

        private ObservableCollection<DrawingItem> _drawingItems;
        public ObservableCollection<DrawingItem> DrawingItems
        {
            get { return _drawingItems; }
            set
            {
                _drawingItems = value;
                NotifyPropertyChanged(nameof(DrawingItem));
            }
        }

        private double _currentMousePositionX;
        public double CurrentMousePositionX
        {
            get { return _currentMousePositionX; }
            set
            {
                if (value.Equals(_currentMousePositionX))
                    return;
                _currentMousePositionX = value;
                NotifyPropertyChanged(nameof(CurrentMousePositionX));
            }
        }

        private double _currentMousePositionY;
        public double CurrentMousePositionY
        {
            get { return _currentMousePositionY; }
            set
            {
                if (value.Equals(_currentMousePositionY))
                    return;
                _currentMousePositionY = value;
                NotifyPropertyChanged(nameof(CurrentMousePositionY));
            }
        }        

        private ActionCommand<MouseButtonEventArgs> _startDrawing;
        public ActionCommand<MouseButtonEventArgs> StartDrawing
        {
            get
            {
                if (_startDrawing == null)
                {
                    _startDrawing = new ActionCommand<MouseButtonEventArgs>((mouseArguments) =>
                    {
                        _drawingStartPoint = new Point(CurrentMousePositionX, CurrentMousePositionY);
                    });
                }
                return _startDrawing;
            }
        }

        private ActionCommand<MouseButtonEventArgs> _endDrawing;
        public ActionCommand<MouseButtonEventArgs> EndDrawing
        {
            get
            {
                if (_endDrawing == null)
                {
                    _endDrawing = new ActionCommand<MouseButtonEventArgs>((mouseArguments) =>
                    {
                        _drawingEndPoint = new Point(CurrentMousePositionX, CurrentMousePositionY);
                    });
                }
                return _endDrawing;
            }
        }
    }
}
