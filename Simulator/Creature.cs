using System.Numerics;

namespace Simulator;

public abstract class Creature
{

    //pola
    private string name;
    private int level = 1; //default value


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
    public abstract void SayHi();

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
    public abstract int Power { get; } //abstract property



    //metoda
    public void Upgrade()
    {
        if (level < 10) { level += 1; }
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }


    //private string x;
    public string[] Go(string dir12) => Go(DirectionParser.Parse(dir12));


    public string Go(Direction dir2) => $"{dir2.ToString().ToLower()}";

    public string[]  Go(Direction[] directions) //tablica ze zmiennymi typu Direction
    {
        var result = new string[directions.Length];

        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }

        return result; 
    }
    //klasy pochodne tworzymy odwołując się przez : do klasy bazowej




    








}

