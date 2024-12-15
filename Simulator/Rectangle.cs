using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Rectangle
    {
        Point a, b;
        public readonly int X1, Y1, X2, Y2;
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            if (x1 < x2 && y1 < y2) // x1 = 3 , x2 = 5
            {
                X1 = x1;
                Y1 = y1;
                X2 = x2;
                Y2 = y2;
            }
            else if (x2 < x1 || y1 < y2) // x1 = 7 x2 = 5
            {
                X1 = x2;
                Y1 = y2;
                X2 = x1;
                Y2 = y1;
            }


            if (x1 != x2 && y1 != y2)
            {
                Point a = new Point(x1, y1);
                Point b = new Point(x2, y2);
            }

            else if (x1 == x2 || y1 == y2)
            {
                throw new ArgumentException("Nie chcemy \"chudych\" prostokątów");
            }
        }
        public override string ToString() => $"({X1},{Y1}):({X2},{Y2})";
        public Rectangle(Point p1, Point p2) 
            : this(p1.X,p1.Y,p2.X,p2.Y)
        {
            Point a0 = new Point(p1.X, p1.Y);
            Point b0 = new Point(p2.X, p2.Y);
        }

        public bool Contains(Point point) // sprawdza czy prostokąt zawiera podany punkt
        {
            if (point.X >= 0 && point.X <= X2 && point.Y >= 0 && point.Y <= Y2)
            { return true; }
            else { return false; }
        }


    }
}
