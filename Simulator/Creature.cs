using Simulator.Maps;
using System.Drawing;

namespace Simulator;

public abstract class Creature
{
    public int Map? Map { get; private set; } //po stworzeniu jego mapa to moze byc null
    public int Point Position { get; private set; } //struct ma wartosc domyslna
    //zainicjować stwora - on jeszcze nie ma mapy i pozycji
    // dopiero potem wrzucamy je razem na mapę
    //private set zeby ktos nie pzestawi stwora
    //pola
    //add będzie potrzebowało mieć stwora i pozycję //zeby polozyc creature na odpowiedniej mapie mamy add
    /*
     * move z creature i position
     * 
     remove tez ma stwora i punkt //zeby podniesc mamy remove
    creature from to 
     
     */

    public void InitMapAndPosition(Map map, Point point)

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
    //out
    public string[] Go(string dir12) => Go(DirectionParser.Parse(dir12));


    public string Go(Direction dir2)
    {
        //zgodnie z regulami
       return $"{dir2.ToString().ToLower()}";
}
   
    //out
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

