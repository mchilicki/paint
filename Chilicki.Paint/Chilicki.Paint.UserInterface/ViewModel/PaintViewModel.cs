using Chilicki.Paint.Application.Managers;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Domain.ValueObjects.DrawingItems;
using Chilicki.Paint.UserInterface.ViewModel.Base;
using Chilicki.Paint.UserInterface.ViewModel.Commands;
using Chilicki.Paint.Common.Extensions.Lists;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Chilicki.Paint.Domain.Enums;
using System.Collections.Generic;
using System.Windows.Media;

namespace Chilicki.Paint.UserInterface.ViewModel
{
    class PaintViewModel : BaseViewModel
    {
        private PaintManager _paintManager;
        private ToolType _currentToolType;
        private IList<Point> _drawingPoints;

        private bool _isUserDrawing = false;

        public PaintViewModel(PaintManager paintManager)
        {
            _paintManager = paintManager;
            _currentToolType = ToolType.Pencil;
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

        private Color _currentColour = Color.FromArgb(255, 0, 0, 0);
        public Color CurrentColour
        {
            get { return _currentColour; }
            set
            {
                _currentColour = value;
                NotifyPropertyChanged(nameof(CurrentColour));
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
                        _isUserDrawing = true;
                        _drawingPoints = new List<Point>();
                        _drawingPoints.Add(new Point(CurrentMousePositionX, CurrentMousePositionY));
                    });
                }
                return _startDrawing;
            }
        }

        private ActionCommand<MouseButtonEventArgs> _continueDrawing;
        public ActionCommand<MouseButtonEventArgs> ContinueDrawing
        {
            get
            {
                if (_continueDrawing == null)
                {
                    _continueDrawing = new ActionCommand<MouseButtonEventArgs>((mouseArguments) =>
                    {
                        if (_drawingPoints != null && _isUserDrawing)
                            _drawingPoints.Add(new Point(CurrentMousePositionX, CurrentMousePositionY));
                    });
                }
                return _continueDrawing;
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
                        if (_drawingPoints != null && _isUserDrawing)
                        {
                            DrawingItemProperties properties = new DrawingItemProperties(
                                _currentThickness + 1, new SolidColorBrush(CurrentColour));
                            _drawingPoints.Add(new Point(CurrentMousePositionX, CurrentMousePositionY));
                            DrawingItems = _paintManager.Draw(_drawingItems.ToList(), _currentToolType,
                                _drawingPoints, properties).ToObservableCollection();
                            _isUserDrawing = false;
                        }                        
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
                        _currentToolType = (ToolType)toolType;
                    });
                }
                return _changeTool;
            }
        }
    }
}
