namespace Chilicki.Paint.Domain.ValueObjects
{
    public abstract class DrawingItem
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
    }
}
