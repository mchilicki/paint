using System.Windows.Media;

namespace Chilicki.Paint.Domain.ValueObjects
{
    public class Pixel
    {
        public int Blue { get; set; }
        public int Green { get; set; }
        public int Red { get; set; }
        public int Alpha { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
        public int GlobalIndex { get; set; }

        public Color Color
        {
            get
            {
                return Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);
            }
        }

    }
}
