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
            var fillPixel = pixels.GetPixel(drawingPoints.First());
            FloodFill(pixels, fillPixel, fillPixel.Color, properties.Color);
            return pixels;
        }

        public PixelCollection FloodFill(PixelCollection pixels, Pixel fillPixel, Color targetColor, Color replacementColor)
        {
            if (targetColor.Equals(replacementColor))
                return pixels;
            if (!fillPixel.Color.Equals(targetColor))
                return pixels;
            var pixelQueue = new Queue<Pixel>();
            pixels.SetPixel(fillPixel, replacementColor);
            pixelQueue.Enqueue(fillPixel);
            Pixel currentPixel;
            while (pixelQueue.Count > 0)
            {
                currentPixel = pixelQueue.Dequeue();
                var northPixel = pixels.GetPixelOrNull(currentPixel.Column, currentPixel.Row - 1);
                var southPixel = pixels.GetPixelOrNull(currentPixel.Column, currentPixel.Row + 1);
                var eastPixel = pixels.GetPixelOrNull(currentPixel.Column + 1, currentPixel.Row);
                var westPixel = pixels.GetPixelOrNull(currentPixel.Column - 1, currentPixel.Row);
                TryToColorPixel(pixels, pixelQueue, northPixel, targetColor, replacementColor);
                TryToColorPixel(pixels, pixelQueue, southPixel, targetColor, replacementColor);
                TryToColorPixel(pixels, pixelQueue, eastPixel, targetColor, replacementColor);
                TryToColorPixel(pixels, pixelQueue, westPixel, targetColor, replacementColor);
            }
            return pixels;
        }

        private void TryToColorPixel(PixelCollection pixels, Queue<Pixel> pixelQueue, Pixel currentPixel,
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
