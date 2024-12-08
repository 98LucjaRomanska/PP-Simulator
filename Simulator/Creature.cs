using Simulator.Maps;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
//using SimConsole.MapVisualizer;

namespace Simulator;

public abstract class Creature : IMappable
{

    //pola
    private string name;
    private int level = 1; //default value
    private Point position;
    private Map map;
    public Point Position { get; private set; }
    public Map? Map { get; private set; }

    //konstruktor
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Info
    {
        get;
    }
    public virtual string Greeting() => $"Hi, I'm {Name}, and my level is {Level}";

    public string Name
    {
        get { return name; }
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');

            if (char.IsLower(name[0]))
            {
                name = char.ToUpper(name[0]) + name.Substring(1);
            }

        }

    }
    public int Level
    {
        get { return level; }
        init
        {
            level = value;
            level = Validator.Limiter(value, 1, 10);
        }
    }
    public abstract int Power { get; } 

    //metoda
    public void Upgrade()
    {
        if (level < 10) level ++; 
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (!map.Exist(position)) throw new ArgumentException($"This point does not belong to the map");

        Map = map;
        Position = position;
        map.Add(this, position);
    }
    public void Go(Direction direction) // alfonso.Go(Direction.Left)
    {

        if (Map == null) throw new InvalidOperationException("No map assigned");
        //Get the next position based on the direction 
        Point nextPosition = Map.Next(Position, direction);
        //Move the creature on the map
        Map.Move(this, Position, nextPosition);
        //Update the position
        Position = nextPosition;
        
       
    }
    void IMappable.Go(Direction direction)
    {
        this.Go(direction);
    }

    object IMappable.Name
    {
        get => Name;
        set=> throw new NotImplementedException();
    }











}