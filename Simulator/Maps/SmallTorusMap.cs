using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public int Size { get; }
        private Rectangle rex;
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
        /*
        public override string ToString()
        {
            return $"(0, 0)-({Size} - 1, {Size} -1)";
        }
        */

        public Point ComWrappers(Point p)
        {
            
            int wrapX = (p.X + SizeX) % SizeX; 
            int wrapY = (p.Y + SizeY) % SizeY;
            Point wrappedp = new Point(wrapX, wrapY);
            return wrappedp;
            
        }
        public override Point Next(Point p, Direction d)
        {
            // p = (0,0) d = Direction.Down
            var newPoint = p.Next(d);  //(0,-1)
            newPoint = ComWrappers(newPoint);
            return newPoint;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var newPoint = p.NextDiagonal(d);
            newPoint = ComWrappers(newPoint);
            return newPoint; 
        }

    }
}
