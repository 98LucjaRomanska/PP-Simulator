using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public SmallMap(int sizeX, int sizeY): base(sizeX,sizeY) 
    {
        if (sizeX >20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }
        if (sizeY > 20)
        {

        }

    public override bool Exist(Point p)
    {
        throw new NotImplementedException();
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
}
