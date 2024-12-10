
namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    
    public Dictionary<Point, List<IMappable>>? dictionary;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");
        
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");
        dictionary = new Dictionary<Point, List<IMappable>?>();
        //struktura mapy zapamiętująca pozycje stworów 
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


        //add the mappable creature to the correct position

        if (!dictionary.ContainsKey(position))
        {
            dictionary[position] = new List<IMappable>();
        }
        dictionary[position].Add(mappable);
        


    }

    public override void Remove(IMappable mappable, Point position)
    {
        
        dictionary.Remove(position);
    }

    public override List<IMappable>? At(Point p)
    {
        if (!Exist(p))
            throw new ArgumentException("Point is outside the map.");

        return dictionary[p];
    }

    public override List<IMappable>? At(int x, int y)
    {
        return At(new Point(x, y));
    }
    
}
