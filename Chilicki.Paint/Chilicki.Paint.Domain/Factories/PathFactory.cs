using Chilicki.Paint.Domain.Enums;
using System;
using System.Windows.Media;

namespace Chilicki.Paint.Domain.Factories
{
    public class PathColorFactory
    {
        private readonly string ArgumentError = "No such path";

        public Brush Create(PathType path, Brush currentBrush)
        {
            switch (path)
            {
                case PathType.Pencil:
                    return currentBrush;
                case PathType.Rubber:
                    return new SolidColorBrush(Colors.White);
                default:
                    throw new ArgumentException(ArgumentError);
            }
        }
    }
}
