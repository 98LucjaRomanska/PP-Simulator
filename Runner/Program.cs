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
        //Lab5b();
        Lab7();
        //TestSmallMapFunctions();



    }
        static void TestSmallMapFunctions()
        {
            // Create a new map of size 5x5
            SmallSquareMap squareMap = new SmallSquareMap(5);

            // Create a new dragon named "Dragon" at level 1
            Creature dragon = new Elf("Dragon", 1); // Assuming "Dragon" is a subclass of Creature

            // Add the dragon to the map at position (2, 2)
            Point p = new Point(2, 2);
            squareMap.Add(dragon, p);

            // Print the dragon's position
            Console.WriteLine($"Creature '{dragon.Name}' added at position {dragon.Position}");

            // Check if the dragon is at position (2, 2)
            var points_whereS = squareMap.At(p);
            Console.WriteLine($"Creatures at position {p}:");
            foreach (Creature c in points_whereS)
            {
                Console.WriteLine(c.Greeting());
            }

            // Move the dragon to a new position (3, 3)

            Point newPosition = new Point(3, 3);
            squareMap.Move(dragon, p, newPosition);

            Console.WriteLine($"Creature {dragon.Name} moved to position {dragon.Position}");

            // Check if the dragon is now at position (3, 3)
            var where_cStands = squareMap.At(newPosition);
            Console.WriteLine($"Creatures at position {newPosition}:");

            foreach (var c in where_cStands)
            {
                //Console.WriteLine(c.Greeting());
            }
            Console.WriteLine(squareMap.At(newPosition));


            // Remove the dragon from the map
            squareMap.Remove(dragon, newPosition);
            Console.WriteLine($"Creature '{dragon.Name}' removed from the map.");

            // Check if the dragon is still on the map (should return an empty list)
            squareMap.At(newPosition);
            Console.WriteLine($"Creatures at position {newPosition} after removal:");
            Console.WriteLine(squareMap.At(newPosition));
        }
        static void Lab7()
        {
            //stwory
            Elf ragnarok = new Elf("Ragnarok", 1, 1);
            Elf gloria = new Elf("Gloria", 17);

            Orc osman = new Orc("Osman", 2);
            Orc oran = new Orc("Oran", 1);

            //lista
            Creature[] _toAdd = { osman, oran, ragnarok,gloria };
            

            //mapa
            SmallSquareMap firstMap = new(20);
            Point p0 = new Point(3, 1);
            firstMap.Add(ragnarok, p0);
            firstMap.Add(gloria, p0);
            Console.WriteLine(firstMap.At(p0));


        }
        static void Lab5b() //map
        {
            Point p = new(2, 0);

            SmallSquareMap firstMap = new(5);
            //Console.WriteLine(firstMap.Size);
            Console.Write($"Coordinates of a new map: {firstMap.SizeX},{firstMap.SizeY}");

            p = firstMap.Next(p, Direction.Up); //(2,1)
            Console.WriteLine(p);
            try
            {
                p = new(4, 4);
                p = firstMap.Next(p, Direction.Up);
                Console.WriteLine(p);
            }
            catch (NotImplementedException exc)
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
        static void Dictionary_to_check()
        {
            var p = new Dictionary<string, int>(); // country population in millions

            p.Add("Poland", 37);    // add 
            p.Add("China", 1437);
            // p.Add("China", 100); // error - key present
            p["India"] = 100;       // another way to add, where key is absent
            p["India"] = 1412;      // update, because key is present 
            p["USA"] = 337;
            p["France"] = 336;
            p.Add("Russia", 145);
            p.Add("UK", 68);

            p.Remove("Russia");     // key present -> remove and return true
                                    //p.Remove("France");     // key absent -> return false

            if (p.ContainsKey("France")) { p["France"] = 3; /* do something */ }
            if (p.ContainsValue(37)) { /* do something */ }  // possible, but slow

            Console.WriteLine(p["Poland"]);
            // Console.WriteLine(p["France"]);  // error - key absent

            // iterate keys or values or key-value-pairs:
            foreach (string s in p.Keys) Console.Write(s + " ");
            Console.WriteLine();
            foreach (int i in p.Values) Console.Write(i + " ");
            Console.WriteLine();
            foreach (KeyValuePair<string, int> element in p)
            {
                Console.WriteLine($"{element.Key,-15}: {element.Value,4}");
            }
        }
        static void Lab5a()
        {
            Point p = new(10, 25);
            Console.WriteLine("Next: " + p.Next(Direction.Right));          // (11, 25)
            Console.WriteLine("NextDiagonal: " + p.NextDiagonal(Direction.Right));  // (11, 24)

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
            o.Greeting();
            for (int i = 0; i < 10; i++)
            {
                o.Hunt();
                o.Greeting();
            }

            Console.WriteLine("\nSING TEST\n");
            var e = new Elf("Legolas", agility: 2);
            e.Greeting();
            for (int i = 0; i < 10; i++)
            {
                e.Sing();
                e.Greeting();
            }

            Console.WriteLine("\nPOWER TEST\n");
            Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
            foreach (Creature dragon in creatures)
            {
                Console.WriteLine($"{dragon.Name,-15}: {dragon.Power}");
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
