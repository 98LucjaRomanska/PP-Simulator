using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }
        private Rectangle rex; 

        public SmallTorusMap(int size) : base()
        {
            Size = size;
            //jeśli wyjdziemy poza Size to wychodzimy po drugiej stronie
            if (size <= 20 && size >= 5)
            {
                rex = new Rectangle(0, 0, Size - 1, Size - 1);
            }
            else
            {
               
                throw new ArgumentOutOfRangeException("size","Size must contain in range 5-20 ");
            }

        }
        public override string ToString()
        {
            return $"(0, 0)-({Size} - 1, {Size} -1)";
        }
        public override bool Exist(Point p)
        {
            return rex.Contains(p);
        }


        private Point wrappedp;
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
