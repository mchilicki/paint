using Chilicki.Paint.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Aggregates
{
    public class PixelCollection : IEnumerable<Pixel>
    {
        private IList<Pixel> _pixels;

        public Pixel this[int key]
        {
            get { return _pixels[key]; }
            set { _pixels[key] = value; }
        }

        public IEnumerator<Pixel> GetEnumerator()
        {
            return _pixels.GetEnumerator(); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _pixels.GetEnumerator(); 
        }

        public PixelCollection()
        {
            _pixels = new List<Pixel>();
            Width = 0;
            Height = 0;
            DpiX = 0;
            DpiY = 0;
        }

        public PixelCollection(IList<Pixel> pixels, int width, int height, int dpiX, int dpiY)
        {
            _pixels = pixels;
            Width = width;
            Height = height;
            DpiX = dpiX;
            DpiY = dpiY;
        }

        public int Width { get; internal set; }

        public int Height { get; internal set; }

        public int DpiX { get; internal set; }

        public int DpiY { get; internal set; }

        public int Count { get { return _pixels.Count; } }

        private readonly string WrongColumnOrRow = "PixelCollection: Column or row too large";
        public Pixel GetPixel(int column, int row)
        {
            if (column >= Width || row >= Height || column < 0 || row < 0)
                throw new ArgumentException(WrongColumnOrRow);
            return _pixels[Width * row + column];
        }

        public Pixel GetPixel(double column, double row)
        {
            return GetPixel((int)column, (int)row);
        }

        public Pixel GetPixel(Point point)
        {
            return GetPixel((int)point.X, (int)point.Y);
        }

        public Pixel GetPixelOrNull(double column, double row)
        {
            if (column >= Width || row >= Height || column < 0 || row < 0)
                return null;
            return _pixels[Width * (int) row + (int)column];
        }

        public void SetPixel(int column, int row, Color colour)
        {
            var pixel = GetPixel(column, row);
            if (pixel != null)
            {
                pixel.Alpha = colour.A;
                pixel.Blue = colour.B;
                pixel.Green = colour.G;
                pixel.Red = colour.R;
            }            
        }

        public void SetPixel(Point point, Color colour)
        {
            if (point != null)
                SetPixel((int)point.X, (int)point.Y, colour);
        }

        public void SetPixel(Pixel pixel, Color colour)
        {
            if (pixel != null)
                SetPixel(pixel.Column, pixel.Row, colour);
        }
    }
}
