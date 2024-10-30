namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        var c = new Creature("Amantha");
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        //Animals
        Animals c2 = new() { Description = "Dogs", Size = 3 };
        Console.WriteLine(c2.Info);

        Animals c3 = new() { Description = "A", Size = 5 };
        Console.WriteLine(c3.Info);
        Animals c4 = new() { Description = "Capibara_Orangulangus_Cornicus", Size = 49 };
        Console.WriteLine(c4.Info);
        Lab3a();
        
    }
    static void Lab3a()
    {
        Creature c = new() { Name = "   Shrek    ", Level = 20 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  ", -5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  donkey ") { Level = 7 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("Puss in Boots – a clever and brave cat.");
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("a                            troll name", 5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }
    
}
