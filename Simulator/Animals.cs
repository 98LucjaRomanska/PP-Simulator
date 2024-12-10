using Simulator.Maps;
using System.ComponentModel;

namespace Simulator;

public class Animals : IMappable
{



    private Map map;
    private Point position;
    private string description;
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public int Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public virtual char Symbol => 'A';

    public Animals(string description, int size = 1)
    {
        Size = size;
        Description = description;
        
    }

    public string Description
    { 
        get {return description; }
        init 
        {
            description = (value ?? "Unknown").Trim();
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
   

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (!map.Exist(position)) throw new ArgumentException($"This point does not belong to the map");

        Map = map;
        Position = position;
        map.Add(this, position);
    }
    public virtual void Go(Direction direction)
    {
        if (Map == null) throw new ArgumentNullException(nameof(map));
        //next position after moving in a given direction
        Point nextPosition = Map.Next(Position, direction);
        Map.Move(this, Position, nextPosition);
        Position = nextPosition;
    }
    void IMappable.Go(Direction direction) //obiekt mapowalny porusza się po mapie
    {
        this.Go(direction);
    }
    object IMappable.Name
    {
        get => Description;
        set => throw new NotImplementedException();
    }

}
    
