using System;

namespace DesignPatternsInCSharp.Factory
{
    public class Point
    {
        private double X, Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho*Math.Sin(theta));
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
        
        public class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho*Math.Sin(theta));
            }
        }
    }
}