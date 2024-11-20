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

        
        public override string ToString()
        {
            return $"(0, 0)-({Size} - 1, {Size} -1)";
        }



        private Point wrappedp;

        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }


        public Point ComWrappers(Point p)
        {
            
            int wrapX = (p.X + Size) % Size;
            int wrapY = (p.Y + Size) % Size;
            Point wrappedp = new Point(wrapX, wrapY);
            return wrappedp;
            
        }
        public override Point Next(Point p, Direction d)
        {
            var newPoint = p.Next(d);
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
