using Simulator.Maps;
using System.Net.Security;
using System.Net.WebSockets;
using System.Xml.Linq;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        //Lab4a();
        //Lab4b();
        //Lab5a();
        Lab5b();
    


    }
    static void Lab5b() //map
    {
        Point p = new(2, 0);
        Console.Write("Coordinates of a new map: ");
        SmallSquareMap firstMap = new(5);
        Console.WriteLine(firstMap.Size);

        p = firstMap.Next(p,Direction.Up); //(2,1)
        Console.WriteLine(p);
        try
        {
            p = new(4, 4);
            p = firstMap.Next(p, Direction.Up);
            Console.WriteLine(p);
        }
        catch(NotImplementedException exc)
        {   
                Console.WriteLine(exc.Message);
        }
        try
        {
            SmallSquareMap secondMap = new(21);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($" {e.Message}");
        }
        //sprawdzenie czy Exist działa
        Console.WriteLine($"Check if point {p} belongs to the map: {firstMap.Exist(p)}");
        Point pr = new(7, 6);
        Console.WriteLine($"Check if point {pr} belongs to the map: {firstMap.Exist(pr)}");
        Point pr2 = new(2, 3);
        Console.WriteLine($"Check if point {pr2} belongs to the map: {firstMap.Exist(pr2)}");
        Console.WriteLine(firstMap.NextDiagonal(pr2, Direction.Up));
        

        
    }

    static void Lab5a()
    {
        Point p = new(10, 25);
        Console.WriteLine("Next: "+ p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine("NextDiagonal: "+ p.NextDiagonal(Direction.Right));  // (11, 24)

        try
        {
            Rectangle prostokat = new(10, 25, 10, 15);
            Console.WriteLine(prostokat);
        }
        catch (ArgumentException de)
        {
            Console.WriteLine($"{de.GetType().Name}: {de.Message}");
        }
        //sprawdzenie czy wspołrzędne są przestawiane
        Rectangle prostokat2 = new(7, 3, 4, 5);
        Console.WriteLine(prostokat2);

        try
        {
            Rectangle prostokat3 = new(25, 10, 5, 10);
            Console.WriteLine(prostokat3);
        }
        catch (ArgumentException de)
        {
            Console.WriteLine($"{de.GetType().Name}: {de.Message}");

        }
        //sprawdzenie bool Contains(Point point)
        Point p1 = new(10, 25);
        Point p2 = new(2, 15);
        Rectangle prostokat4 = new(p1, p2);
        Console.WriteLine(prostokat4);
        Point p3 = new(30, 20);
        Point p4 = new(4, 16);
        Point p5 = new(60, 25);
        Console.WriteLine("Sprawdź czy prostokąt zawiera podany punkt");
        Console.WriteLine($"{p3}: {prostokat4.Contains(p3)}");
        Console.WriteLine($"{p4}: {prostokat4.Contains(p4)}");
        Console.WriteLine($"{p5}: {prostokat4.Contains(p5)}");

    }
    static void Lab4a()
    {

        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }




}
