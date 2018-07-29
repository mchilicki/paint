using System.Collections.Generic;
using Chilicki.Paint.Domain.Aggregates;
using Chilicki.Paint.Domain.ValueObjects;
using Chilicki.Paint.Common.Extensions.Lists;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Services.PaintingTools
{
    public class FillTool : IPainterTool
    {
        public PixelCollection Draw(PixelCollection pixels, IList<Point> drawingPoints, DrawingItemProperties properties)
        {
            return Draw(pixels, drawingPoints.First(), properties);
        }

        public PixelCollection Draw(PixelCollection pixels, Point fillPoint, DrawingItemProperties properties)
        {
            var fillPixel = pixels.GetPixel(fillPoint);
            var targetColor = fillPixel.Color;
            var replacementColor = properties.Color;            
            if (targetColor.Equals(replacementColor))
                return pixels;
            var pixelQueue = new Queue<Pixel>();
            pixels.SetPixel(fillPixel, replacementColor);
            pixelQueue.Enqueue(fillPixel);
            Pixel currentPixel;
            while (pixelQueue.Count > 0)
            {
                currentPixel = pixelQueue.Dequeue();
                var northPixel = pixels.GetPixelOrNull(currentPixel.Row - 1, currentPixel.Column);
                var southPixel = pixels.GetPixelOrNull(currentPixel.Row + 1, currentPixel.Column);
                var eastPixel = pixels.GetPixelOrNull(currentPixel.Row, currentPixel.Column + 1);
                var westPixel = pixels.GetPixelOrNull(currentPixel.Row, currentPixel.Column - 1);
                TryToColorPixel(ref pixels, ref pixelQueue, northPixel, targetColor, replacementColor);
                TryToColorPixel(ref pixels, ref pixelQueue, southPixel, targetColor, replacementColor);
                TryToColorPixel(ref pixels, ref pixelQueue, eastPixel, targetColor, replacementColor);
                TryToColorPixel(ref pixels, ref pixelQueue, westPixel, targetColor, replacementColor);
            }
            return pixels;
        }

        private void TryToColorPixel(ref PixelCollection pixels, ref Queue<Pixel> pixelQueue, Pixel currentPixel,
            Color targetColor, Color replacementColor)
        {
            if (currentPixel != null && targetColor.Equals(currentPixel.Color))
            {
                pixels.SetPixel(currentPixel, replacementColor);
                pixelQueue.Enqueue(currentPixel);
            }
        }
    }
}
