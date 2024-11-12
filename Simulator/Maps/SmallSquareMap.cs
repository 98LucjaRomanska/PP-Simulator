
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {

        public int Size { get; } 


        Point p;
        private Rectangle rex; 
        public SmallSquareMap(int size)
        {
          

            if (size >=5 && size <= 20)
            {
                Size = size;
                Console.WriteLine($"(0, 0) - ({Size - 1}, {Size - 1})");
            }
            else if (20 < size || 5 > size)
            {
                throw new ArgumentOutOfRangeException();
            }
            rex = new(0, 0, Size - 1, Size - 1);
            
            

        }
        public override bool Exist(Point p) => rex.Contains(p);
        
        
        public override Point Next(Point p, Direction d)
        {
            int s = p.Y;
            int t = p.X;
            if (p.X > Size || p.Y > Size)
                throw new NotImplementedException("Punkt nie może wyjść poza granice mapy.");
            else
                switch (d)
                {
                    case Direction.Up:
                        s = p.Y + 1;
                        p = new Point(p.X, s); //creating new point
                        break; 
                    case Direction.Down:
                        s = p.Y - 1;
                        p = new Point(p.X, s);
                        break;
                    case Direction.Left:
                        t = p.X - 1;
                        p = new Point(t, p.Y);
                        break;
                    case Direction.Right:
                        t = p.X + 1;
                        p = new Point(t, p.Y);
                        break; 
                    default:
                        t = p.X;
                        s = p.Y;
                        p = new Point(p.X, p.Y);
                        break; 
                }

            Point newPoint = new Point(t, s);
            return newPoint; 
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var p_after = p.NextDiagonal(d);
            if (!Exist(p_after)) { return p;}
            return p_after;         

        }
        
    }
}
