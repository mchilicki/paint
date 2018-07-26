namespace Chilicki.Paint.Domain.ValueObjects.DrawingItems
{
    public class LineItem : DrawingItem
    {
        public double StartPointX { get; set; }
        public double StartPointY { get; set; }
        public double EndPointX { get; set; }
        public double EndPointY { get; set; }
    }
}
