using System.Net.Security;
using System.Net.WebSockets;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");


        //Animals
        Animals c2 = new() { Description = "Dogs", Size = 3 };
        Console.WriteLine(c2.Info);

        Animals c3 = new() { Description = "A", Size = 5 };
        Console.WriteLine(c3.Info);
        Animals c4 = new() { Description = "Capibara_Orangulangus_Cornicus", Size = 49 };
        Console.WriteLine(c4.Info);
        

        /*
        Elf e0 = new() { Name = "Elandor", Level = 6 };
        e0.SayHi();
        e0.Upgrade();
        Console.WriteLine(e0.Info);
        //class Elf can refer to its own components or inherited components


        Elf legolas = new() { Name = "Legolas", Agility = 3 };
        legolas.SayHi(); //method of Creature base class
        Console.WriteLine($"{legolas.Name} - agility {legolas.Agility}");
        legolas.Sing(); //method of Elf derived class


        Orc o9 = new("Gorbag", rage: 5);
        Console.WriteLine($"{o9.Name} / level {o9.Level} / rage {o9.Rage}");
        Orc gendrin = new("Gendrin", rage: 7);
        Console.WriteLine($"{gendrin.Name} / level {gendrin.Level} / rage {gendrin.Rage}");
        */

        Orc o1 = new();
        Console.WriteLine($"{o1.Name} / level {o1.Level} / rage {o1.Rage}");
        // Unknown Orc / level 10 / rage 6

        //tworzenie elfa i orca przez Creature - rzutowanie klas
        //ell.Sing(); // w rzutowaniu na typ bazowy nie jestem w stanie zrobić downcasting
        //konwersja typów
        //do Elf_test
        Elf_test e = new() { Name = "Elandor", Level = 6 }; //Agility=1
        e.SayHi();
        e.Upgrade();
        Console.WriteLine(e.Info);
        Elf_test legolas = new() { Name = "Legolas", Agility = 3 }; //Level =1 
        legolas.SayHi();
        Console.WriteLine($"{legolas.Name} - agility {legolas.Agility}");
        legolas.Sing();

        Lab4a();
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




}
