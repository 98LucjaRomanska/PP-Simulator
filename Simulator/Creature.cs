using Simulator.Maps;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Simulator;

public abstract class Creature
{

    //pola
    private string name;
    private int level = 1; //default value
    private Point position;
    private Map map;


    //konstruktor
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Point Position { get; private set; }
    public Map? Map { get; private set; }

    public Creature() { }
    public abstract string Info
    {
        get;
    }
    public virtual string Greeting() => $"Hi, I'm {Name}, and my level is {Level}";

    public string Name
    {
        get { return name; }
        set
        {
            //name = (value ?? "Unknown").Trim();
            name = Validator.Shortener(value, 3, 25, '#');


            if (char.IsLower(name[0]))
            {
                name = char.ToUpper(name[0]) + name.Substring(1);
                //.Substring(int startIndex, int length) - określam początek i długość 
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
        if (level < 10) { level += 1; }
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public void InitializeMP(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException($"Creature cannot be moved from one map to another");
        if (!map.Exist(position)) throw new ArgumentException($"This point does not belong to the map");

        Map = map;
        Position = position;
        Map.Add(this, position);
    }
    public string Go(Direction direction) // alfonso.Go(Direction.Left)
    {
        
        if (Map == null) return "No map assigned";

        Point nextPosition = Map.Next(Position, direction);

        Map.Move(this, Position, nextPosition);
        Position = nextPosition;
        return $"{Name} goes {direction.ToString().ToLower()}.";
        /*
        Map?.Move(this, Position, Map.Next(Position, direction));

        return $"{direction.ToString().ToLower()}";
        */
    }












}