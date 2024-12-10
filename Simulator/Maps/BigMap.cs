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

        //inicjalizacja słownika
        dictionary = new Dictionary<Point, List<IMappable>?>();
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                dictionary.Add(new Point(i, j), new List<IMappable>());
            }
            //tablica wymiarów mapy na dictionary
        }
    }
    public override void Add(IMappable mappable, Point position)
    {
        //PointIsOutside_exception(position);
        if (position.X < 0 || position.X >= SizeX)
        {
            int count0 = 0 - position.X;
            int count1 = position.X - SizeX;
            if (count0 > count1)
            {
                position = new Point(0, position.Y);
            }
            //throw new ArgumentOutOfRangeException("Position goes out of bounds");
            else if (count1 > count0)
            {
                position = new Point(SizeX - 1, position.Y);
            }
            if (!dictionary.ContainsKey(position))
            {
                dictionary[position] = new List<IMappable>();
            }
            dictionary[position].Add(mappable);
        }
        else if (position.Y < 0 || position.Y >= SizeY)
        {
            int count0 = 0 - position.Y;
            int count1 = position.Y - SizeY;
            if (count0 > count1)
            {
                position = new Point(position.X, 0);
            }
            //throw new ArgumentOutOfRangeException("Position goes out of bounds");
            else if (count1 > count0)
            {
                position = new Point(position.X,SizeY - 1);
            }
            dictionary[position].Add(mappable);
        }
        else
        {
            if (!dictionary.ContainsKey(position))
            {
                dictionary[position] = new List<IMappable>();
            }
            dictionary[position].Add(mappable);
        }
            

       
    }

    public override void Remove(IMappable mappable, Point position)
    {
        //PointIsOutside_exception(position);
        dictionary.Remove(position);
    }

    public override List<IMappable>? At(Point p) 
        //wskazuje jakie stwory są na punkcie p
    {
        //PointIsOutside_exception(p);
        return dictionary[p];
        
    }

    public override List<IMappable>? At(int x, int y)
    {
        //PointIsOutside_exception(new Point(x,y));
        if (dictionary.TryGetValue(new Point(x, y), out var mappableList))
        {
            return mappableList;      
        }
        return null;
    }

    public void PointIsOutside_exception(Point p)
    {
        if (!Exist(p))
            throw new ArgumentException("Point is not a part of the map.");
    }

    public void IfDictionaryIsNull(Point p)
    {
        if (dictionary[p] == null)
        {
            dictionary[p] = new List<IMappable>();
        }
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
