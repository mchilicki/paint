using Chilicki.Paint.Domain.Aggregates;
using Chilicki.Paint.Domain.ValueObjects;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chilicki.Paint.Application.Converters
{
    public class BitmapConverter
    {
        private readonly static int PixelValues = 4;

        public static BitmapSource ToBitmap(PixelCollection pixels)
        {
            var newBitmap = new WriteableBitmap(
                    pixels.Width, pixels.Height, pixels.DpiX, pixels.DpiY, PixelFormats.Bgra32, null);
            byte[] pixelsArray = new byte[pixels.Height * pixels.Width * PixelValues];
            int index = 0;
            foreach (var pixel in pixels)
            {
                pixelsArray[index] = (byte)pixel.Blue;
                pixelsArray[index + 1] = (byte)pixel.Green;
                pixelsArray[index + 2] = (byte)pixel.Red;
                pixelsArray[index + 3] = (byte)pixel.Alpha;
                index += PixelValues;
            }
            Int32Rect rect = new Int32Rect(0, 0, pixels.Width, pixels.Height);
            int stride = PixelValues * pixels.Width;
            newBitmap.WritePixels(rect, pixelsArray, stride, 0);
            return newBitmap;
        }

        public static PixelCollection ToPixelCollection(BitmapSource bitmapSource)
        {
            int stride = bitmapSource.PixelWidth * ((bitmapSource.Format.BitsPerPixel + 7) / 8);
            byte[] byteArray = new byte[bitmapSource.PixelHeight * stride];
            bitmapSource.CopyPixels(byteArray, stride, 0);
            IList<Pixel> pixelList = new List<Pixel>();
            for (int i = 0; i < byteArray.Length; i += PixelValues)
            {
                pixelList.Add(new Pixel()
                {
                    Blue = byteArray[i],
                    Green = byteArray[i + 1],
                    Red = byteArray[i + 2],
                    Alpha = byteArray[i + 3],
                    IndexGlobal = i,
                    IndexColumn = i % bitmapSource.PixelWidth,
                    IndexRow = i % bitmapSource.PixelHeight,
                });
            }
            return new PixelCollection(pixelList, bitmapSource.PixelWidth, bitmapSource.PixelHeight,
                (int)bitmapSource.DpiX, (int)bitmapSource.DpiY);
        }
    }
}