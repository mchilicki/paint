using Chilicki.Paint.Application.Managers;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.UserInterface.ViewModel.Base;
using Chilicki.Paint.UserInterface.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Chilicki.Paint.UserInterface.ViewModel
{
    class PaintViewModel : BaseViewModel
    {
        private PaintManager _paintManager;

        private Point _drawingStartPoint;
        private Point _drawingEndPoint;

        public PaintViewModel(PaintManager paintManager)
        {
            _paintManager = paintManager;
        }

        private ObservableCollection<DrawingItem> _drawingItems 
            = new ObservableCollection<DrawingItem>();
        public ObservableCollection<DrawingItem> DrawingItems
        {
            get { return _drawingItems; }
            set
            {
                _drawingItems = value;
                NotifyPropertyChanged(nameof(DrawingItems));
            }
        }

        private double _currentMousePositionX;
        public double CurrentMousePositionX
        {
            get { return _currentMousePositionX; }
            set
            {
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
                _currentMousePositionY = value;
                NotifyPropertyChanged(nameof(CurrentMousePositionY));
            }
        }

        private double _currentThickness = 1;
        public double CurrentThickness
        {
            get { return _currentThickness; }
            set
            {
                _currentThickness = value;
                NotifyPropertyChanged(nameof(CurrentThickness));
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
                        System.Windows.MessageBox.Show(_drawingStartPoint.X.ToString() + " " + _drawingStartPoint.Y.ToString() + "SS " + _drawingEndPoint.X.ToString() + " " + _drawingEndPoint.Y.ToString());
                    });
                }
                return _endDrawing;
            }
        }

        private ICommand _undo;
        public ICommand Undo
        {
            get
            {
                if (_undo == null)
                {
                    _undo = new NoParameterCommand(() =>
                    {
                    });
                }
                return _undo;
            }
        }

        private ICommand _changeTool;
        public ICommand ChangeTool
        {
            get
            {
                if (_changeTool == null)
                {
                    _changeTool = new RelayCommand((toolType) =>
                    {
                    });
                }
                return _changeTool;
            }
        }
    }
}
