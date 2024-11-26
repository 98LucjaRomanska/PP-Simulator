using System.Text;
using Simulator.Maps;
using Simulator;


namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Hello, World!");
        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();
        var turn = 1;

        while (!simulation.Finished)
        {
            Console.ReadKey();

            Console.WriteLine($"Runda {turn}");
            Console.Write($"{simulation.CurrentCreature.Info}" +
                $"{simulation.CurrentCreature.Position} " +
                $"goes {simulation.CurrentMoveName}\n");

            Console.WriteLine();
            simulation.Turn();
            mapVisualizer.Draw();
            turn++;
        
        }
       
    }
}
