﻿namespace Chilicki.Paint.Domain.ValueObjects
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
