
namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    
    public Dictionary<Point, List<IMappable>>? dictionary;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");
        
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(SizeY), "Too long");
    }


    /*
    public override void Add(IMappable mappable, Point position)
    {


        //add the mappable creature to the correct position

        if (!dictionary.ContainsKey(position))
        {
            dictionary[position] = new List<IMappable>();
        }
        dictionary[position].Add(mappable);
    }*/
    
}
