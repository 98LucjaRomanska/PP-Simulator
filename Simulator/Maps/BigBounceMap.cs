using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        //jeśli jest przed ścianą i idzie w strone ściany to ma zmienić kierunek 
        //czyli zamiast (X + 1, Y ) jeśli w prawo
        //(X - 1, Y) jeśli w prawo (czyli porusza się w lewo)
        //prawda kiedy (X+1) == SizeX 
        //PointIsOutside_exception(p);

        var nextPoint = p.Next(d); //nowy punkt po przesunięciu w kierunku d
        if (nextPoint.X == (SizeX))
        {
            if (d == Direction.Right) d = Direction.Left;
            else if (d == Direction.Left) d = Direction.Right;
        }

        if (nextPoint.Y == (SizeY))
        {
            if (d == Direction.Up) d = Direction.Down;
            else if (d == Direction.Down) d = Direction.Up;

        }
        nextPoint = p.Next(d);
        if (nextPoint.X < 0 || nextPoint.X >= SizeX || nextPoint.Y < 0 || nextPoint.Y >= SizeY)
        {
            return p;
        }

        return nextPoint;
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        
        var nextPoint = p.NextDiagonal(d);
        if (nextPoint.X >= SizeX && nextPoint.Y >= SizeY)
        { 
            nextPoint = p;
        }
        if (nextPoint.X >= SizeX || nextPoint.Y >= SizeY)
        {
            //docieram do ściany po prawej
            if (d == Direction.Up) d = Direction.Down;
            //docieram do ściany po lewej
            else if (d == Direction.Down) d = Direction.Up;
            //docieram do ściany na górze
            else if (d == Direction.Left) d = Direction.Right;

            else if (d == Direction.Right) d = Direction.Left;

            nextPoint = p.NextDiagonal(d);

        }
        nextPoint = p.NextDiagonal(d);
        return nextPoint;


    }

}
