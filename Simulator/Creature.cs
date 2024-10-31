using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace Simulator;

public class Creature
{


    //pola
    private string name;
    private int level = 1; //default value


    //konstruktor
    public Creature(string name, int level = 1)
    {
        Name = name; //initial value
        Level = level;
    }
    public Creature() { } //konstruktor bezparametrowy
    public string Info //właściwość automatyczna - pole publiczne z get/set
    {
        get { return $"{Name} [{Level}]"; }
    }
    public void SayHi() //metoda
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }


    //właściwości automatyczne 
    public string Name
    {
        get { return name; } //name to odwołanie do pola klasy
        set
        {
            name = (value ?? "Unknown");
            name = name.Trim();
            //?? returns a value of its left hand operand 
            //if it isn't null


            if (name.Length < 3)
            {
                for (int i = 0; i < (3 - name.Length); i++)
                {
                    name += "#";
                }
            }
            else if (name.Length > 25)
            {
                //string name_holder = "";
                name = name.Substring(0, 25);
                name = name.TrimEnd();
                if (name.Length < 3) { name += "#"; }

            }

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
        init { level = value;
            if (level > 10)
            {
                level = 10;
            }
            else if (level < 1)
            { 
                level = 1;
            }
        }
    }

    //metoda
    public void Upgrade()
    {
        if (level < 10) { level += 1; }
    }

    private string x;
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








}

