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
            name = (value ?? "Unknown").Trim();
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
    public abstract int Power {get;} //abstract property
   


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
    public void Go(string dir1)
    {
        Direction[] newDirect = DirectionParser.Parse(dir1);
        Go(newDirect);

    }

    public void Go(Direction dir2) //zmienna typu Direction
    {

        string floor = dir2.ToString().ToLower();
        Console.WriteLine($"{Name} goes {floor}");

    }
    public void Go(Direction[] directions) //tablica ze zmiennymi typu Direction
    {
        for (int i = 0; i < directions.Length; i++)
        {
            string floor = directions[i].ToString().ToLower();
            Console.WriteLine($"{Name} goes {floor}");
        }
    }
    //klasy pochodne tworzymy odwołując się przez : do klasy bazowej




    








}

