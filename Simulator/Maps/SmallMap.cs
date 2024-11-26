
namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields; //[,] 2D array
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");
        }
        //struktura mapy zapamiętująca pozycje stworów 
        _fields = new List<Creature>?[SizeX, SizeY]; //tablica potworów

    }

    public List<Creature> creatures = new();
    public List<Point> points_whereStands = new();
    public override void Add(Creature creature, Point position)
    {

        if (!Exist(position))
            throw new ArgumentException("Point is outside the map.");

        creatures.Add(creature);
        _fields[position.X, position.Y] ??= new List<Creature>();
        _fields[position.X, position.Y]?.Add(creature);


    }

    public override void Remove(Creature creature, Point position)
    {
        _fields[position.X, position.Y] ??= new List<Creature>();

        _fields[position.X, position.Y]?.Add(creature);
    }

    public override List<Creature>? At(Point p)
    {
        if (!Exist(p))
            throw new ArgumentException("Point is outside the map.");
        return _fields[p.X, p.Y];
    }

    public override List<Creature>? At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public override void Move(Creature creature, Point pFirst, Point pDesired)
    {
        /*
        if (!Exist(pFirst) || !Exist(pDesired)) 
            throw new ArgumentException("One of the points does not belong to the map!");
        Remove(creature, pFirst);
        */

        _fields[pFirst.X, pDesired.Y]?.Remove(creature);
        _fields[pFirst.X, pDesired.Y]?.Add(creature);
    }
}
