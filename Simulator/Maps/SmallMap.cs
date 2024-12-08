
namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<IMappable>?[,] _fields; //[,] 2D array
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");
        
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");
        //struktura mapy zapamiętująca pozycje stworów 

        _fields = new List<IMappable>?[sizeX, sizeY]; 
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                _fields[i, j] = new List<IMappable>();
            }
        }
        

    }

    //public List<Creature> creatures = new();
    //public List<Point> points_whereStands = new();
    public override void Add(IMappable mappable, Point position)
    {

        if (!Exist(position))
            throw new ArgumentException("Point is outside the map.");
        //add the mappable creature to the correct position

        _fields[position.X, position.Y] ??= new List<IMappable>();
        _fields[position.X, position.Y]?.Add(mappable);


    }

    public override void Remove(IMappable mappable, Point position)
    {

        _fields[position.X, position.Y]?.Remove(mappable);
    }

    public override List<IMappable>? At(Point p)
    {
        if (!Exist(p))
            throw new ArgumentException("Point is outside the map.");
        return _fields[p.X, p.Y];
    }

    public override List<IMappable>? At(int x, int y)
    {
        return At(new Point(x, y));
    }
    
}
