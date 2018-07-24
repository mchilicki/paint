using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilicki.Paint.Domain.ValueObjects
{
    public class Point
    {
        public double X;
        public double Y;

        public Point() { }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
