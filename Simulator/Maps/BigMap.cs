using FizzWare.NBuilder.Dates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigMap : Map
{
    //List<IMappable>?[,] _fields; //pola na obiekty mapowalne
    private Dictionary<Point, List<IMappable>>? dictionary;
    protected BigMap(int sizeX,int sizeY) : base(sizeX,sizeY)
    {
        if (sizeX > 1000 || sizeY > 1000) throw new ArgumentException("One of sizes is too big to create a BigMap. ");
        //list_forX = new List<IMappable>?[sizeX, sizeY];
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
