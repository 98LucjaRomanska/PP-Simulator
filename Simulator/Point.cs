using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public readonly struct Point
    {
        public readonly int X, Y;
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"({X},{Y})";


        public Point Next(Direction direction)
        {
            Point z; 
            switch (direction)
            {
                case Direction.Up:
                    z = new Point(X, Y + 1);
                    break; 
                case Direction.Down:
                    z = new Point(X, Y - 1);
                    break;
                case Direction.Left:
                    z = new Point(X - 1, Y);
                    break;
                case Direction.Right:
                    z = new Point(X + 1, Y);
                    break;
                default: 
                    z = new Point(X, Y);
                    break;
            } 
            return z;
        }
        public Point NextDiagonal(Direction direction)
        {
            Point a;
            switch (direction)
            {
                case Direction.Up:
                    a = new Point(X + 1, Y + 1);
                    break;
                case Direction.Down:
                    a = new Point(X - 1, Y - 1);
                    break;
                case Direction.Left:
                    a = new Point(X - 1, Y + 1);
                    break;
                case Direction.Right:
                    a = new Point(X + 1, Y - 1);
                    break;
                default:
                    a = new Point(X, Y);
                    break;

            } return a;
        }



        public Point DivideBy(int divisor)
        {
            return new Point(X / divisor, Y / divisor);
        }

    }
    
}
