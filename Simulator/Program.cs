namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        var c = new Creature("Amantha");
        c.SayHi();

        string name = c.Name;
        int level = c.Level;
        
        c.Level = 16;
        c.SayHi();
        string information_c = c.Info;
        Console.WriteLine(information_c);

        //Animals
        Animals c2 = new() { Description = "Dogs", Size = 3 };
        string information_c2 = c2.Info;
        Console.WriteLine(information_c2);
    }
}
