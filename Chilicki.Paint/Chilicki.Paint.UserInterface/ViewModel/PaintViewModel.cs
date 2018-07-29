using Chilicki.Paint.Application.Managers;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.UserInterface.ViewModel.Base;
using Chilicki.Paint.UserInterface.ViewModel.Commands;
using System.Windows.Input;
using Chilicki.Paint.Domain.Enums;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;

namespace Chilicki.Paint.UserInterface.ViewModel
{
    class PaintViewModel : BaseViewModel
    {
        private PaintManager _paintManager;
        private ToolType _currentToolType;
        private IList<Point> _drawingPoints;

        private static readonly string DefaultEmptyFileUri = 
            @"pack://application:,,,/Chilicki.Paint.UserInterface;component/Pictures/emptyFile.bmp";
        private static readonly int DefaultBitmapWidth = 400;
        private static readonly int DefaultBitmapHeight = 400;

        private bool _isUserDrawing = false;

        public PaintViewModel(PaintManager paintManager)
        {
            _paintManager = paintManager;
            _currentToolType = ToolType.Pencil;
        }

        private BitmapSource _currentBitmap 
            = new WriteableBitmap(new BitmapImage(new Uri(DefaultEmptyFileUri, UriKind.Absolute)));
        public BitmapSource CurrentBitmap
        {
            get { return _currentBitmap; }
            set
            {
                _currentBitmap = value;
                NotifyPropertyChanged(nameof(CurrentBitmap));
            }
        }
        
        private int _currentBitmapWidth = DefaultBitmapWidth;
        public int CurrentBitmapWidth
        {
            get { return _currentBitmapWidth; }
            set
            {
                _currentBitmapWidth = value;
                NotifyPropertyChanged(nameof(CurrentBitmapWidth));
            }
        }
        
        private int _currentBitmapHeight = DefaultBitmapHeight;
        public int CurrentBitmapHeight
        {
            get { return _currentBitmapHeight; }
            set
            {
                _currentBitmapHeight = value;
                NotifyPropertyChanged(nameof(CurrentBitmapHeight));
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
                            DrawingItemProperties properties = new DrawingItemProperties(CurrentColour);
                            _drawingPoints.Add(new Point(CurrentMousePositionX, CurrentMousePositionY));
                            CurrentBitmap = _paintManager.Draw(CurrentBitmap, _currentToolType,
                                _drawingPoints, properties);
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
